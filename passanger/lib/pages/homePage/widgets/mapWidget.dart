import 'package:flutter/material.dart';
import 'package:flutter_map/flutter_map.dart';
import 'package:latlong2/latlong.dart';
import 'package:flutter_map_cancellable_tile_provider/flutter_map_cancellable_tile_provider.dart';
class Map extends StatefulWidget {
  

  const Map({super.key, required this.mapController, required this.markers, required this.points});
  final List<Marker> markers;
  final List<LatLng> points;
  final MapController mapController;
  static bool mostralot = false;
  
  @override
  State<Map> createState() => _MapState();
  
}

class _MapState extends State<Map> {
@override
void initState() {
  super.initState();
  // Inicializações adicionais aqui
}
  @override
  Widget build(BuildContext context) {
    return FlutterMap(
      mapController: widget.mapController,

      options: const MapOptions( // centro do mapa
        initialZoom: 15.0,
        initialCenter: LatLng(2, 2), // nível de zoom inicial
      ),

      children: [
        
        TileLayer(
          urlTemplate: 'https://tile.openstreetmap.org/{z}/{x}/{y}.png',
          tileProvider: CancellableNetworkTileProvider(),
        ),

        MarkerLayer(
          markers: widget.markers,
          
        ),

        PolylineLayer(
          polylines:[
            Polyline(
              points: widget.points,
              color: const Color.fromARGB(157, 64, 115, 225),
              strokeWidth: 7,
            ),
          ]
        )
      ],
    );
  }
}