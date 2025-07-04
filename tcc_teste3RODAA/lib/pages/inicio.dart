// ignore_for_file: prefer_const_constructors, prefer_final_fields, prefer_interpolation_to_compose_strings
//!Autocomplete

import 'dart:async';
import 'package:flutter/material.dart';
import 'package:flutter_map/flutter_map.dart';
import 'package:latlong2/latlong.dart';
import 'package:flutter/services.dart';
import 'package:tcc_teste/controllers/mapcontroller.dart';
import 'package:tcc_teste/pages/config_page.dart';
import 'package:tcc_teste/pages/busBucks_page.dart';
import 'package:tcc_teste/pages/alarm_page.dart';
import 'package:tcc_teste/utils/dao.dart';


class HomePage extends StatefulWidget {
  const HomePage({super.key});
  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  MapController _mapController = MapController();
  double latitude = 0;
  double longitude = 0;
  Timer? _timer;
  int isFirstSetState = 0;
  
  String nome = '';
  int estrelas = 1;
  int lotacao = 1;
  int lotacaoTot = 1;

  Future<void> _searchCoordinates(String code) async {
    List listaltlg = await dao.trazerlatlong(code);
    setState(() {
    latitude = listaltlg[0];
    longitude = listaltlg[1];
    });
  }

  
  
  void _startUpdatingCoordinates() {
  _timer?.cancel(); // Cancelar o temporizador existente
  const interval = Duration(seconds: 1);
  _timer = Timer.periodic(interval, (timer) async {
    final searchCode = _searchController.text.trim();
    if (rotas.contains(searchCode)) {
      await _searchCoordinates(searchCode);
      if (isFirstSetState<2){ 
        setState(() {
          isFirstSetState++;
          focarbus = true;
        });
      }else{
        focarbus = false;

      }
    }
  });
  }
  static double calcAlt(){
    if(zeraRecomendacao == true ){
      return 0;
    }else{ 
    if(excedeu){
      return 170;
    }else{
      return mostradas.length*32.4;
    }
    }
  }
  static bool focaBouN(){
    if(contagem>2){
      return false;
      }else{
        return true;
        }
  }
  @override
  void initState() {
    super.initState();
    _startUpdatingCoordinates(); // Iniciar o timer de atualização
  }

  @override
  void dispose() {
    _searchController.dispose();
    _timer?.cancel(); // Cancelar o timer ao sair da tela
    super.dispose();
  }

  static TextEditingController _searchController = TextEditingController();
  static List<String> rotas = [
    '2013',
    '2022',
    '2023',
    '2024',
    '2026',
    '2025',
  ];
  static List<String> mostradas = [];
  bool focarloc1 = false;
  bool focarbus = false;
  bool mostrarloc = true;
  static bool zeraRecomendacao = false;
  bool tapped = false;
  static bool excedeu = false;
  String rotaselec = '';
  dynamic latLong = LatLng(-22.56248, -47.42426);
  static int contagem = 1;


