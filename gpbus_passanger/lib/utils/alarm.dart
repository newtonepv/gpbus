import 'dart:math';

import 'package:flutter/material.dart';
import 'package:flutter_map/flutter_map.dart';
import 'package:latlong2/latlong.dart';
enum AlarmState {
  ready,
  played,
}
class Alarm{
  int alarmId;
  String userName;
  int busId;
  TimeOfDay startTime;
  TimeOfDay endTime;
  double cLatitude;
  double cLongitude;
  double radius;
  AlarmState state;
  Alarm(this.alarmId,this.userName,this.busId,this.startTime,this.endTime,this.cLatitude,this.cLongitude,this.radius, {this.state = AlarmState.ready});

  bool isTimeInRange(TimeOfDay target) {
      int targetMinutes = target.hour * 60 + target.minute;
      int startMinutes = startTime.hour * 60 + startTime.minute;
      int endMinutes = endTime.hour * 60 + endTime.minute;
      //print(" isTimeInRange ${targetMinutes >= startMinutes && targetMinutes <= endMinutes}");
      return targetMinutes >= startMinutes && targetMinutes <= endMinutes;
    }
  bool isMarkerInsideCircle(LatLng markerPosition, MapCamera mapCamera) {
    Offset markerPixels = mapCamera.latLngToScreenOffset(markerPosition);
    Offset centerPixels = mapCamera.latLngToScreenOffset(LatLng(cLatitude, cLongitude));
    
    double distance = sqrt(
      pow(markerPixels.dx - centerPixels.dx, 2) + 
      pow(markerPixels.dy - centerPixels.dy, 2)
    );
    //print(" isMarkerInsideCircle ${distance <= radius}");
    return distance <= radius;
  }
  bool shouldActivate(LatLng markerPosition, MapCamera mapCamera){
    return (isTimeInRange(TimeOfDay.now()) && isMarkerInsideCircle(markerPosition,mapCamera));
  }

}
