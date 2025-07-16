// ignore_for_file: prefer_interpolation_to_compose_strings

import "package:dio/dio.dart";
import 'package:flutter/material.dart';
import 'package:gpbus_passanger/utils/changingPageFunctions.dart';
import 'dart:async';
import 'dart:convert';

import 'package:gpbus_passanger/utils/customExceptions/custom_server_exceptions.dart';

final Dio httpClient = Dio(); 

String host = "https://gpbus-psql-python-rest-api.onrender.com";

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


Future<List<int>> serverLoadBusIds(BuildContext context) async {
  //can return a DioException if its .response.statuscode = 502 the server is full, other exceptions are unexpected
  String path = host+"/busids";
  try{
    var response = await httpClient.get(path);
    return  List<int>.from(json.decode(response.data['ids']));
  }on DioException catch (e){
    handleConnectionError(e,context);
    handleServerFullError(e,context);
    rethrow;
  }
}

Future<List<double>> getBusLocation(CancelToken completer, int busid,BuildContext context) async{ 
  try{
    Response response =  await httpClient.get(host+'/getBusLoc/',
                queryParameters: {
                  'busid': busid.toString(),
                },
                cancelToken: completer
                );
    List<double> returning = [json.decode(response.toString())["latitude"],json.decode(response.toString())["longitude"]];
    return returning;
  }on DioException catch (e){
    handleConnectionError(e,context);
    handleServerFullError(e,context);
    rethrow;
  }
}

Future<List<List<double>>> getBusRoute(CancelToken completer, int busid,BuildContext context) async{ 
  try{
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
  }on DioException catch (e){
    handleConnectionError(e,context);
    handleServerFullError(e,context);
    rethrow;
  }
}

Future<bool> autenticateUser(String userName, String password,BuildContext context) async {
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
    handleConnectionError(e,context);
    handleServerFullError(e,context);
    rethrow;
  }
}

void handle409Exception(DioException e, String msg){
  if(e.response!=null){
    if(e.response!.statusCode==409){
      throw Custom409Exception(msg);
    }
  }
}

Future<void> createUser(String userName, String password,BuildContext context) async {
  String path = host+"/createPassanger/"; 
  try{
    await httpClient.get(path,
      queryParameters: {
        "userName": userName,
        "userPassword":password,
      }
    );
  }on DioException catch (e){
    handleConnectionError(e,context);
    handleServerFullError(e,context);
    handle409Exception(e,"Esse usuário já existe");//this should change DioException to make it more specific in case its a 409 exception
    rethrow;
  }
}

Future<void> makeBus200Moove(BuildContext context) async {
  String path = host+"/makeBus200Moove/"; 
  try{
    await httpClient.get(path);
  }on DioException catch (e){
    handleConnectionError(e,context);
    handleServerFullError(e,context);
    handle409Exception(e, "O ônibus 200 já está se movimentando");//this should change DioException to make it more specific in case its a 409 exception
    rethrow;
  }
}


Future<List<Map<String,dynamic>>> getBusComments(int busId, String userName,BuildContext context) async {
  String path = host+"/getBusComments/"; 
  try{
    var response = await httpClient.get(path,
      queryParameters: {
        "busid":busId
      });
    if(response.toString()!="[]"){
      List<String> commentsListUnparsed=transformStringToArray(response.toString());
      List<Map<String,dynamic>> commentListParsed = [];
      for(int i=0;i<commentsListUnparsed.length;i++){
        commentListParsed.add( await commentDictParse(commentsListUnparsed[i],userName,context)); 
      }

      return commentListParsed;
    }else{
      return [];
    }
  }on DioException catch (e){
    handleConnectionError(e,context);
    handleServerFullError(e,context);//this should change DioException to make it more specific in case its a 502 exception
    rethrow;
  }
}

List<String> transformStringToArray(String input) {
  // Remove os colchetes iniciais e finais
  String trimmed = input.substring(1, input.length - 1);
  
  // Divide a string nos padrões "}, {" para separar os objetos
  List<String> objects = trimmed.split('}, {');
  objects[0]=objects[0].substring(1,objects[0].length);
  objects[objects.length-1]=objects[objects.length-1].substring(0,objects[objects.length-1].length -1);

  // Adiciona os colchetes de volta a cada objeto (exceto o primeiro e último que precisam de tratamento especial)
  return objects;
}

Future<Map<String,dynamic>> commentDictParse(String str, String userName,BuildContext context)async{
  List<String> unParsedBusComment = str.split(', ');
  Map<String,dynamic> commentDict = {};
  commentDict['id']= int.parse(unParsedBusComment[0].split(': ')[1]);
  //lets see if the user liked it
  commentDict['userInteraction']=await getUserInteractionWithCommentAux(userName,commentDict['id'],context);
  commentDict['message']= unParsedBusComment[1].split(': ')[1];
  commentDict['stars']= int.parse(unParsedBusComment[2].split(': ')[1]);
  commentDict['userName']= unParsedBusComment[3].split(': ')[1];
  commentDict['date']= unParsedBusComment[4].split(': ')[1];
  commentDict['likes']= int.parse(unParsedBusComment[5].split(': ')[1]);
  commentDict['disLikes']= int.parse(unParsedBusComment[6].split(': ')[1]);
  return commentDict;
}

Future<int> getUserInteractionWithCommentAux(String userName, int commentId, BuildContext context) async {
  //do not handle connection errors here because this is a aux function
  String path = host+"/checkIfUserLikedComment/"; 
    var response = await httpClient.get(path,
      queryParameters: {
        "commentId":commentId,
        "userName":userName,
      }
    );
    if(json.decode(response.toString())['exists_like']==false){
      //has no opinion
      return 0;
    }
    else if(json.decode(response.toString())['is_dislike']==true){
      //dislike
      return -1;
    }else{
      //like
      return 1; 
    }
}

Future<void> likeComment(String userName, int commentId, int interactionCode, BuildContext context) async {
  String path = host+"/likeComment/"; 
  try{
    await httpClient.get(path,
      queryParameters: {
        'commentId':commentId,
        'userName':userName,
        'interactionCode':interactionCode,
      }
    );
  }on DioException catch (e){
    handleConnectionError(e,context);
    handleServerFullError(e,context);//this should change DioException to make it more specific in case its a 502 exception
    rethrow;
  }
}

Future<void> createComment(int busid, String userName,String password, int stars, String comment, BuildContext context) async {
  String path = host+"/addBusComment/"; 
  try{
    await httpClient.get(path,
      queryParameters: {
        'busid':busid,
        'userName':userName,
        'userPassword':password,
        'comment':comment,
        'stars':stars
      }
    );
  }on DioException catch (e){
    handleConnectionError(e,context);
    handleServerFullError(e,context);//this should change DioException to make it more specific in case its a 502 exception
    rethrow;
  }
}