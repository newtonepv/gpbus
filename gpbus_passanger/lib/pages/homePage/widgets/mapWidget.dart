import 'package:flutter/material.dart';
import 'package:flutter_map/flutter_map.dart';
import 'package:latlong2/latlong.dart';

class MapWidget extends StatefulWidget {
  const MapWidget({
    super.key, 
    required this.mapController, 
    required this.markers, 
    required this.points,
    this.initialCenter,
    this.initialZoom,
    this.onPositionChanged
  });
  
  final List<Marker> markers;
  final List<LatLng> points;
  final MapController mapController;
  final LatLng? initialCenter;
  final double? initialZoom;
  final Function()? onPositionChanged;
  
  
  static bool mostralot = false;
  
  // Default fallback values
  static const LatLng defaultCenter = LatLng(-23.587489, -46.682300);
  static const double defaultZoom = 15.0;

  @override
  State<MapWidget> createState() => _MapWidgetState();
}

class _MapWidgetState extends State<MapWidget> {
  
  
  @override
  Widget build(BuildContext context) {
    return FlutterMap(
      mapController: widget.mapController,
      options: MapOptions(
        onPositionChanged: (MapCamera camera, bool hasGesture) {
            widget.onPositionChanged?.call();
          },
        onMapEvent: (MapEvent event) {
            // Listen for zoom events specifically
            if (event is MapEventDoubleTapZoom) {
              widget.onPositionChanged?.call();
            }
          },
        initialCenter: widget.initialCenter ?? MapWidget.defaultCenter,
        initialZoom: widget.initialZoom ?? MapWidget.defaultZoom,
      ),
      
      children: [
        TileLayer(
          urlTemplate: 'https://cartodb-basemaps-a.global.ssl.fastly.net/light_all/{z}/{x}/{y}.png',
          tileProvider: NetworkTileProvider(),
        ),
        MarkerLayer(
          markers: widget.markers,
        ),
        if(widget.points.isNotEmpty)
        PolylineLayer(
          polylines: [
            Polyline(
              points: widget.points,
              color: const Color.fromARGB(157, 64, 115, 225),
              strokeWidth: 7,
            ),
          ],
        ),
      ],
    );
  }
}
