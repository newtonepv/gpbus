// ignore_for_file: prefer_const_constructors

import 'package:flutter/material.dart';
class ConfigPage extends StatefulWidget {
  const ConfigPage({Key? key}) : super(key: key);

  @override
  // ignore: library_private_types_in_public_api
  _ConfigPageState createState() => _ConfigPageState();
}

class _ConfigPageState extends State<ConfigPage> {
   late bool _isChecked = false;

  void _toggleCheck(bool? value) {
  setState(() {
    _isChecked = value ?? false;
  });
}

  final List<Map<String, dynamic>> _expandableList = [
    
    {
      "title": "APARÊNCIA",
      "subtitle": "Modo claro, escuro",
      "options": [
        {"title": "Tema escuro", "icon": Icons.brightness_3_sharp, "checkbox": true},
      ]
    },
    {
      "title": "CONTA",
      "subtitle": "Gerencie sua conta",
      "options": [
        {"title": "Editar perfil", "icon": Icons.edit},
        {"title": "Alterar senha", "icon": Icons.lock},
        {"title": "Excluir conta", "icon": Icons.delete},
      ]
    },
    {
      "title": "PAGAMENTO",
      "subtitle": "Cartões cadastrados, Pagamentos anteriores, Doações",
      "options": [
        {"title": "Cadastrar cartão", "icon": Icons.wallet_giftcard},
        {"title": "Histórico", "icon": Icons.arrow_back},
        {"title": "Doações", "icon": Icons.handshake},
      ]
    },
    {
      "title": "SOBRE",
      "subtitle": "Saiba mais sobre o aplicativo",
      "options": [
        {"title": "Sobre nós", "icon": Icons.info},
        {"title": "Redes sociais", "icon": Icons.person},
      ]
    },
    {
      "title": "SUPORTE",
      "subtitle": "Obtenha ajuda e suporte",
      "options": [
        {"title": "Central de ajuda", "icon": Icons.help},
        {"title": "Contato", "icon": Icons.phone},
      ]
    },
  ];



