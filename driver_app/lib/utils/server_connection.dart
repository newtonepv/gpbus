import 'dart:convert';

import 'package:dio/dio.dart';
import 'package:flutter/material.dart';
import 'package:pegaloc/customExceptions/custom_server_exceptions.dart';
import 'package:pegaloc/main.dart';

String host = "https://gpbus-psql-python-rest-api.onrender.com";


Dio httpClient = Dio();
void handleConnectionError(DioException e, BuildContext context){
  if(e.type==DioExceptionType.connectionError){
    loadLoginPage(context: context,errorMsg: "Não há conexão com o Servidor, tente novamente mais tarde");
    throw CustomNavigatedToLoginPageException("");
  }
}
void handleServerFullError(DioException e, BuildContext context){
  if(e.response!=null){
    if(e.response!.statusCode==502){
      loadLoginPage(context: context,errorMsg:"O servidor está cheio. Tente novamente mais tarde");
      throw CustomNavigatedToLoginPageException("");
    }
  }
}
void loadLoginPage({required BuildContext context, String errorMsg=""}){
    Navigator.pushReplacement(
      context, 
      MaterialPageRoute(builder: (context) => FormContainer(errorMsg: errorMsg,))
    );
  }

Future<List<int>> getBusIds(BuildContext context)async{
  try{
    final response = await httpClient.get(host+'/busids');
    return List<int>.from(json.decode(response.data['ids']));
  }on DioException catch (e){
    handleConnectionError(e, context);
    handleServerFullError(e, context);
    rethrow;
  }
}

Future<void> updateBusLocApiRequest(CancelToken locationUpdateCompleter, int busid, double newLatitude, double newLongitude, int driverId, String driverPassword, BuildContext context) async{ 
  try{
    await httpClient.get(host+'/udtBusLoc/',
      queryParameters: {
        'busid': busid.toString(),
        'latitude': newLatitude.toString(),
        'longitude': newLongitude.toString(),
        'idDriver': driverId.toString(),
        'driverPassword': driverPassword.toString()
      },
      cancelToken: locationUpdateCompleter
    );
  }on DioException catch (e){
    handleConnectionError(e, context);
    handleServerFullError(e, context);
    rethrow;
  }
}