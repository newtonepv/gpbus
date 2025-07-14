import 'package:flutter/material.dart';
import 'package:flutter_map/flutter_map.dart';
import 'package:latlong2/latlong.dart';
import 'package:flutter_map_cancellable_tile_provider/flutter_map_cancellable_tile_provider.dart';



class MapWidget extends StatefulWidget {
  

  const MapWidget({super.key, required this.mapController, required this.markers, required this.points});
  final List<Marker> markers;
  final List<LatLng> points;
  final MapController mapController;
  static bool mostralot = false;
  
  static const MapOptions mapHardCodedInitialValue = MapOptions( 
    // centro do mapa e zoom inicial
    initialZoom: 15.0,
    initialCenter: LatLng(-23.587489, -46.682300), 
  );

  @override
  State<MapWidget> createState() => _MapWidgetState();
  
}

class _MapWidgetState extends State<MapWidget> {
  
@override
void initState() {
  super.initState();
  // Inicializações adicionais aqui
}
  @override
  Widget build(BuildContext context) {
    return FlutterMap(
      mapController: widget.mapController,

      options: MapWidget.mapHardCodedInitialValue,

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