
// ignore_for_file: prefer_conditional_assignment

import 'package:gpbus_passanger/utils/alarm.dart';

class UserInfo{

  static UserInfo? _instance;

  late String name;
  late String password;
  List<int>? busIds;
  List<Alarm>? alarms;

  //construtor privado
  UserInfo._privateConstructor(this.name, this.password);

  factory UserInfo({required String name, required String password}){
    
    if(_instance==null){
      _instance = UserInfo._privateConstructor(name, password);
    }
    return _instance!;
  }
}