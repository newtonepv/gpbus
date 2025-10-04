// ignore_for_file: prefer_const_constructors, prefer_final_fields, prefer_interpolation_to_compose_strings
//!Autocomplete

import 'dart:async';
import 'package:dio/dio.dart';
import 'package:flutter/material.dart';
import 'package:flutter_map/flutter_map.dart';
import 'package:geolocator/geolocator.dart';
import 'package:gpbus_passanger/pages/homePage/widgets/busComments.dart';
import 'package:gpbus_passanger/pages/homePage/widgets/mapBuilder.dart';
import 'package:gpbus_passanger/pages/homePage/widgets/loadingPage.dart';
import 'package:gpbus_passanger/pages/homePage/widgets/homeBottomNavigationBar.dart';
import 'package:gpbus_passanger/pages/homePage/widgets/menu.dart';
import 'package:gpbus_passanger/pages/homePage/widgets/moove_bus_200.dart';
import 'package:gpbus_passanger/pages/homePage/widgets/ringingBell.dart';
import 'package:gpbus_passanger/singleton/userInfo.dart';
import 'package:gpbus_passanger/utils/changingPageFunctions.dart';
import 'package:gpbus_passanger/utils/customExceptions/custom_location_exceptions.dart';
import 'package:gpbus_passanger/utils/customExceptions/custom_server_exceptions.dart';
import 'package:gpbus_passanger/utils/locationServices.dart';
import 'package:gpbus_passanger/utils/alarm.dart';
import 'package:gpbus_passanger/utils/server_requests.dart';
import 'package:gpbus_passanger/widgets/busSearchBar.dart';
import 'package:gpbus_passanger/widgets/infoTextBox.dart';
import 'package:latlong2/latlong.dart';



class HomePage extends StatefulWidget {
  final UserInfo userInfo;
  const HomePage({super.key, required this.userInfo});
  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  late UserInfo _userInfo;

  MapController _mapController = MapController();
  SearchController _searchController = SearchController();

  List<double> _userLocation =[];
  List<double> _busLocation =[];
  List<List<double>> _busRoute = [];
  CancelToken _mapUpdateCT = CancelToken();
  CancelToken _loadAlarmsCT = CancelToken();
  CancelToken _checkAlarmLoopCT = CancelToken();
  //whenever i make a update about the map, i want to set this both to false
  bool _focusBusLocation = false;
  bool _focusUserLocation = false;
  late bool _isFirstTimeLoadingMapWithThisBus;

  String _busRelatedMessage='';
  int _infoMessageCode=0;
  String _locationRelatedMessage= '';
  int _locationRelatedMessageCode=0;
  bool _showCommentsWidget = false;
  int _busId = -1;

  final Duration _mapUpdateDelay = Duration(milliseconds: 250);
  Timer? _mapUpdateLoop;
  final Duration _alarmCheckDelay = Duration(milliseconds: 250);
  
  List<RingingBellWidget> _playingAlarms = [];
  double _bellSize = 100;
  @override
  void initState() {
    super.initState();
    _userInfo = widget.userInfo;
    _loadBusIds();
    _loadAlarms();

  }

  @override
  void dispose() {
    _searchController.dispose();
    _mapUpdateLoop?.cancel(); // Stop getting the bus locaiton
    _mapUpdateCT.cancel("Canceled Request");
    _loadAlarmsCT.cancel("Navigated");
    _checkAlarmLoopCT.cancel("disposed");
    _mapController.dispose();
    super.dispose();
  }

  void _loadAlarms() async {
    try{
      List<Alarm> alarms = await getAlarms(context, _userInfo.name,_loadAlarmsCT);
      setState(() {
        _userInfo.alarms=alarms;
      });
    }on CustomNavigatedToLoginPageException{
      //do nothing if it navigated to another page
    }on DioException catch (e){
      if(e.type==DioExceptionType.cancel){
        //if the request is canceled, nothing happens
      }else{
        rethrow;
      }
    }
    _alarmCheckLoop();
  }

  void _alarmCheckLoop() async {
    while (!_checkAlarmLoopCT.isCancelled) {//this will break the loop
      await _checkAlarms(_checkAlarmLoopCT);
      await Future.delayed(_alarmCheckDelay);
    }
  }

  Future<void> _checkAlarms(CancelToken ct) async {

    try{
      for(Alarm a in _userInfo.alarms!){
        List<double> busLocation = await getBusLocation(context, ct, a.busId);
        //print(a.alarmId);
        //print("----");
        try{
          if(a.shouldActivate(LatLng(busLocation[0],busLocation[1]), _mapController.camera)){
            if(a.state == AlarmState.ready){
              _playAlarm(a);
            }
          }
          else{
            // if the bus is not in the range, this means the next time it enters the range, the alarm should play
            a.state=AlarmState.ready;
          }
        } on Exception catch (e) {
          if(e.toString() == "You need to have the FlutterMap widget rendered at least once before using the MapController."){
            continue;//do not check for alarms if the mapcontroller is not initialized
          }
          rethrow;
        }
      }
    }on DioException catch (e){
      if(e.type==DioExceptionType.cancel){
        //if the request is canceled, nothing happens
      }else{
        rethrow;
      }
    }on CustomNavigatedToLoginPageException{
      //do nothing as well
    }
  }
  
