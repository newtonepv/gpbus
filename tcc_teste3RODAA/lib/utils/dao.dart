 import 'package:mysql1/mysql1.dart';
              class dao{

                static Future<List<double>> trazerlatlong(code) async {
                  List<double> latLong = [];
                final settings = ConnectionSettings(
                    host: '143.106.241.3',
                    port: 3306,
                    user: 'cl201273',
                    password: 'MarcosLeonardo18',
                    db: 'cl201273',
                  );

                  final connection = await MySqlConnection.connect(settings);

                  final results = await connection.query(
                    "SELECT latitude, longitude  FROM cl201273.TCC_Linha WHERE (`CodigoLINHA` = '$code');",
                  );

                  if (results.isNotEmpty) {
                    final row = results.first.fields;
                    double latitude = double.parse(row['latitude'].toString());
                    double longitude = double.parse(row['longitude'].toString());
                    latLong = [latitude, longitude];
                    await connection.close();
                    return latLong;
                    
                  } else {
                    latLong = [22,44];
                    await connection.close();
                    return latLong;
                  }
                }


              }