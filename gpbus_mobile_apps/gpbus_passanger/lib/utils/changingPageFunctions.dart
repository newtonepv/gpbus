import 'package:flutter/material.dart';
import 'package:gpbus_passanger/pages/loginPage.dart';

void loadLoginPage({required BuildContext context, String errorMsg=""}){
    Navigator.pushReplacement(
      context, 
      MaterialPageRoute(builder: (context) => LoginPage(errorMsg: errorMsg,))
    );
  }