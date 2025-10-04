// ignore_for_file: prefer_const_constructors, prefer_final_fields, prefer_interpolation_to_compose_strings
//!Autocomplete
import 'dart:math';

import 'package:flutter/material.dart';
import 'package:flutter_map/flutter_map.dart';
import 'package:gpbus_passanger/pages/alarmPage/widgets/radiusControlWidget.dart';
import 'package:gpbus_passanger/pages/homePage/widgets/mapBuilder.dart';
class AlarmMapPage extends StatefulWidget {
  final List<double>  busLocation;
  final List<List<double>> busRoute;
  AlarmMapPage({super.key, required this.busRoute, required this.busLocation});
  @override
  _AlarmMapPageState createState() => _AlarmMapPageState();
}

class _AlarmMapPageState extends State<AlarmMapPage> {
  MapController _mapController = MapController();
  //whenever i make a update about the map, i want to set this false
  bool _focusBusLocation = true;
  double _actualZoom=16;

  //for the circle radius
  double _radius = 50;

  @override
  void setState(VoidCallback fn) {
    super.setState(() {
      _focusBusLocation = false;
      fn();
    });
  }

  @override
  void dispose() {
    _mapController.dispose();
    super.dispose();
  }


  double calculateRadiusForZoom(double baseRadius, double currentZoom) {
    return baseRadius * pow(2, currentZoom - 16);
  }

  void onPositionChanged(){
    setState(() {
      _actualZoom=_mapController.camera.zoom;
    });
  }
  
  @override
  Widget build(BuildContext context) {
    
    return Scaffold(
      body: Stack( 
        children:[ 
          Positioned.fill(
            child:SizedBox(
              height: 525,
              width: 600,
              child:
              MapBuilderForAlarms(
                widget.busRoute,
                widget.busLocation,
                _focusBusLocation,
                onPositionChanged,
                calculateRadiusForZoom(_radius,_actualZoom),
                _mapController
              ),
            ),
          ),
          Positioned(
            bottom: 16,
            right: 16,
            child: Column(
              spacing: 16,
              mainAxisSize: MainAxisSize.min,
              children: [
                _buildRadiusControls(),
                _buildZoomControls(),
                _buildConfirmButton(),
              ],
            ),
          )
        ],
      ),
    );
  }
  Widget _buildConfirmButton() {
    return Container(
      width: 48,
      height: 48,
      decoration: BoxDecoration(
        border: Border.all(color: Colors.green, width: 2),
        color: const Color.fromARGB(255, 255, 255, 255),
        borderRadius: BorderRadius.circular(8),
      ),
      child: IconButton(
        icon: Icon(Icons.check, color: Colors.black),
        onPressed: () {
          Navigator.pop(context, [_radius, _mapController.camera.center]);
        },
      ),
    );
  }


  
  Widget _buildRadiusControls() {
  return RadiusControlWidget(
    start_radius: _radius,
    setRadius:(double radius){
      setState(() {
        _radius = radius;
      });
    });
  }

  Widget _buildZoomControls() {
    return Row(
      mainAxisSize: MainAxisSize.min,
      children: [
        Container(
          width: 48,
          height: 48,
          decoration: BoxDecoration(
            color: const Color.fromARGB(255, 247, 180, 80),
            borderRadius: BorderRadius.circular(8),
          ),
          child: IconButton(
            icon: Icon(Icons.zoom_in, color: Colors.black),
            onPressed: () {
              _mapController.move(_mapController.camera.center, _mapController.camera.zoom + 1);
            },
          ),
        ),
        SizedBox(width: 16),
        Container(
          width: 48,
          height: 48,
          decoration: BoxDecoration(
            color: const Color.fromARGB(255, 247, 180, 80),
            borderRadius: BorderRadius.circular(8),
          ),
          child: IconButton(
            icon: Icon(Icons.zoom_out, color: Colors.black),
            onPressed: () {
              _mapController.move(_mapController.camera.center, _mapController.camera.zoom - 1);
            },
          ),
        ),
      ],
    );
  }
}

