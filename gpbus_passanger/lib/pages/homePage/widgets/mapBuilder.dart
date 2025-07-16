
import 'package:flutter/material.dart';
import 'package:flutter_map/flutter_map.dart';
import 'package:gpbus_passanger/pages/homePage/widgets/mapWidget.dart';
import 'package:latlong2/latlong.dart';

Widget mapBuilder({List<List<double>>? route, List<double>? busLocationParam, bool focusBus=false, List<double>? userLocationParam, bool focusUser=false, required MapController mapController}){ 
  List<double> busLocation = [];
  List<double> userLocation = [];
  List<LatLng> points = [];
  if (busLocationParam!=null){  // se for nulo ou for [], o valor de userLocation_p = []
    busLocation = busLocationParam;
  }
  if (userLocationParam!=null){ // se for nulo ou for [], o valor de userLocation_p = []
    userLocation = userLocationParam;
  }
  if(route!=null){
    points = route.map((p) => LatLng(p[0], p[1])).toList();
  }

  List<Marker> markers = [];
  /*if(route != null){
    points = linhas.getRoute(route!);
  }*/
  if(busLocation.isNotEmpty){
    markers.add(
      Marker(
        child: const Icon(
        Icons.directions_bus,
        color: Colors.orange,
        size: 50,
      ),
      point: LatLng(busLocation[0], busLocation[1]),
      height: 50,
      width: 50,
    ),
    );
  }
  
  if(userLocation.isNotEmpty){ 
    markers.add(
      Marker(
        width: 30.0,
        height: 30.0,
        //DEBUG
        point: LatLng(userLocation[0], userLocation[1]), 
        child: Container(
          child: const Icon(Icons.location_pin, color: Colors.red),
        ),
      ) 
    );  
  }

  if(focusUser==true&&userLocation.isNotEmpty){
    mapController.move(LatLng(userLocation[0],userLocation[1]), 16);
  }
  if(focusBus==true&&busLocation.isNotEmpty){
    mapController.move(LatLng(busLocation[0],busLocation[1]), 16);
  }
  return MapWidget(mapController: mapController, markers:markers, points: points);
  }