  @override
  Widget build(BuildContext context) {
    
    return Scaffold(
      
        appBar: AppBar(
          backgroundColor: _isChecked ?  Color.fromARGB(255, 46, 43, 43) :  Color(0xFFFFC966),
          title: const Text('Configurações'),
        ),
        body: Container(
            
            color: _isChecked ? Color.fromARGB(255, 58, 58, 58) :  Color(0xFFffebbe),
            child: ListView(children: [
              const SizedBox(height: 22),
              Text(
                'CONECTAR',
                style: TextStyle(
                  fontSize: 18,
                  fontWeight: FontWeight.bold,
                  color: _isChecked ?  Color.fromARGB(255, 211, 211, 211) : Color.fromRGBO(0, 0, 0, 1.0),
                ),
                textAlign: TextAlign.center,
              ),
              const SizedBox(height: 18),
              Padding(
                padding: const EdgeInsets.symmetric(horizontal: 16),
                child: Column(
                  children: [
                    Row(
                      children: [
                        Expanded(
                          child: Container(
                            
                            margin: const EdgeInsets.only(top: 0),
                            decoration: BoxDecoration(
                              color: _isChecked? Color.fromARGB(255, 78, 78, 78): null,
                              border: Border.all(
                                color: Colors.grey,
                                width: 1.0,
                              ),
                              borderRadius: BorderRadius.circular(8),
                            ),
                            child: Column(
                              
                              children: [
                                const SizedBox(height: 8),
                                 Text(
                                  'Conecte-se com \no Facebook',
                                  textAlign: TextAlign.center,
                                  style: TextStyle( 
                                  color: _isChecked? Color.fromARGB(255, 255, 255, 255): null,
                                  )
                                ),
                                const SizedBox(height: 3),
                                Row(
                                  mainAxisAlignment: MainAxisAlignment.center,
                                  children: [
                                    ElevatedButton(
                                      onPressed: () {},
                                      style: ElevatedButton.styleFrom(
                                        backgroundColor:
                                             _isChecked? const Color.fromARGB(255, 65, 65, 65) :Color(0xFFffc966),
                                      ),
                                      child: const Text('Conectar'),
                                    ),
                                  ],
                                ),
                                const SizedBox(height: 8),
                              ],
                            ),
                          ),
                        ),
                        const SizedBox(width: 16),
                        Expanded(
                          child: Container(
                            margin: const EdgeInsets.only(top: 0),
                            decoration: BoxDecoration(
                              color: _isChecked?  Color.fromARGB(255, 78, 78, 78): null,
                              border: Border.all(
                                color: Colors.grey,
                                width: 1.0,
                              ),
                              borderRadius: BorderRadius.circular(8),
                            ),
                            child: Column(
                              children: [
                                const SizedBox(height: 8),
                                 Text(
                                  'Conecte-se com \no Google',
                                  textAlign: TextAlign.center,
                                  style: TextStyle( 
                                  color: _isChecked? Color.fromARGB(255, 255, 255, 255): null,
                                  )
                                ),
                                const SizedBox(height: 3),
                                Row(
                                  mainAxisAlignment: MainAxisAlignment.center,
                                  children: [
                                    ElevatedButton(
                                      onPressed: () {},
                                      style: ElevatedButton.styleFrom(
                                        backgroundColor:
                                             _isChecked? const Color.fromARGB(255, 65, 65, 65) :Color(0xFFffc966),
                                      ),
                                      child: const Text('Conectar'),
                                    ),
                                  ],
                                ),
                                const SizedBox(height: 8),
                              ],
                            ),
                          ),
                        ),
                      ],
                    ),
                  ],
                ),
              ),
              const SizedBox(height: 10),
              const Divider(),
              const SizedBox(height: 8),
              Text(
                'CONFIGURAÇÕES',
                style: TextStyle(
                  fontSize: 18, 
                  fontWeight: FontWeight.bold,
                  color: _isChecked ? Color.fromARGB(255, 189, 189, 189) : Color.fromARGB(255, 29, 29, 29)),
                textAlign: TextAlign.center,
              ),
              const SizedBox(height: 12),
              Padding(
                  padding: const EdgeInsets.symmetric(horizontal: 16),
                  child: Column(
                    
                    children: _expandableList.map((item) {
                      return ExpansionTile(
                        title: Text(item['title'],
                                  style: TextStyle(
                                  color: _isChecked ? Color.fromARGB(255, 189, 189, 189) :Color.fromARGB(255, 29, 29, 29) ,
                                ),),
                        subtitle: Text(item['subtitle'],
                                  style: TextStyle(
                                  color: _isChecked ?  Color.fromARGB(255, 189, 189, 189) :Color.fromARGB(255, 29, 29, 29)
                                ),),
                        children: item['options'].map<Widget>((option) {
                          return ListTile(
                            leading:

                              Icon(
                              option['icon'],
                              color: _isChecked ?  Color.fromARGB(255, 189, 189, 189) :Color.fromARGB(255, 29, 29, 29)),

                            title: 
                            option['title'] == "Tema escuro" ? null :
                             Text(option['title'],
                             style: TextStyle(
                                  color: _isChecked ? Color.fromARGB(255, 189, 189, 189) : Color.fromARGB(255, 29, 29, 29),
                                ),
                             ),
                            onTap: () {},
                            //SUBTITULO
                            subtitle: option['checkbox'] == true ? CheckboxListTile(
                              contentPadding: EdgeInsets.only(left: 0, right: 0),
                              title: Text(
                                'Modo Escuro',
                                style: TextStyle(
                                  color: _isChecked ?Color.fromARGB(255, 189, 189, 189) :Color.fromARGB(255, 29, 29, 29),
                                ),
                              ),
                              value: _isChecked,
                              onChanged: _toggleCheck,
                              controlAffinity: ListTileControlAffinity.leading,
                            ) : null,
                          );
                        }).toList(),
                      );
                    }).toList(),
                  ),
                ),
            ])));
  }
}
