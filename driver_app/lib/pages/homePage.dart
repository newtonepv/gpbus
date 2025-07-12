// ignore_for_file: prefer_interpolation_to_compose_strings

import 'dart:async';
import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:geolocator/geolocator.dart';
import 'package:dio/dio.dart';
import 'package:pegaloc/widgets/busSearchBar.dart'; 
import '../widgets/infoTextBox.dart'; 
import '../main.dart';


Future<Position> getCurrentLocation() async {
  bool serviceEnabled = await Geolocator.isLocationServiceEnabled();
  //Tratamento de erros de não ativação de localização:
  if (!serviceEnabled) {
    return Future.error('Habilite a localização.');
  }

  //Tratamento de erros de permissão:
  List<LocationPermission> deniedPermissions = [LocationPermission.deniedForever, LocationPermission.denied];
  LocationPermission permission = await Geolocator.checkPermission();
  if (deniedPermissions.contains(permission)) {
    permission = await Geolocator.requestPermission();
    if (deniedPermissions.contains(permission)) {
    return Future.error('As permissões de localização foram negadas, vá para configurações e habilite.');
    }
  }

  return await Geolocator.getCurrentPosition(
    desiredAccuracy: LocationAccuracy.high,
  );
}



Future<Response> updateBusLocApiRequest(Dio httpClient,CancelToken locationUpdateCompleter, int busid, double newLatitude, double newLongitude, int driverId, String driverPassword ) async{ 
  String host = "https://gpbus-psql-python-rest-api.onrender.com";
  return  await httpClient.get(host+'/udtBusLoc/',
  queryParameters: {
    'busid': busid.toString(),
    'latitude': newLatitude.toString(),
    'longitude': newLongitude.toString(),
    'idDriver': driverId.toString(),
    'driverPassword': driverPassword.toString()
  },
  cancelToken: locationUpdateCompleter
  );
}
void loadLoginPage({required BuildContext context, String errorMsg=""}){
  
  Navigator.pushReplacement(
    context, 
    MaterialPageRoute(builder: (context) => FormContainer(errorMsg: errorMsg,))
  );
}

class BusDriverPage extends StatelessWidget {
  final String title = "Voltar";
  final ThemeData theme;
  final String driverPassword;
  final int driverId;
  const BusDriverPage({Key? key, required this.theme, required this.driverId, required this.driverPassword}) : super(key: key);
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: title,
      theme: theme,
      home: BusDriverPageBody(title: title, driverId: driverId, driverPassword: driverPassword),
    );
  }
}

class BusDriverPageBody extends StatefulWidget {
  final String title;
  final String driverPassword;
  final int driverId;
  const BusDriverPageBody({Key? key, required this.title, required this.driverId,required this.driverPassword}) : super(key: key);
  @override
  BusDriverPageBodyState createState() => BusDriverPageBodyState();
}

class BusDriverPageBodyState extends State<BusDriverPageBody> {
  
  SearchController searchController = SearchController();
  Timer? _timer; // Usado para controlar o intervalo de atualização
  int busSelected= -1;
  late Dio httpClient;
  late CancelToken _locationUpdateToken;
  bool postingLocFlag = false;
  bool isLoadingPageFlag=true;
  List<int> busIdList=[];
  String errorMsg = "";
  String infoTextBoxMessage = "";
  int infoTextBoxColorCode = 0;
  final String erroServidorCheio = "O servidor está cheio, tente novamente mais tarde";
  @override
  void initState(){
    super.initState();
    httpClient=Dio();
    _locationUpdateToken = CancelToken();
    _loadBusIds(httpClient);
  }  

  void _loadLoginPage({required BuildContext context, String errorMsg=""}){
    
    Navigator.pushReplacement(
              context, 
              MaterialPageRoute(builder: (context) => FormContainer(errorMsg: errorMsg,))
            );
  }
    
  bool _handle502DioExceptions(DioException e){
    if(e.response!=null){
      if(e.response!.statusCode==502){
        //deu servidor cheio
        print("vamos primeiro fechar as corrotinas");
        _stopPostingLoc();//tentar parar as corrotinas atuais
        _loadLoginPage(context: context, errorMsg: erroServidorCheio);
        return true;
      }
    }
    return false;
  }

  Future<void> _loadBusIds(Dio httpClient) async{
    setState(() {isLoadingPageFlag=true;});
    try{
      print("mandou req http pedindo bus ids");

      String host = "https://gpbus-psql-python-rest-api.onrender.com";
      final response = await httpClient.get(host+'/busids');
      print("recebeu bus ids: "+ json.decode(response.data['ids']).toString());

      setState(() {
        busIdList = List<int>.from(json.decode(response.data['ids']));
        isLoadingPageFlag=false;
        });
    }on DioException catch (e){
      if(_handle502DioExceptions(e)==false){
        print("[ERROR] func _loadBusIds: "+e.toString());
      }
    }
  }

