import 'package:flutter/material.dart';

class LoadingPage extends StatelessWidget{
  final String msg;
  const LoadingPage({super.key, required this.msg});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color(0xFFfff8e4),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            const CircularProgressIndicator(
              valueColor: AlwaysStoppedAnimation<Color>(Color(0xFFffc966)),
              strokeWidth: 3.0,
            ),
            const SizedBox(height: 24),
            Text(
              msg,
              style: const TextStyle(
                fontSize: 16,
                color: Colors.black54,
                fontWeight: FontWeight.w500,
              ),
            ),
            const SizedBox(height: 8),
            const Text(
              'Aguarde um momento',
              style: TextStyle(
                fontSize: 14,
                color: Colors.black38,
              ),
            ),
          ],
        ),
      ),
    );
  }
}