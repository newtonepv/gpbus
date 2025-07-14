// ignore_for_file: prefer_const_constructors, prefer_interpolation_to_compose_strings

import 'package:flutter/material.dart';
import 'package:tcc_teste/utils/changingPageFunctions.dart';
import 'package:tcc_teste/utils/customExceptions/custom_server_exceptions.dart';
import 'package:tcc_teste/utils/server_requests.dart';

class MoveBus200Button extends StatefulWidget {

  const MoveBus200Button({
    Key? key,
  }) : super(key: key);

  @override
  State<MoveBus200Button> createState() => _MoveBus200ButtonState();
}

class _MoveBus200ButtonState extends State<MoveBus200Button> {
  String _msg = "Mover ônibus número 200";
  bool _isloading = false;
  Color backgroundColor = const Color.fromARGB(255, 252, 176, 77); 
  Color foregroundColor = const Color.fromARGB(255, 53, 33, 8); 

  @override 
  void dispose() {
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      constraints: const BoxConstraints(
        minWidth: 200,   // Minimum width
        maxWidth: 400,   // Maximum width
      ),
      width: 300,         // Default width (between min and max)
      child: ElevatedButton(
        onPressed: () async {
          setState(() {
            _msg = "Verificando se já não está se movendo";
            _isloading = true;
          });
          try {
            await makeBus200Moove(context);
            setState(() {
              _msg = "Movido com sucesso!!\nMover denovo";
              _isloading = false;
            });
          } on Custom409Exception catch (e) {
            setState(() {
              _msg = e.toString() + "\nTentar denovo";
              _isloading = false;
            });
          } on CustomNavigatedToLoginPageException {
            //do nothing
          }
        },
        style: ElevatedButton.styleFrom(
          backgroundColor: backgroundColor,
          foregroundColor: foregroundColor,
          padding: const EdgeInsets.symmetric(horizontal: 24, vertical: 12),
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(8),
          ),
        ),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Flexible(
              child: Text(
                _msg,
                style: const TextStyle(
                  fontSize: 16,
                  fontWeight: FontWeight.w500,
                ),
                overflow: TextOverflow.ellipsis,
              ),
            ),
            if (_isloading)
              const SizedBox(
                width: 30,
                height: 30,
                child: Padding(
                  padding: EdgeInsets.all(5),
                  child: CircularProgressIndicator(),
                ),
              ),
          ],
        ),
      ),
    );
  }
}