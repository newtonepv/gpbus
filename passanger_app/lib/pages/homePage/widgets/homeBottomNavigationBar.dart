
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
          color: const Color(0xFFffc966),
          child: Row(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: [
              InkWell(
                onTap: () {
                  onLocationIconTapped();
                },
                child: Image.asset(
                  'assets/home/icons/location.png',
                  height: 24,
                  width: 24,
                ),
              ),
              InkWell(
                onTap: () {},
                child: Image.asset(
                  'assets/home/icons/busStop.png',
                  height: 24,
                  width: 24,
                ),
              ),           
              InkWell(
                onTap: () {},
                child: Image.asset(
                  'assets/home/icons/clock.png',
                  height: 24,
                  width: 24,
                ),
              ), 
              InkWell(
                onTap: () {
                  onZoomInIconTapped();
                },
                child: Icon(
                  Icons.zoom_in_rounded,
                  size: 27,
                ),
              ),    
              InkWell(
                onTap: () {
                  onZoomOutIconTapped();
                },
                child: Icon(
                  Icons.zoom_out_rounded,
                  size: 27,
                ),
              ), 
            ],
          ),
        );
  }
}
