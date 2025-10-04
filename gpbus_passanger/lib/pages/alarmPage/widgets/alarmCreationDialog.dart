import 'package:dio/dio.dart';
import 'package:flutter/material.dart';
import 'package:gpbus_passanger/pages/alarmPage/alarmMapPage.dart';
import 'package:gpbus_passanger/pages/alarmPage/widgets/timePickerWidget.dart';
import 'package:gpbus_passanger/singleton/userInfo.dart';
import 'package:gpbus_passanger/utils/alarm.dart';
import 'package:gpbus_passanger/utils/customExceptions/custom_server_exceptions.dart';
import 'package:gpbus_passanger/utils/server_requests.dart';
import 'package:gpbus_passanger/widgets/busSearchBar.dart';
import 'package:gpbus_passanger/widgets/infoTextBox.dart';
import 'package:latlong2/latlong.dart';

class AlarmCreationDialog extends StatefulWidget {
  final Function onAlarmCreated; 
  final UserInfo userInfo;
  AlarmCreationDialog({super.key, required this.userInfo, required this.onAlarmCreated});

  @override
  _AlarmCreationDialogState createState() => _AlarmCreationDialogState();
}

class AppColors {
  static const Color primaryColor = Color(0xFFffc966);
  static const Color accentColor = Colors.blue;
  static const Color textColor = Colors.black;
  static const Color disabledTextColor = Colors.grey;
}
class _AlarmCreationDialogState extends State<AlarmCreationDialog> {
  late UserInfo _userInfo;

  //alarm realted
  bool _isCreatingAlarm = false;
  TimeOfDay _startTime = TimeOfDay.now();
  TimeOfDay _endTime = TimeOfDay.now();
  int _busId=-1;
  double _alarmRadius=-1;//-1 indicates that it has not been initialized
  late LatLng _alarmPosition;

  //bus map
  CancelToken _cancelGetBusInfo = CancelToken(); 
  List<double>  _busLoc = [];
  List<List<double>> _busRoute = [];
  bool _isLoadingBus=false;
  
  //widget activation
  String _errorMsg="";

  @override
  void initState(){
    super.initState();
    _userInfo = widget.userInfo;
  }
  @override 
  void dispose(){
    _cancelGetBusInfo.cancel("disposed widget");
    super.dispose();
  }

  Future<void> loadBusInfo(int busId, context)async {
    _cancelGetBusInfo.cancel("loading another bus");
    _cancelGetBusInfo= CancelToken();
    
    try{
      List<double> busLocAux = await getBusLocation(context, _cancelGetBusInfo, busId);
      List<List<double>> busRouteAux = await getBusRoute(context, _cancelGetBusInfo, busId);
      setState(() {
        _isLoadingBus=false;
        busId=busId;
        _busLoc=busLocAux;
        _busRoute=busRouteAux;
      });
    }on DioException catch (e){
      if(e.type==DioExceptionType.cancel){
        //if the request is canceled, nothing happens
      }else{
        rethrow;
      }
    }on CustomNavigatedToLoginPageException{
      //do nothing 
    }
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      content: SizedBox(
        width: MediaQuery.of(context).size.width * 0.9,
        child: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            Row(
              children: [
                TimePickerWidget(
                  label: "começo:",
                  selectedTime: _startTime,
                  onTimeChanged: (newTime) {
                    print(newTime);
                    setState(() {
                      _startTime = newTime;
                    });
                  },
                ),
                TimePickerWidget(
                  label: "fim:",
                  selectedTime: _endTime,
                  onTimeChanged: (newTime) {
                    setState(() {
                      print(newTime);
                      _endTime = newTime;
                    });
                  },
                ),
              ],
            ),
            const SizedBox(height: 16),
            //BusSearchBar
            BusSearchBar(
              busIds: _userInfo.busIds!,
              hintText: "Escolha o ônibus",
              onBusSelected: (newBus) {
                loadBusInfo(newBus,context);
                setState(() {
                  _isLoadingBus=true;
                  _busId = newBus;
                });
              },
            ),
            if(_errorMsg!="")
              Column(children: [
                SizedBox(height: 16),
                infoTextBoxBuilder(_errorMsg, -1)!
              ],),
              
            const SizedBox(height: 16),
            if(_busId == -1)
              _buildDisabledButton()
            else if(_isLoadingBus) 
              _buildLoadingWidget("Trazendo informações do ônibus...")
            else if(_isCreatingAlarm) 
              _buildLoadingWidget("Criando alarme...")
            else if(_alarmRadius==-1)
              _buildSelectLocationButton()
            else
              _buildCreateAlarmButton()
          ],
        ),
      ),
      backgroundColor: Colors.white, // Cor de fundo do AlertDialog
    );
  }
  Widget _buildDisabledButton() {
    return ElevatedButton(
      onPressed: () {},
      style: ElevatedButton.styleFrom(
        padding: EdgeInsets.all(4),
        backgroundColor: const Color.fromARGB(255, 207, 207, 207),
        foregroundColor: AppColors.textColor,
      ),
      child: Text('Escolha o ônibus primeiro!'),
    );
  }

  Widget _buildLoadingWidget(String mensagem) {
    return Container(
      padding: EdgeInsets.symmetric(vertical: 12, horizontal: 16),
      decoration: BoxDecoration(
        color: AppColors.primaryColor,
        borderRadius: BorderRadius.circular(8),
      ),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Text(
            mensagem,
            style: TextStyle(
              color: AppColors.textColor,
              fontWeight: FontWeight.w500,
            ),
          ),
          SizedBox(width: 12),
          SizedBox(
            width: 20,
            height: 20,
            child: CircularProgressIndicator(
              color: AppColors.textColor,
              strokeWidth: 2,
            ),
          ),
        ],
      ),
    );
  }

  Widget _buildSelectLocationButton() {
    return ElevatedButton(
      onPressed: () async {
        final resultado = await Navigator.push(
          context,
          MaterialPageRoute(builder: (context) {
            return AlarmMapPage(
              busRoute: _busRoute, 
              busLocation: _busLoc
            );
          }),
        );
        
        setState(() {
          _alarmPosition = resultado[1];
          _alarmRadius = resultado[0];
        });
      },
      style: ElevatedButton.styleFrom(
        backgroundColor: AppColors.primaryColor,
        foregroundColor: AppColors.textColor,
      ),
      child: Text('Escolher local do alarme para ônibus: $_busId'),
    );
  }

  Widget _buildCreateAlarmButton() {
    return ElevatedButton(
      onPressed: () async {
        setState(() {
          _isCreatingAlarm=true;
          _errorMsg="";
        });
        try{
          Alarm alarme = Alarm(-1, _userInfo.name, _busId, _startTime, _endTime, _alarmPosition.latitude, _alarmPosition.longitude, _alarmRadius);

          await createAlarm(context, _userInfo.name, _userInfo.password, alarme);

          widget.onAlarmCreated();
          Navigator.pop(context);
        }on CustomNavigatedToLoginPageException{
          //do nothing
        }on DioException catch (e){
          if (e.response?.statusCode == 400) {
            setState((){
              _errorMsg="Os horários de começo e fim dos alarmes não fazem sentido";
              _isCreatingAlarm = false;
            });
          }else{
            rethrow;
          }
        }
      },
      style: ElevatedButton.styleFrom(
        backgroundColor: AppColors.primaryColor,
        foregroundColor: AppColors.textColor,
      ),
      child: Text('Criar Alarme!'),
    );
  }

}

