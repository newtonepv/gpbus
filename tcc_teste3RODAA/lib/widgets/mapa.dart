import 'package:flutter/material.dart';
import 'package:flutter_map/flutter_map.dart';
import 'package:latlong2/latlong.dart';

class Mapa extends StatefulWidget {
  

  Mapa({required this.mapController, required this.ltDefault, required this.markers, required this.points});
  final List<Marker> markers;
  final dynamic ltDefault;
  final List<LatLng> points;
  final MapController mapController;
  static bool mostralot = false;
  
  @override
  State<Mapa> createState() => _MapaState();
  
}

class _MapaState extends State<Mapa> {
@override
void initState() {
  super.initState();
  // Inicializações adicionais aqui
}
  @override
  Widget build(BuildContext context) {
    return FlutterMap(
              mapController: widget.mapController,
              options: MapOptions( // centro do mapa
                initialZoom: 15.0,
                initialCenter: widget.ltDefault, // nível de zoom inicial
              ),
              children: [
                TileLayer(
                  urlTemplate: 'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png',
                  subdomains: const ['a', 'b', 'c'], // subdomínios do servidor de mapas
                  
                ),
                MarkerLayer(
                  markers: widget.markers,
                  
                ),
                PolylineLayer(
                  polylines:[
                    Polyline(
                      points: widget.points,
                      color: Color.fromARGB(157, 64, 115, 225),
                      strokeWidth: 7,
                    ),
                  ]
                )
              ],
            );
  }
}