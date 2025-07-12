import 'package:flutter/material.dart';

class AlarmPage extends StatelessWidget {
  const AlarmPage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Alarme'),
        backgroundColor: const Color(0xFFffc966),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            const Text(
              'Ainda não há alarmes definidos.',
              style: TextStyle(
                fontSize: 18,
                fontWeight: FontWeight.bold,
              ),
            ),
            const SizedBox(height: 16),
            ElevatedButton(
              onPressed: () {
                _showAddAlarmDialog(context);
              },
              style: ElevatedButton.styleFrom(
                backgroundColor: const Color(0xFFffc966),
                foregroundColor: Colors.black,
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(24),
                ),
                padding: const EdgeInsets.symmetric(horizontal: 24, vertical: 12),
              ),
              child: const Row(
                mainAxisSize: MainAxisSize.min,
                children: [
                  Icon(Icons.add),
                  SizedBox(width: 8),
                  Text('Adicionar Alarme'),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }

  void _showAddAlarmDialog(BuildContext context) {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AddAlarmDialog();
      },
    );
  }
}

class AppColors {
  static const Color primaryColor = Color(0xFFffc966);
  static const Color accentColor = Colors.blue;
  static const Color textColor = Colors.black;
  static const Color disabledTextColor = Colors.grey;
}

class AddAlarmDialog extends StatefulWidget {
  const AddAlarmDialog({super.key});

  @override
  _AddAlarmDialogState createState() => _AddAlarmDialogState();
}

class _AddAlarmDialogState extends State<AddAlarmDialog> {
  TimeOfDay _selectedTime = TimeOfDay.now();
  final List<bool> _selectedWeekdays = List.generate(7, (_) => false);
  String _alarmName = '';

   @override
  Widget build(BuildContext context) {
    return AlertDialog(
      content: SizedBox(
        width: MediaQuery.of(context).size.width * 0.9,
        child: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            TimePickerWidget(
              selectedTime: _selectedTime,
              onTimeChanged: (newTime) {
                setState(() {
                  _selectedTime = newTime;
                });
              },
            ),
            const SizedBox(height: 16),
            WeekdaySelectionWidget(
              selectedWeekdays: _selectedWeekdays,
              onWeekdayTapped: (dayIndex) {
                setState(() {
                  _selectedWeekdays[dayIndex] = !_selectedWeekdays[dayIndex];
                });
              },
            ),
            const SizedBox(height: 16),
            NameTextFieldWidget(
              alarmName: _alarmName,
              onNameChanged: (newName) {
                setState(() {
                  _alarmName = newName;
                });
              },
            ),
            const SizedBox(height: 16),
            ElevatedButton(
              onPressed: () {
                // Aqui você pode adicionar a lógica para salvar o alarme com as informações inseridas
                Navigator.of(context).pop(); // Fechar o pop-up após adicionar
              },
              style: ElevatedButton.styleFrom(
                backgroundColor: AppColors.primaryColor,
                foregroundColor: AppColors.textColor,
              ),
              child: const Text('Adicionar Alarme'),
            ),
          ],
        ),
      ),
      backgroundColor: Colors.white, // Cor de fundo do AlertDialog
    );
  }
}

class TimePickerWidget extends StatefulWidget {
  final TimeOfDay selectedTime;
  final ValueChanged<TimeOfDay> onTimeChanged;

  const TimePickerWidget({super.key, required this.selectedTime, required this.onTimeChanged});

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
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        const SizedBox(width: 8),
        TextButton(
          onPressed: () async {
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
          child: Text(_pickedTime.format(context)),
        ),
      ],
    );
  }
}

class WeekdaySelectionWidget extends StatelessWidget {
  final List<bool> selectedWeekdays;
  final ValueChanged<int> onWeekdayTapped;

  const WeekdaySelectionWidget(
      {super.key, required this.selectedWeekdays, required this.onWeekdayTapped});

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        for (int i = 0; i < 7; i++)
          GestureDetector(
            onTap: () {
              onWeekdayTapped(i);
            },
            child: Container(
              width: 30,
              height: 30,
              decoration: BoxDecoration(
                border: Border.all(
                  color: selectedWeekdays[i] ? Colors.blue : Colors.grey,
                  width: 2,
                ),
                borderRadius: BorderRadius.circular(15),
              ),
              child: Center(
                child: Text(
                  ['D', 'S', 'T', 'Q', 'Q', 'S', 'S'][i],
                  style: TextStyle(
                    color: selectedWeekdays[i] ? Colors.blue : Colors.black,
                    fontWeight: FontWeight.bold,
                  ),
                ),
              ),
            ),
          ),
      ],
    );
  }
}

class NameTextFieldWidget extends StatelessWidget {
  final String alarmName;
  final ValueChanged<String> onNameChanged;

  const NameTextFieldWidget({super.key, required this.alarmName, required this.onNameChanged});

  @override
  Widget build(BuildContext context) {
    return TextField(
      decoration: const InputDecoration(
        labelText: 'Nome do Alarme',
        hintText: 'Digite o nome do alarme',
      ),
      onChanged: (newName) {
        onNameChanged(newName);
      },
    );
  }
}
