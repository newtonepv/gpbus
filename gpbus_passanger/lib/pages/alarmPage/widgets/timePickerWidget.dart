import 'package:flutter/material.dart';
class TimePickerWidget extends StatefulWidget {
  final TimeOfDay selectedTime;
  final ValueChanged<TimeOfDay> onTimeChanged;
  final String label; // legenda

  const TimePickerWidget({
    super.key,
    required this.selectedTime,
    required this.onTimeChanged,
    required this.label
  });

  @override
  _TimePickerWidgetState createState() => _TimePickerWidgetState();
}

class _TimePickerWidgetState extends State<TimePickerWidget> {
  late TimeOfDay _pickedTime;

  @override
  void initState() {
    super.initState();
    _pickedTime = widget.selectedTime;
  }

  @override
  Widget build(BuildContext context) {
    // Fonte responsiva
    double fontSize = MediaQuery.of(context).size.width * 0.025;

    return Expanded(
      child: InkWell(
        borderRadius: BorderRadius.circular(16),
        onTap: () async {
          TimeOfDay? pickedTime = await showTimePicker(
            context: context,
            initialTime: _pickedTime,
          );
          if (pickedTime != null) {
            setState(() {
              _pickedTime = pickedTime;
              widget.onTimeChanged(_pickedTime);
            });
          }
        },
        child: Container(
          margin: const EdgeInsets.symmetric(horizontal: 8, vertical: 8),
          padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 12),
          decoration: BoxDecoration(
            color: const Color(0xFFffc966).withOpacity(0.15),
            borderRadius: BorderRadius.circular(16),
            border: Border.all(color: const Color(0xFFffc966), width: 1),
          ),
          child: Row(
            children: [
              Icon(Icons.access_time, color: const Color(0xFFffc966)),
              const SizedBox(width: 8),
              Expanded(
                flex: 5,
                child: Text(
                  widget.label,
                  style: TextStyle(
                    fontWeight: FontWeight.bold,
                    color: const Color(0xFFffc966),
                    fontSize: fontSize,
                  ),
                  overflow: TextOverflow.ellipsis,
                  maxLines: 1,
                ),
              ),
              const SizedBox(width: 8),
              Text(
                _pickedTime.format(context),
                style: TextStyle(
                  fontWeight: FontWeight.bold,
                  fontSize: fontSize,
                ),
                maxLines: 1,
              ),
            ],
          ),
        ),
      ),
    );
  }
}