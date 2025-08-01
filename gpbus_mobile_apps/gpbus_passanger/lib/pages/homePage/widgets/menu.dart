import 'package:flutter/material.dart';
import 'package:gpbus_passanger/pages/alarm_page.dart';
import 'package:gpbus_passanger/pages/busBucks_page.dart';
import 'package:gpbus_passanger/pages/config_page.dart';

void showHomePageMenu(BuildContext context) {
    showModalBottomSheet(
      context: context,
      isScrollControlled: true,
      builder: (BuildContext context) {
        return Container(
          decoration: BoxDecoration(
            color: const Color(0xFFfff8e4).withOpacity(0.9),
            borderRadius: const BorderRadius.vertical(
              top: Radius.circular(20),
            ),
          ),
          child: Column(
            mainAxisSize: MainAxisSize.min,
            crossAxisAlignment: CrossAxisAlignment.stretch,
            children: [
              Container(
                height: 55,
                color: const Color(0xFFffc966),
                padding: const EdgeInsets.all(16),
                child: const Text(
                  'Menu',
                  style: TextStyle(
                    color: Colors.white,
                    fontSize: 20,
                    fontWeight: FontWeight.bold,
                  ),
                ),
              ),
              _buildMenuItem(Icons.settings, 'Configurações', () {
                Navigator.push(
                  context,
                  PageRouteBuilder(
                    pageBuilder: (context, animation, secondaryAnimation) =>
                        const ConfigPage(),
                    transitionsBuilder:
                        (context, animation, secondaryAnimation, child) {
                      const begin = Offset(1.0, 0.0);
                      const end = Offset.zero;
                      const curve = Curves.ease;

                      final tween = Tween(begin: begin, end: end)
                          .chain(CurveTween(curve: curve));

                      return SlideTransition(
                        position: animation.drive(tween),
                        child: child,
                      );
                    },
                  ),
                );
              }),
              _buildMenuItem(Icons.monetization_on, 'BusBucks', () {
                Navigator.push(
                context,
                PageRouteBuilder(
                  pageBuilder: (context, animation, secondaryAnimation) => const BusBucks(),
                  transitionsBuilder:
                      (context, animation, secondaryAnimation, child) {
                    const begin = Offset(1.0, 0.0);
                    const end = Offset.zero;
                    const curve = Curves.ease;

                    final tween = Tween(begin: begin, end: end)
                        .chain(CurveTween(curve: curve));

                    return SlideTransition(
                      position: animation.drive(tween),
                      child: child,
                    );
                  },
                ),
              );

              }),
              _buildMenuItem(Icons.favorite, 'Favoritos', () {}),
              _buildMenuItem(Icons.alarm, 'Alarme', () {
          Navigator.push(
            context,
            MaterialPageRoute(builder: (context) => AlarmPage()), // Navigate to AlarmPage
          );
        }),
              _buildMenuItem(Icons.star, 'Avaliações', () {}),
            ],
          ),
        );
      },
    );
  }
  Widget _buildMenuItem(IconData iconData, String text, VoidCallback onTap) {
  return InkWell(
    onTap: onTap,
    child: Container(
      padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 12),
      child: Row(
        children: [
          Icon(iconData),
          const SizedBox(width: 16),
          Text(
            text,
            style: const TextStyle(
              fontSize: 16,
            ),
          ),
        ],
      ),
    ),
  );
}