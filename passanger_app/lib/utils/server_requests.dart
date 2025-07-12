// ignore_for_file: prefer_interpolation_to_compose_strings

import "package:dio/dio.dart";
import 'dart:async';
import 'dart:convert';

import 'package:tcc_teste/utils/customExceptions/custom_server_exceptions.dart';

final Dio httpClient = Dio(); 

const String host = "https://gpbus-psql-python-rest-api.onrender.com";

//const String host = "http://0.0.0.0:8000";
Future<List<int>> serverLoadBusIds() async {
  //can return a DioException if its .response.statuscode = 502 the server is full, other exceptions are unexpected
  String url = host+"/busids"; 
  print("running curl '"+url+"'");
  var response = await httpClient.get(host+"/busids");
  return  List<int>.from(json.decode(response.data['ids']));
}

Future<List<double>> getBusLocation(CancelToken completer, int busid) async{ 
  Response response =  await httpClient.get(host+'/getBusLoc/',
              queryParameters: {
                'busid': busid.toString(),
              },
              cancelToken: completer
              );
  List<double> returning = [json.decode(response.toString())["latitude"],json.decode(response.toString())["longitude"]];
  return returning;
}



Future<List<List<double>>> getBusRoute(CancelToken completer, int busid)async{ 
  Response responses =  await httpClient.get(host+'/getBusRoute/',
              queryParameters: {
                'busid': busid.toString(),
              },
              cancelToken: completer
              );

  String routeString = json.decode(responses.toString())["route"];
  List<List<double>> coordinates = [];
  
  //using regex to find all latitude and longitude pairs
  RegExp recordRegex = RegExp(r'<Record latitude=([\d.-]+) longitude=([\d.-]+)>');
  Iterable<RegExpMatch> matches = recordRegex.allMatches(routeString);

  for (RegExpMatch match in matches) {
    double latitude = double.parse(match.group(1)!);
    double longitude = double.parse(match.group(2)!);
    coordinates.add([latitude, longitude]);
  }
  return coordinates;
}

Future<bool> autenticateUser(String userName, String password) async {
  //can return a DioException if its .response.statuscode = 502 the server is full, other exceptions are unexpected
  String path = host+"/authenticatePassanger/"; 
  try{
    var response = await httpClient.get(path,
      queryParameters: {
        "userName": userName,
        "userPassword":password,
      }
    );
    return  bool.parse(json.decode(response.toString())['hasAccess'].toString().toLowerCase());
  }on DioException catch (e){
    throwCustomServerFullException(e);//this should change it to make it more specific in case its a 502 exception
    rethrow;
  }
  
}

void throwCustomServerFullException(DioException e){
  //if "e" parameter is a ServerFullException (502 code in http) this throws a CustomServerFullException 
  if(e.response!=null){
    if(e.response!.statusCode==502){
      throw CustomServerFullException("O servidor está cheio. Tente novamente mais tarde");
    }
  }
}