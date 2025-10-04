import 'package:flutter/material.dart';
import 'package:gpbus_passanger/utils/alarm.dart';
class AlarmWidget extends StatelessWidget {
  final Alarm alarm;
  final Function(Alarm) onDelete;

  const AlarmWidget({
    super.key,
    required this.alarm,
    required this.onDelete,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: const EdgeInsets.symmetric(vertical: 6, horizontal: 12),
      padding: const EdgeInsets.symmetric(vertical: 12, horizontal: 16),
      decoration: BoxDecoration(
        color: const Color(0xFFffc966).withOpacity(0.2),
        borderRadius: BorderRadius.circular(16),
        border: Border.all(color: const Color(0xFFffc966), width: 1),
      ),
      child: Row(
        children: [
          Expanded(
            flex: 3,
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  'Ônibus: ${alarm.busId}',
                  style: const TextStyle(
                    fontWeight: FontWeight.bold,
                    fontSize: 15,
                  ),
                ),
                const SizedBox(height: 4),
                Text(
                  'Início: ${alarm.startTime.format(context)}',
                  style: const TextStyle(fontSize: 13),
                ),
                Text(
                  'Fim: ${alarm.endTime.format(context)}',
                  style: const TextStyle(fontSize: 13),
                ),
              ],
            ),
          ),
          IconButton(
            icon: const Icon(Icons.close, color: Colors.red),
            onPressed: (){onDelete(alarm);},
            tooltip: 'Remover alarme',
          ),
        ],
      ),
    );
  }
}

