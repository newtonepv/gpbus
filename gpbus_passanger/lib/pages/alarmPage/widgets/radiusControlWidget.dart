import 'dart:async';

import 'package:flutter/material.dart';

class RadiusControlWidget extends StatefulWidget {
  final double start_radius;
  final Function(double) setRadius;
  RadiusControlWidget({required this.start_radius,required this.setRadius});
  @override
  _RadiusControlWidgetState createState() => _RadiusControlWidgetState();
}

class _RadiusControlWidgetState extends State<RadiusControlWidget> {
  late double _radius;

  @override 
  void initState(){
    super.initState();
    _radius = widget.start_radius;
  }

  double _velocity = 0;
  double _acceleration = 0;
  Timer? _timer;

  void _startChangingRadius(double acceleration) {
    _acceleration = acceleration;
    _velocity = 0;
    _timer = Timer.periodic(Duration(milliseconds: 16), (timer) {
      setState(() {
        _velocity += _acceleration;
        _radius += _velocity * 0.016; // 0.016 ≈ 16ms/frame
        if (_radius < 0) _radius = 0;
        widget.setRadius(_radius);
      });
    });
  }

  void _stopChangingRadius() {
    _timer?.cancel();
    _timer = null;
    _velocity = 0;
    _acceleration = 0;
  }

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisSize: MainAxisSize.min,
      children: [
        GestureDetector(
          onTapDown: (_) => _startChangingRadius(10), // aceleração positiva
          onTapUp: (_) => _stopChangingRadius(),
          onTapCancel: () => _stopChangingRadius(),
          child: Container(
            width: 48,
            height: 48,
            decoration: BoxDecoration(
              color: const Color.fromARGB(255, 247, 180, 80),
              borderRadius: BorderRadius.circular(8),
            ),
            child: Icon(Icons.add, color: Colors.black),
          ),
        ),
        SizedBox(width: 16),
        GestureDetector(
          onTapDown: (_) => _startChangingRadius(-10), // aceleração negativa
          onTapUp: (_) => _stopChangingRadius(),
          onTapCancel: () => _stopChangingRadius(),
          child: Container(
            width: 48,
            height: 48,
            decoration: BoxDecoration(
              color: const Color.fromARGB(255, 247, 180, 80),
              borderRadius: BorderRadius.circular(8),
            ),
            child: Icon(Icons.remove, color: Colors.black),
          ),
        ),
      ],
    );
  }
}
