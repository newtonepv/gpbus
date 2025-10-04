import 'package:flutter/material.dart';
import 'package:audioplayers/audioplayers.dart';

class RingingBellWidget extends StatefulWidget {
  final String text;
  final double size;
  final int busId;
  final int alarmId;
  final Function(int id) onDeactivated;

  const RingingBellWidget({
    Key? key,
    required this.text,
    required this.busId,
    required this.alarmId,
    required this.onDeactivated,
    this.size = 100.0,
  }) : super(key: key);

  @override
  State<RingingBellWidget> createState() => _RingingBellWidgetState();
}

class _RingingBellWidgetState extends State<RingingBellWidget>
    with SingleTickerProviderStateMixin {
  late AnimationController _controller;
  late Animation<double> _animation;
  late AudioPlayer _audioPlayer;

  @override
  void initState() {
    super.initState();
    _audioPlayer = AudioPlayer();
    _controller = AnimationController(
      duration: const Duration(milliseconds: 300),
      vsync: this,
    );
    _animation = Tween<double>(
      begin: -0.1,
      end: 0.1,
    ).animate(CurvedAnimation(
      parent: _controller,
      curve: Curves.elasticInOut,
    ));

    
    _startRinging();
  }

  void _startRinging() {
    _controller.repeat(reverse: true);
    _playBellSound();
  }

  void _playBellSound() async {
    try {
      // Play a bell sound on repeat
      await _audioPlayer.setReleaseMode(ReleaseMode.loop);
      await _audioPlayer.play(AssetSource('bellSound.wav'));
    } catch (e) {
      print('Error playing sound: $e');
    }
  }

  void _stopSound() async {
    await _audioPlayer.stop();
  }

  @override
  void dispose() {
    _controller.dispose();
    _audioPlayer.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () {
        _controller.stop();
        _controller.reset();
        _stopSound();
        widget.onDeactivated(widget.alarmId);
      },
      child: SizedBox(
        width: widget.size,
        child: Column(
          mainAxisSize: MainAxisSize.min,
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            AnimatedBuilder(
              animation: _animation,
              builder: (context, child) {
                return Transform.rotate(
                  angle: _animation.value,
                  child: Icon(
                    Icons.notifications,
                    color: Colors.red,
                    size: widget.size * 0.6,
                  ),
                );
              },
            ),
            SizedBox(height: widget.size * 0.1),
            Text(
              widget.text,
              style: TextStyle(
                color: Colors.red,
                fontSize: widget.size * 0.15,
                fontWeight: FontWeight.bold,
              ),
              textAlign: TextAlign.center,
            ),
          ],
        ),
      ),
    );
  }
}