  @override
  Widget build(BuildContext context) {
    

    String searchCode = "";
  

  
    
    // Desabilita a funcionalidade de voltar à tela anterior
    return WillPopScope(
      onWillPop: () async {
        // Ação desejada ao pressionar o botão de voltar
        SystemNavigator.pop();
        return false;
      },
      child: Scaffold(
        appBar: AppBar(
          automaticallyImplyLeading: false,
          toolbarHeight: 45,
          backgroundColor: const Color(0xFFffc966),
          title: Container(
            padding: const EdgeInsets.symmetric(horizontal: 8),
            decoration: BoxDecoration(
              color: Colors.grey[200],
              borderRadius: BorderRadius.circular(20),
            ),
            height: 27,
            child: Row(
              children: [
                 Expanded(
                  child: TextField(
                    onChanged: (value) async {
                      searchCode = _searchController.text.trim();

                      if (searchCode.isNotEmpty&&rotas.contains(searchCode)) {


                        setState(() {
                        zeraRecomendacao = true;
                        mostrarloc = false;
                        rotaselec = searchCode;
                        });
                        
                        isFirstSetState = 0;
                        

                      }else if(searchCode.isNotEmpty&&rotas.contains(searchCode)==false){ 
                      mostradas = rotas.where((rota) => rota.contains(searchCode)).toList();
                      if(mostradas.length*30>=180){
                        setState(() {
                        excedeu = true;
                        zeraRecomendacao = false;
                        });
                      }else{
                        setState(() {
                        excedeu = false;
                        zeraRecomendacao = false;
                        });
                      }
                        setState(() {
                        zeraRecomendacao = false;
                        });
                     
                      }else if(searchCode.isEmpty){
                        setState(() {
                       zeraRecomendacao = true;
                       });
                      }
                      
                    },
                    controller: _searchController,
                    style: TextStyle(fontSize: 14),
                    decoration: InputDecoration(
                      hintText: "digite uma linha de onibus...",
                      border: InputBorder.none,
                      isDense: true,
                      contentPadding:
                          EdgeInsets.only(top: 8, bottom: 6, left: 0, right: 0),
                    ),
                    
                  ),
                ),
                
              ],
            ),
          ),
          actions: [
            IconButton(
              icon: const Icon(Icons.menu),
              color: Colors.black, // adicionando a propriedade color
              onPressed: () {
                _showMenu(context);
              },
            ),
          ],
        ),
        body: 
        Stack( 
        children:[ 

        Positioned.fill(
          child:
          SizedBox(
          height: 525,
          width: 600,
          child:mapcontroller.desenhapontos(rotaselec, latitude, longitude, mostrarloc, focarloc1, focarbus, _mapController ),
        ),
        ),
       Positioned(
            left: 10,
            right: 10,
            height: calcAlt(),
            child: Container(
              padding: EdgeInsets.only(top: 5),
              color: Color.fromARGB(255, 255, 255, 255),
              child:ListView.separated(
      
                itemBuilder: (BuildContext context, int index){ 
                return SizedBox(

                  height: 20,
                  child: ElevatedButton(
                    style: ButtonStyle(
                      alignment: Alignment.centerLeft,
                      backgroundColor: MaterialStateProperty.all<Color>(Colors.white),
                      ),
                      
                      
                    onPressed:()async {
                      
                      _searchController.text = mostradas[index];
                      searchCode = _searchController.text.trim();
                      if (searchCode.isNotEmpty) {
                        await _searchCoordinates(searchCode);
                      }
                      setState(() {
                        zeraRecomendacao = true;
                        rotaselec = searchCode;
                        contagem = 1;
                      });
                      
                    },

                    child: 
                      Container(
                        padding: EdgeInsets.only(bottom: 5),
                        child:
                        Text(
                      "     • ${mostradas[index]}",
                      style: TextStyle(
                        
                        color: Color.fromARGB(255, 0, 0, 0),
                      ),
                    ),
                    ),
                ));

                }, 
                separatorBuilder: (BuildContext context, index){
                  return Divider();
                }, 
                itemCount: mostradas.length
                ),
              ),
          ),
        ],
        ),
        bottomNavigationBar: BottomAppBar(
          height: 50,
          color: const Color(0xFFffc966),
          child: Row(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: [
              InkWell(
                onTap: () {
                  if(tapped){
                    setState(() {
                  mostrarloc = false;
                  focarloc1 = false;
                  tapped = false;
                    });
                }else{
                  setState(() {
                  mostrarloc=true;
                  focarloc1=true;
                  tapped= true;
                });
                }
                
                },
                child: Image.asset(
                  'assets/home/icons/location.png',
                  height: 24,
                  width: 24,
                ),
              ),
              InkWell(
                onTap: () {},
                child: Image.asset(
                  'assets/home/icons/busStop.png',
                  height: 24,
                  width: 24,
                ),
              ),           
              InkWell(
                onTap: () {},
                child: Image.asset(
                  'assets/home/icons/clock.png',
                  height: 24,
                  width: 24,
                ),
              ), 
              InkWell(
                onTap: () {
                  setState(() {
                    _mapController.move(_mapController.center, _mapController.zoom + 1);
                  });
                },
                child: Icon(
                  Icons.zoom_in_rounded,
                  size: 27,
                ),
              ),    
              InkWell(
                onTap: () {
                  setState(() {
                    _mapController.move(_mapController.center, _mapController.zoom - 1);
                  });
                },
                child: Icon(
                  Icons.zoom_out_rounded,
                  size: 27,
                ),
              ), 
            ],
          ),
        ),
      ),
    );
  }

  void _showMenu(BuildContext context) {
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
}



