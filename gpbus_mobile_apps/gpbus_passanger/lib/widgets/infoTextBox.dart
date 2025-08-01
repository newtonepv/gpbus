
import 'package:flutter/material.dart';

Widget? infoTextBoxBuilder(String error_msg, int text_code){
  //text_code = -1 for red, 0 for blue, and 1 for green message
  Color textBoxColor = Colors.black;
  switch (text_code){
    case -1:
      textBoxColor = Colors.red;
    case 0:
      textBoxColor = Colors.blue;
    case 1:
      textBoxColor = Colors.green;
  }
  
  if (error_msg.isNotEmpty){
    return Container(
      margin: const EdgeInsets.all(16),
      padding: const EdgeInsets.all(12),
      constraints: const BoxConstraints(
        maxWidth: 200, 
      ),
      decoration: BoxDecoration(
        color: Colors.red.shade50,
        border: Border.all(color:textBoxColor),
        borderRadius: BorderRadius.circular(8),
      ),
      child: Row(children: [
        if(text_code==0)
          CircularProgressIndicator(
          color: textBoxColor,
          strokeWidth: 3, 
        ),
        SizedBox(
          width: 10,
        ),
        Expanded(
          child: Text(
            error_msg,
            style: TextStyle(
              color: textBoxColor,
              fontSize: 14,
              fontWeight: FontWeight.w500,
            ),
            textAlign: TextAlign.left,
            softWrap: true,
          ),
        ),
      ],)
    );
  }
  return null;
}
