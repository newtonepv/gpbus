import 'package:flutter/material.dart';
import 'package:tcc_teste/pages/loginPage.dart';

void loadLoginPage({required BuildContext context, String errorMsg=""}){
    Navigator.pushReplacement(
      context, 
      MaterialPageRoute(builder: (context) => LoginPage(errorMsg: errorMsg,))
    );
  }