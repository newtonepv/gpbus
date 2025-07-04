// ignore_for_file: library_private_types_in_public_api, file_names, sized_box_for_whitespace, prefer_const_constructors

import 'package:flutter/material.dart';

class ListaPesquisaPage extends StatefulWidget {
  const ListaPesquisaPage({Key? key}) : super(key: key);

  @override
  ListaPesquisaPageState createState() => ListaPesquisaPageState();
}

class ListaPesquisaPageState extends State<ListaPesquisaPage> {

  static List<String> rotas = [
    '2013',
    '2022'
  ];


  @override
  Widget build(BuildContext context) {

    return Container(
      width: 100,
      height: 10,
      color: Colors.amber,
      child:
        Column(
          children: [
            ListView.separated(
            itemBuilder: (BuildContext context, int index) {
              return ListTile(
                title: Text(
                  rotas[index],
                ),
              );
            },
            padding: EdgeInsets.all(16),
            separatorBuilder: (BuildContext context, int index){
              return Divider();
              },
            itemCount: rotas.length)
          ],
        )
      ,
    );
  }
}