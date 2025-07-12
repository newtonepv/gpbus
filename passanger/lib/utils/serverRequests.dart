import "package:dio/dio.dart";
import 'dart:async';
import 'dart:convert';

final Dio http_client = Dio(); 
final String host = "https://gpbus-psql-python-rest-api.onrender.com";

Future<List<int>> serverLoadBusIds() async {
  //can return a DioException if its .response.statuscode = 502 the server is full, other exceptions are unexpected
  String url = host+"/busids"; 
  print("running curl '"+url+"'");
  var response = await http_client.get(host+"/busids");
  return  List<int>.from(json.decode(response.data['ids']));
}
Future<List<double>> getBusLocation(CancelToken completer, int busid) async{ 
  Response response =  await http_client.get(host+'/getBusLoc/',
              queryParameters: {
                'busid': busid.toString(),
              },
              cancelToken: completer
              );
  List<double> returning = [json.decode(response.toString())["latitude"],json.decode(response.toString())["longitude"]];
  return returning;
}

Future<List<List<double>>> getBusRoute(CancelToken completer, int busid)async{ 
  Response responses =  await http_client.get(host+'/getBusRoute/',
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