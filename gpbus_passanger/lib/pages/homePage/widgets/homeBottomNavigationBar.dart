
import 'package:flutter/material.dart';

class HomePageBottomNavigationBar extends StatelessWidget{
  final void Function() onLocationIconTapped;
  final void Function() onZoomInIconTapped;
  final void Function() onZoomOutIconTapped;
  const HomePageBottomNavigationBar({super.key, required this.onLocationIconTapped, required this.onZoomInIconTapped, required this.onZoomOutIconTapped});

  @override
  Widget build(BuildContext context) {
    return BottomAppBar(
      height: 50,
      padding: EdgeInsets.all(10),
      color: const Color(0xFFffc966),
      child: LayoutBuilder(
        builder: (context, constraints) {
          // Calculate icon size based on available width
          double iconSize = (constraints.maxWidth / 7).clamp(20.0, 40.0);

          return Row(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: [
              InkWell(
                onTap: onLocationIconTapped,
                child: Icon(
                  Icons.location_on_rounded,
                  size: iconSize,
                  color: Colors.black,
                ),
              ),
              InkWell(
                onTap: onZoomInIconTapped,
                child: Icon(
                  Icons.zoom_in_rounded,
                  size: iconSize,
                  color: Colors.black,
                ),
              ),
              InkWell(
                onTap: onZoomOutIconTapped,
                child: Icon(
                  Icons.zoom_out_rounded,
                  size: iconSize,
                  color: Colors.black,
                ),
              ),
            ],
          );
        },
      ),
    );
  }
}