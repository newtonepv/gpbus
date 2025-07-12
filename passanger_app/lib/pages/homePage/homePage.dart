// ignore_for_file: prefer_const_constructors, prefer_final_fields, prefer_interpolation_to_compose_strings
//!Autocomplete

import 'dart:async';
import 'package:dio/dio.dart';
import 'package:flutter/material.dart';
import 'package:flutter_map/flutter_map.dart';
import 'package:geolocator/geolocator.dart';
import 'package:tcc_teste/pages/homePage/widgets/mapBuilder.dart';
import 'package:tcc_teste/pages/homePage/widgets/loadingPage.dart';
import 'package:tcc_teste/pages/homePage/widgets/homeBottomNavigationBar.dart';
import 'package:tcc_teste/pages/homePage/widgets/menu.dart';
import 'package:tcc_teste/utils/changingPageFunctions.dart';
import 'package:tcc_teste/utils/locationServices.dart';
import 'package:tcc_teste/utils/server_requests.dart';
import 'package:tcc_teste/pages/homePage/widgets/busSearchBar.dart';
import 'package:tcc_teste/widgets/infoTextBox.dart';


class HomePage extends StatefulWidget {
  const HomePage({super.key});
  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  List<int> _busIds = []; 
  MapController _mapController = MapController();
  SearchController _searchController = SearchController();
  List<double> _userLocation =[];
  List<double> _busLocation =[];
  List<List<double>> _busRoute = [];
  Timer? _timer;
  CancelToken _busLocationLoadCancelToken = CancelToken();
  //whenever i make a update about the map, i want to set this both to false
  bool _focusBusLocation = false;
  bool _focusUserLocation = true;

  String _busRelatedMessage='';
  int _infoMessageCode=0;
  String _locationRelatedMessage= '';
  int _locationRelatedMessageCode=0;



  void _startGettingBusCoordinates(int busid) async {
    _timer?.cancel(); // Cancelar o temporizador existente
    _busLocationLoadCancelToken.cancel("Canceled Request");
    _busLocationLoadCancelToken = CancelToken();
    bool _isFirstTimeLoadingMapWithThisBus=true;
    setState(() {
      _busRelatedMessage = "Obtendo ônibus do servidor";
      _infoMessageCode=0;
    });
    //tem que cancelar a request
    const interval = Duration(seconds: 1);
    _timer = Timer.periodic(interval, (timer) async {
      try{
        List<double> newBusLocation = await getBusLocation(_busLocationLoadCancelToken, busid);
        List<List<double>> newBusRoute = await getBusRoute(_busLocationLoadCancelToken, busid);
        
        setState(() {
          if(_busRelatedMessage.isNotEmpty){
            _busRelatedMessage="";
          }
          _busRoute = newBusRoute;
          _busLocation = newBusLocation;
          _focusUserLocation = false;
          _focusBusLocation = _isFirstTimeLoadingMapWithThisBus;
        });
        _isFirstTimeLoadingMapWithThisBus=false;
        
      }on DioException catch (e){
        //handle full server
        if(e.type==DioExceptionType.cancel){
          //if this req was canceled, then lets do nothing
        }
        if(_handle502DioExceptions(e)==false){
          throw e;
        }
      }
      
      //error handling etc
      
    });
  }

  @override
  void initState() {
    super.initState();
    _loadBusIds();
  }
  
  bool _handle502DioExceptions(DioException e){
    if(e.response!=null){
      if(e.response!.statusCode==502){
        //full server
        //try to close coroutines
        loadLoginPage(context: context, errorMsg: "O servidor está cheio, tente novamente mais tarde");
        return true;
      }
    }
    return false;
  }

  Future<void> _loadBusIds() async {
    try{
      final List<int> newbusIds=await serverLoadBusIds();
      setState(() {
        _busIds=newbusIds;
      });
    }on DioException catch (e){
      if(_handle502DioExceptions(e)==false){// if it is not a 502 error, dont catch it
        print("[ERROR] " + e.toString());
        throw e;
      }
    }on Exception catch (e){
      print("[ERROR] " + e.toString());
      throw e;
    }
  }

  @override
  void dispose() {
    _searchController.dispose();
    _timer?.cancel(); // Cancelar o timer ao sair da tela
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    // Desabilita a funcionalidade de voltar à tela anterior
    if(_busIds.isEmpty){
      return LoadingPage(msg:'Carregando onibus');
    }else{
      return Scaffold(
        appBar: AppBar(
          automaticallyImplyLeading: false,
          toolbarHeight: 45,
          leading: IconButton(
            icon: const Icon(Icons.arrow_back),
            color: Colors.black,
            onPressed: () {
              loadLoginPage(context: context, errorMsg:"");
            },
          ),
          backgroundColor: const Color(0xFFffc966),
          title: Container(
            padding: const EdgeInsets.symmetric(horizontal: 8),
            height: 27,
            child: BusSearchBar(
              busIds: _busIds,
              onBusSelected: (int busIdSelected){
                _startGettingBusCoordinates(busIdSelected);
              },
              hintText: "digite uma linha de onibus...")
              
          ),
          actions: [
            IconButton(
              icon: const Icon(Icons.menu),
              color: Colors.black, // adicionando a propriedade color
              onPressed: () {
                showHomePageMenu(context);
              },
            ),
          ],
        ),
        body: 
        Stack( 
        children:[ 
          Positioned.fill(
            child:
              SizedBox(
                height: 525,
                width: 600,
                child:mapBuilder(userLocationParam: _userLocation,focusUser: _focusUserLocation,busLocationParam: _busLocation, focusBus: _focusBusLocation, mapController: _mapController, route: _busRoute),
              ),
          ),
          Positioned(
            bottom: 16,
            right: 16,
            child: Column(
              children: [
                if(infoTextBox(_locationRelatedMessage, _locationRelatedMessageCode)!= null)infoTextBox(_locationRelatedMessage, _locationRelatedMessageCode)!,
                if(infoTextBox(_busRelatedMessage, _infoMessageCode)!= null)infoTextBox(_busRelatedMessage, _infoMessageCode)!
              ],
            ) 
          )
        ],),
        bottomNavigationBar: HomePageBottomNavigationBar(
          onLocationIconTapped: () async {
            if(_userLocation.isEmpty) {
              try{
                setState(() {
                  _locationRelatedMessage = 'Obtendo Sua localização';
                  _locationRelatedMessageCode = 0;
                });

                Position newUserLocationNotParsed = await getCurrentLocation();

                List<double> newUserLocation = [newUserLocationNotParsed.latitude, newUserLocationNotParsed.longitude];
                setState(() {
                  _locationRelatedMessage = '';
                  _locationRelatedMessageCode = 0;
                  _focusUserLocation = true;
                  _userLocation = newUserLocation;
                });
              }on Exception catch (e){
                setState(() {
                _locationRelatedMessage = e.toString();
                _locationRelatedMessageCode = -1;
                });
              } 
              
            }else{
              setState(() {
                _focusUserLocation=false;
                _userLocation = [];
              });
            }
        },
        onZoomInIconTapped: (){
          setState(() {
            _focusUserLocation=false;
            _mapController.move(_mapController.camera.center, _mapController.camera.zoom + 1);
          });
        },
        onZoomOutIconTapped: (){
          setState(() {
            _focusUserLocation=false;
            _mapController.move(_mapController.camera.center, _mapController.camera.zoom - 1);
          });
        }
        )
      );
    }
  }

  
}





