import 'package:flutter/material.dart';
import 'package:gpbus_passanger/pages/busBucks_page.dart';
import 'package:gpbus_passanger/pages/cadastro_page.dart';
import 'package:gpbus_passanger/pages/config_page.dart';
import 'package:gpbus_passanger/pages/esqueceu_page.dart';
import 'package:gpbus_passanger/pages/loginPage.dart';
import 'package:gpbus_passanger/pages/splash_page.dart';
import 'package:gpbus_passanger/pages/alarm_page.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner:false,
      title: 'GPBus',
      theme: ThemeData(
        colorScheme:
            ColorScheme.fromSeed(seedColor: const Color.fromARGB(255, 255, 255, 255)),
      ),
      initialRoute: '/splash',
      routes: {
        '/splash': (_) => const SplashPage(),
        '/login': (_) => const LoginPage(),
        '/cadastro': (_) => const CreateAccount(),
        '/esqueceu': (_) => const EsqueceuPage(),
        '/config': (_) => const ConfigPage(),
        '/busbucks':(_) => const BusBucks(),
        'alarme':(_) => AlarmPage(),
      },
    );
  }
}