  void _playAlarm(Alarm a){
    a.state = AlarmState.played;
    setState(() {
      if(_getAlarmWidget(a.alarmId)==-1){
        setState(() {
          _playingAlarms.add(
          RingingBellWidget(
            text: "Alarme ativado para o ônibus: ${a.busId}",
            size:_bellSize,
            busId: a.busId,
            alarmId: a.alarmId,
            onDeactivated: (int alarmId){
              setState(() {
                _playingAlarms.removeAt(_getAlarmWidget(a.alarmId));
              });
            },
        ));
        });
      }
    });
  }
  
  int _getAlarmWidget(int id){
    for(int i=0; i<_playingAlarms.length; i++){
      RingingBellWidget w = _playingAlarms[i];
      if(w.alarmId == id){
        return i;
      }
    }
    return -1;
  }

  Future<void> _loadBusIds() async {
    try{
      final List<int> newbusIds=await serverLoadBusIds(context);
      setState(() {
        _userInfo.busIds=newbusIds;
      });
    }on CustomNavigatedToLoginPageException{
      //do nothing if it navigated to another page
    }on DioException catch (e){
      if(e.type==DioExceptionType.cancel){
        //if the request is canceled, nothing happens
      }else{
        rethrow;
      }
    }
  }


  void _startMapUpdateLoop() async {
    _mapUpdateLoop?.cancel(); // Cancelar o temporizador existente
    _mapUpdateCT.cancel("Canceled Request"); // cancelar updt do mapa
    _mapUpdateCT = CancelToken();
    _isFirstTimeLoadingMapWithThisBus=true;

    setState(() {
      _busRelatedMessage = "Obtendo ônibus do servidor";
      _infoMessageCode=0;
      
    });

    List<List<double>>? route = await updateRoute();
    if(route==null){return;}//this means that navigated or canceled request 
    setState(() {
      _busRoute=route;
    });
    _mapUpdateLoop = Timer.periodic(_mapUpdateDelay,updateMap);
  }

  Future<List<List<double>>?> updateRoute() async {
    try{
      List<List<double>> newBusRoute = await getBusRoute(context, _mapUpdateCT, _busId);
      return newBusRoute;      
    }on DioException catch (e){
      if(e.type==DioExceptionType.cancel){
        //if the request is canceled, nothing happens
      }else{
        rethrow;
      }
    }on CustomNavigatedToLoginPageException{
      //do nothing as well 
    }
    return null;
  }

  void updateMap (timer) async {
    try{
      List<double> newBusLocation = await getBusLocation(context, _mapUpdateCT, _busId);
      
      setState(() {
        if(_busRelatedMessage.isNotEmpty){
          _busRelatedMessage="";
        }
        _busLocation = newBusLocation;
        _focusUserLocation = false;
        _focusBusLocation = _isFirstTimeLoadingMapWithThisBus;
      });
      _isFirstTimeLoadingMapWithThisBus=false;
      
    }on DioException catch (e){
      if(e.type==DioExceptionType.cancel){
        //if the request is canceled, nothing happens
      }else{
        rethrow;
      }
    }on CustomNavigatedToLoginPageException{
      //do nothing as well
    }
  }

  
  

  @override
  Widget build(BuildContext context) {
    // Desabilita a funcionalidade de voltar à tela anterior
    if(_userInfo.busIds==null||_userInfo.busIds==null){
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
              busIds: _userInfo.busIds!,
              onBusSelected: (int busIdSelected){
                setState(() {
                  _busId=busIdSelected;// has to reaload the bus comments
                });
                _startMapUpdateLoop();
              },
              hintText: "digite uma linha de onibus...")
              
          ),
          actions: [
            IconButton(
              icon: const Icon(Icons.menu),
              color: Colors.black, // adicionando a propriedade color
              onPressed: () {
                showHomePageMenu(context,_userInfo);
              },
            ),
          ],
        ),
        body: Stack( 
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
                mainAxisAlignment: MainAxisAlignment.end,
                children: [
                  if(infoTextBoxBuilder(_locationRelatedMessage, _locationRelatedMessageCode)!= null)infoTextBoxBuilder(_locationRelatedMessage, _locationRelatedMessageCode)!,
                  if(infoTextBoxBuilder(_busRelatedMessage, _infoMessageCode)!= null)infoTextBoxBuilder(_busRelatedMessage, _infoMessageCode)!,
                  MoveBus200Button(),
                ],
              ) 
            ),
            if(_busLocation.isNotEmpty) 
              Positioned(
                bottom: 16,
                left: 16,
                child: Container(
                  width: 48,
                  height: 48,
                  decoration: BoxDecoration(
                    color: const Color.fromARGB(255, 247, 180, 80),
                    borderRadius: BorderRadius.circular(8),
                  ),
                  child: IconButton(
                    icon: Icon(Icons.comment, color: Colors.black),
                    onPressed: () {
                      setState(() {
                        _showCommentsWidget=true;
                      });
                    },
                  ),
                ),
              ),
            if (_showCommentsWidget)
            Comments(
              onCloseWidgetPressed: () {
                setState(() {
                  _showCommentsWidget = false;
                });
              },
              busId: _busId,
              userInfo: _userInfo
            ),
            Positioned(
              top: 16,
              right: 16,
              child: Container(
                height: _bellSize*2, // Set maximum height
                child: SingleChildScrollView(
                  child: Column(
                    spacing: 16,
                    children: _playingAlarms,
                  ),
                ),
              )
            )
          ],
        ),
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
              }on CustomLocationPermissionDeniedException catch (e){
                setState(() {
                _locationRelatedMessage = e.toString();
                _locationRelatedMessageCode = -1;
                });
              }on CustomLocationServiceDisabledException catch (e){
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


