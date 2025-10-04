import 'package:dio/dio.dart';
import 'package:flutter/material.dart';
import 'package:gpbus_passanger/pages/alarmPage/widgets/alarmCreationDialog.dart';
import 'package:gpbus_passanger/pages/alarmPage/widgets/alarmWidget.dart';
import 'package:gpbus_passanger/singleton/userInfo.dart';
import 'package:gpbus_passanger/utils/alarm.dart';
import 'package:gpbus_passanger/utils/customExceptions/custom_server_exceptions.dart';
import 'package:gpbus_passanger/utils/server_requests.dart';

class AlarmPage extends StatefulWidget {
  final UserInfo userInfo;
  
  AlarmPage({super.key, required this.userInfo});
  @override
  State<AlarmPage> createState() => _AlarmPageState();
}

class _AlarmPageState extends State<AlarmPage> {
  late UserInfo _userInfo;
  final CancelToken _cancelGetAlarms = CancelToken(); 
  bool _loadingAlarms = false;

  @override 
  void initState(){
    super.initState();
    _userInfo = widget.userInfo;
    _loadAlarms();
  }

  @override
  void dispose(){
    _cancelGetAlarms.cancel("navigated");
    super.dispose();
  }

  Future<void> _loadAlarms() async {
    setState((){
      _loadingAlarms = true;
    });
    try{
      List<Alarm> alarmsAux = await getAlarms(context, _userInfo.name, _cancelGetAlarms);
      setState(() {
        _userInfo.alarms=alarmsAux;
        _loadingAlarms=false;
      });
    }on CustomNavigatedToLoginPageException{
      //do nothing if it navigated to another page
    }on DioException catch (e){
      if(e.type==DioExceptionType.cancel){
        //if the request is canceled, nothing happens
      }else{
        rethrow;
      }
    }
  }

  Future<void> deleteAlarmWidget(Alarm a) async {
    setState(() {
      _loadingAlarms=true;
    });
    await deleteAlarm(context, _userInfo.name , _userInfo.password, a.alarmId);
    await _loadAlarms();// we can await or not await
  }

  List<Widget> alarmWidgets(List<Alarm> alarms){
    List<Widget> alarmWidgets = [];
    for(int i=0; i<alarms.length ;i++){
      Widget alarmWidget = AlarmWidget(alarm: alarms[i],onDelete: deleteAlarmWidget);
      alarmWidgets.add(alarmWidget);
    }
    return alarmWidgets;
  }
  

  @override
  Widget build(BuildContext context) {

    return Scaffold(
      appBar: AppBar(
        title: const Text('Alarmes'),
        backgroundColor: const Color(0xFFffc966),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            if(_loadingAlarms)
              Column(
                children: [
                  CircularProgressIndicator(
                    color: const Color(0xFFffc966),
                    strokeWidth: 3,
                  ),
                  const SizedBox(height: 16),
                  Text(
                    'Carregando alarmes...',
                    style: TextStyle(
                      fontSize: 16,
                      fontWeight: FontWeight.w500,
                      color: Colors.grey[600],
                    ),
                  ),
                ],
              )
            else if(_userInfo.alarms!.isEmpty)
              Text(
                'Ainda não há alarmes definidos.',
                style: TextStyle(
                  fontSize: 18,
                  fontWeight: FontWeight.bold,
                ),
              )
            else 
              Expanded(
                child: Center(
                  child: SingleChildScrollView(
                    child: Column(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: alarmWidgets(_userInfo.alarms!)
                    ),
                  ),
                ),
              ),
            const SizedBox(height: 16),
            ElevatedButton(
              onPressed: () {
                showDialog(//funcao do flutter para criar widgets que extendem de Dialog
                  context: context,
                  builder: (BuildContext context) {
                    
                    return AlarmCreationDialog(userInfo: _userInfo, 
                      onAlarmCreated: (){
                          _loadAlarms();
                        } 
                      );
                  },
                );
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
            const SizedBox(height: 32),
          ],
        ),
      ),
    );
  }

}

