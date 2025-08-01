// ignore_for_file: prefer_const_constructors, prefer_final_fields, prefer_interpolation_to_compose_strings
//!Autocomplete

import 'dart:async';
import 'package:dio/dio.dart';
import 'package:flutter/material.dart';
import 'package:flutter_map/flutter_map.dart';
import 'package:geolocator/geolocator.dart';
import 'package:gpbus_passanger/pages/homePage/widgets/bus_comments.dart';
import 'package:gpbus_passanger/pages/homePage/widgets/mapBuilder.dart';
import 'package:gpbus_passanger/pages/homePage/widgets/loadingPage.dart';
import 'package:gpbus_passanger/pages/homePage/widgets/homeBottomNavigationBar.dart';
import 'package:gpbus_passanger/pages/homePage/widgets/menu.dart';
import 'package:gpbus_passanger/pages/homePage/widgets/moove_bus_200.dart';
import 'package:gpbus_passanger/utils/changingPageFunctions.dart';
import 'package:gpbus_passanger/utils/customExceptions/custom_location_exceptions.dart';
import 'package:gpbus_passanger/utils/customExceptions/custom_server_exceptions.dart';
import 'package:gpbus_passanger/utils/locationServices.dart';
import 'package:gpbus_passanger/utils/server_requests.dart';
import 'package:gpbus_passanger/pages/homePage/widgets/busSearchBar.dart';
import 'package:gpbus_passanger/widgets/infoTextBox.dart';


class HomePage extends StatefulWidget {
  final String userName;
  final String password;
  const HomePage({super.key, required this.userName, required this.password});
  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  late String _userName;
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
  bool _focusUserLocation = false;

  String _busRelatedMessage='';
  int _infoMessageCode=0;
  String _locationRelatedMessage= '';
  int _locationRelatedMessageCode=0;
  bool _showCenterWidget = false;
  int _busId = -1;
  
  @override
  void dispose() {
    _searchController.dispose();
    _timer?.cancel(); // Stop getting the bus locaiton
    _busLocationLoadCancelToken.cancel("Canceled Request");
    _mapController.dispose();
    super.dispose();
  }
  @override
  void initState() {
    super.initState();
    _userName=widget.userName;
    _loadBusIds();
  }


  void _startGettingBusCoordinates(int busid) async {
    _timer?.cancel(); // Cancelar o temporizador existente
    _busLocationLoadCancelToken.cancel("Canceled Request");
    _busLocationLoadCancelToken = CancelToken();

    bool isFirstTimeLoadingMapWithThisBus=true;//used to focus the bus only in the first map update
    setState(() {
      _busRelatedMessage = "Obtendo ônibus do servidor";
      _infoMessageCode=0;
    });
    //tem que cancelar a request
    const interval = Duration(seconds: 1);
    _timer = Timer.periodic(interval, (timer) async {
      try{
        List<double> newBusLocation = await getBusLocation(_busLocationLoadCancelToken, busid,context);
        List<List<double>> newBusRoute = await getBusRoute(_busLocationLoadCancelToken, busid,context);
        
        setState(() {
          if(_busRelatedMessage.isNotEmpty){
            _busRelatedMessage="";
          }
          _busRoute = newBusRoute;
          _busLocation = newBusLocation;
          _focusUserLocation = false;
          _focusBusLocation = isFirstTimeLoadingMapWithThisBus;
        });
        isFirstTimeLoadingMapWithThisBus=false;
        
      }on DioException catch (e){
        //handle full server
        if(e.type==DioExceptionType.cancel){
          //if the request is canceled, nothing happens
        }else{
          rethrow;
        }
      }on CustomNavigatedToLoginPageException{
        //do nothing as well
      }
    });
  }


  Future<void> _loadBusIds() async {
    try{
      final List<int> newbusIds=await serverLoadBusIds(context);
      setState(() {
        _busIds=newbusIds;
      });
    }on CustomNavigatedToLoginPageException{
      //do nothing if it navigated to another page
    }
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
                setState(() {
                  _busId=busIdSelected;
                });
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
                        _showCenterWidget=true;
                      });
                    },
                  ),
                ),
              ),
            if (_showCenterWidget)
            Comments(
              onCloseWidgetPressed: () {
                setState(() {
                  _showCenterWidget = false;
                });
              },
              busId: _busId,
              userName: _userName,
              password: widget.password,
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


