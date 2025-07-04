import 'dart:async';

import 'package:flutter/material.dart';
import 'package:mysql1/mysql1.dart';
import 'package:geolocator/geolocator.dart';


void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'MySQL Update Example',
      home: MyHomePage(),
    );
  }
}

class MyHomePage extends StatefulWidget {
  @override
  _MyHomePageState createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  final String host = '143.106.241.3';
  final int port = 3306;
  final String user = 'cl201273';
  final String password = 'MarcosLeonardo18';
  final String db = 'cl201273';
  Timer? _timer; // Usado para controlar o intervalo de atualização

  Future<void> updateLinha(int codigoLinha, double newLatitude, double newLongitude) async {
    final settings = ConnectionSettings(
      host: host,
      port: port,
      user: user,
      password: password,
      db: db,
    );

    final connection = await MySqlConnection.connect(settings);

    try {
      await connection.query(
        'UPDATE `cl201273`.`TCC_Linha` SET `latitude` = ?, `longitude` = ? WHERE `CodigoLINHA` = ?',
        [newLatitude, newLongitude, codigoLinha]
      );

      print('Linha atualizada com sucesso.');
    } catch (e) {
      print('Erro ao atualizar linha: $e');
    } finally {
      await connection.close();
    }
  }

  Future<Position> getCurrentLocation() async {
    Position position = await Geolocator.getCurrentPosition(
        desiredAccuracy: LocationAccuracy.high);
    return position;
  }

  void startUpdatingLinha(int cdgl) {
    _timer = Timer.periodic(Duration(seconds: 1), (timer) async {
      Position currentPosition = await getCurrentLocation();
      double newLatitude = currentPosition.latitude;
      double newLongitude = currentPosition.longitude;
      await updateLinha(cdgl, newLatitude, newLongitude);
      setState(() {
                    
                  atu = true;
                  });
    });
  }

  void stopUpdatingLinha() {
    _timer?.cancel();
    _timer = null;
    setState(() {
                    
                  atu = false;
                  });
  }
  bool atu=false;
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('MySQL Update Example'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            
            SizedBox(height: 20),
            ElevatedButton(
              onPressed: () {
                  startUpdatingLinha(2022);
                  
              },
              child: Text('Iniciar Atualização "$_timer"'),
              style: ButtonStyle(
                backgroundColor: atu ? MaterialStateProperty.all<Color>(Colors.red) : MaterialStateProperty.all<Color>(Colors.blue),
              ),
            ),
            ElevatedButton(
              onPressed: () {
                  stopUpdatingLinha();
                  
              },
              child: Text('Parar Atualização"$_timer"'),
              style: ButtonStyle(
                backgroundColor: atu ? MaterialStateProperty.all<Color>(Colors.blue) : MaterialStateProperty.all<Color>(Colors.red),
              ),
              )
            
          ],
        ),
      ),
    );
  }
}
