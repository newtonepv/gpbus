
import 'package:flutter/material.dart';
import 'package:flutter_map/flutter_map.dart';
import 'package:tcc_teste/widgets/mapa.dart';
import 'package:latlong2/latlong.dart';
import 'package:tcc_teste/utils/linhas.dart';
class mapcontroller {

  static Widget desenhapontos(String rota, double latitudeB, double longitudeB, bool mostrarloc, bool focarloc1,  bool focarBus, MapController mapController){ 
  
  dynamic ltDefault = LatLng(-22.56248, -47.42426);
  // ignore: unused_local_variable
  List<Marker> markers = [];
  // ignore: unused_local_variable
  List<LatLng> points = [];
  
    points = linhas.retornaPoints(rota);
     ///markers.removeWhere((marker) =>
        ///marker.builder == (ctx) => Image.asset("assets/home/icons/bus.png"));
    markers=[
      Marker(
            child: Image.asset("assets/home/icons/bus.png"),
            point: LatLng(latitudeB,longitudeB),
            height: 50,
            width: 50,
          ),
        ];
        
      if(mostrarloc==true){ 
          markers=[
      Marker(
            child: Image.asset("assets/home/icons/bus.png"),
            point: LatLng(latitudeB,longitudeB),
            height: 50,
            width: 50,
          ),
          Marker(
                width: 30.0,
                height: 30.0,
                point: LatLng(-22.56218359, -47.42499053), 
                child: Container(
                child: Icon(Icons.location_pin, color: Colors.red),
                ),
                ) 
        
        ];
            
        }
      if(focarBus==true){mapController.move(LatLng(latitudeB,longitudeB), 16);}
      return Mapa(mapController: mapController,ltDefault: ltDefault, markers:markers, points: points,);
    }  
  }