  Future<void> _updateBusLoc(Dio httpClient, CancelToken locationUpdateCompleter, int busid, double newLatitude, double newLongitude, int driverId, String driverPassword ) async {
    try{
      print("mandou req http...");
      final response = await updateBusLocApiRequest(httpClient,locationUpdateCompleter, busid,newLatitude,newLongitude,driverId,driverPassword);
      print("response.statusCode: "+response.statusCode.toString());
      setState(() {
        infoTextBoxMessage="Movendo o Onibus";
        infoTextBoxColorCode=1;
      });
    }on DioException catch (e){
      if(_handle502DioExceptions(e)==false){
        throw e;// passa ela para ser 
      }
    } 
  }

  void _stopPostingLoc() {
    print("stopPostingLoc");
    _locationUpdateToken.cancel("Parou de publicar a localização");
    _locationUpdateToken = CancelToken();
    _timer?.cancel();
    _timer = null;

    setState(() {         
      infoTextBoxMessage = "";
      postingLocFlag = false;
    });
  }

  void _startPostingLoc(int busId) {
    setState(() {
      errorMsg="";
      postingLocFlag = true;
      infoTextBoxMessage = "Acessando os servidores...";
      infoTextBoxColorCode=0;
    });
    
    _timer = Timer.periodic(const Duration(seconds: 1), (timer) async {
      if (!timer.isActive) return;
      //get the loc
      late String msg="";
      try{
        Position currentPosition = await getCurrentLocation();
        await _updateBusLoc(httpClient, _locationUpdateToken, busId, currentPosition.latitude, currentPosition.longitude, widget.driverId, widget.driverPassword);
      }on DioException catch (e){
        if(e.response?.statusCode==401){
          msg="Voce não tem permissão para dirigir este onibus";
        }else if(e.type == DioExceptionType.cancel){
          errorMsg=msg;
        }else{
          msg= e.toString();
        }
        _stopPostingLoc();
      }catch (e){
        msg=e.toString();
        _stopPostingLoc();
      }finally{
        print("erro obtido" + msg);
        setState(() {
          errorMsg=msg;
        });
      }
    });
    
  }


  void busSelectedCallback(int bus){
    print("selecionou: "+bus.toString());
    setState(() {
      busSelected=bus;
    });
  }
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
      title: Text(widget.title),
      leading: IconButton(
        icon: Icon(Icons.arrow_back),
        onPressed: () {
          _loadLoginPage(context: context);
        },
      ),
    ),
      body: Center(
        child: _buildContent()
      ),
    );
  }
  Widget _buildContent(){
    if(isLoadingPageFlag){
      return buildLoadingIndicator();
    }else{
      return _buildMainContent();
    }
  }
  
  Widget _buildMainContent(){
    return Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        BusSearchBar(busIds:busIdList,onBusSelected: busSelectedCallback, hintText: 'Escolha o ônibus que quer dirigir',),
        const SizedBox(height: 20),//padding
        if(busSelected != -1)
          // ...existing code...
          ElevatedButton(
            onPressed: () {
              if(!postingLocFlag){
                _startPostingLoc(busSelected);
              }else{
                _stopPostingLoc();
              }
            },
            style: ButtonStyle(
              maximumSize: WidgetStateProperty.all<Size>(const Size(280, double.infinity)),
              backgroundColor: WidgetStateProperty.all<Color>(const Color.fromARGB(255, 255, 180, 95)),
              padding: WidgetStateProperty.all<EdgeInsets>(const EdgeInsets.all(16)),
            ),
            child: Row(
              mainAxisSize: MainAxisSize.min,
              children: [
                Icon(postingLocFlag ? Icons.stop : Icons.play_arrow, size: 30),
                const SizedBox(width: 8),
                Expanded(
                  child: Text(
                    !(postingLocFlag) 
                      ? 'Mover o ônibus no aplicativo para a localização do celular' 
                      : 'Parar de mover o ônibus no aplicativo',
                    textAlign: TextAlign.center,
                    style: const TextStyle(fontSize: 16),
                    softWrap: true,
                  ),
                ),
              ],
            )
          ),
        if(infoTextBox(errorMsg,-1) != null) infoTextBox(errorMsg,-1)!,
        if(infoTextBox(infoTextBoxMessage,infoTextBoxColorCode) != null) infoTextBox(infoTextBoxMessage,infoTextBoxColorCode)!,
      ],
    );
  }
}




Widget buildLoadingIndicator() {
    return Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        const CircularProgressIndicator(
          color: Color.fromARGB(255, 65, 31, 0),
          strokeWidth: 3,
        ),
        const SizedBox(height: 16),
        Text(
          'Carregando linhas de ônibus...',
          style: TextStyle(
            fontSize: 16,
            color: Colors.grey[600],
          ),
        ),
      ],
    );
  }