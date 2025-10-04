// ignore_for_file: await_only_futures

import 'package:flutter/material.dart';
import 'package:gpbus_passanger/utils/customExceptions/custom_server_exceptions.dart';
import 'package:gpbus_passanger/utils/server_requests.dart';
import 'package:gpbus_passanger/utils/string_autentications.dart';
import 'package:gpbus_passanger/widgets/infoTextBox.dart';

class CreateAccount extends StatefulWidget {
  const CreateAccount({Key? key}) : super(key: key);

  @override
  State<CreateAccount> createState() => _CreateAccountState();
}

class _CreateAccountState extends State<CreateAccount> {
  final _userNameController = TextEditingController();
  final _passwordController = TextEditingController();

  @override
  void dispose() {
    _userNameController.dispose();
    _passwordController.dispose();
    super.dispose();
  }

  String _infoTextMsg="";
  int _infoTextCode=0;
  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        backgroundColor: const Color(0xFFfff8e4),
        body: Container(
          margin: const EdgeInsets.all(24),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: [
              _header(context),
              _inputField(context),
              _esqcSenha(context),
              _cadastrar(context),
            ],
          ),
        ),
      ),
    );
  }


  _header(context) {
    return const Column(
      children: [
        Text(
          "GPbuS",
          style: TextStyle(
              fontSize: 40,
              fontWeight: FontWeight.bold,
              color: Color(0xFFffa430)),
        ),
        Text(
          "Sua cidade ao seu alcance.",
          style: TextStyle(color: Color.fromARGB(255, 0, 0, 0)),
        ),
      ],
    );
  }

  _inputField(context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.stretch,
      children: [
        TextField(
          controller: _userNameController,
          decoration: InputDecoration(
              hintText: "Nome da conta",
              border: OutlineInputBorder(
                  borderRadius: BorderRadius.circular(18),
                  borderSide: BorderSide.none),
              fillColor: const Color(0xFFffc966).withOpacity(0.1),
              filled: true,
              prefixIcon: const Icon(
                Icons.person,
                color: Color(0xFFffc966),
              )),
        ),
        const SizedBox(height: 10),
        TextField(
          controller: _passwordController,
          decoration: InputDecoration(
              hintText: "Senha da conta",
              border: OutlineInputBorder(
                  borderRadius: BorderRadius.circular(18),
                  borderSide: BorderSide.none),
              fillColor: const Color(0xFFffc966).withOpacity(0.1),
              filled: true,
              prefixIcon: const Icon(
                Icons.lock,
                color: Color(0xFFffc966),
              )),
          obscureText: true,
        ),
        const SizedBox(height: 10),
        ElevatedButton(
          onPressed: () async{
            setState(() {
              _infoTextMsg="Criando conta...";
              _infoTextCode=0;
            });
            if(filters(_userNameController.text, _passwordController.text)==false){
              setState(() {
                _infoTextMsg="Não use caracteres especiais nem deixe em branco";
                _infoTextCode=-1;
              });
              return;
            }
            try{
              await createUser(context, _userNameController.text, _passwordController.text);
              setState(() {
                _infoTextMsg="Conta criada com sucesso";
                _infoTextCode=1;
              });
            }on Custom409Exception  catch (e){
              setState(() {
                _infoTextMsg=e.toString();
                _infoTextCode=-1;
              });
            }on CustomNavigatedToLoginPageException{
              //do nothing
            }
          },
          style: ElevatedButton.styleFrom(
            shape: const StadiumBorder(),
            backgroundColor: const Color(0xFFffc966),
            padding: const EdgeInsets.symmetric(vertical: 16),
          ),
          child: const Text(
            "Cadastrar",
            style: TextStyle(fontSize: 20),
          ),
        ),
        const SizedBox(height: 10),
        if (infoTextBoxBuilder(_infoTextMsg,_infoTextCode) != null)infoTextBoxBuilder(_infoTextMsg,_infoTextCode)!
      ],
    );
  }

  _esqcSenha(context) {
    return const SizedBox.shrink();
  }

  _cadastrar(context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        const Text(
          "Já tem uma conta?",
          style: TextStyle(color: Colors.grey),
        ),
        TextButton(
            onPressed: () {
              Navigator.pop(context);
            },
            child: const Text(
              "Faça login.",
              style: TextStyle(color: Color(0xFFffa430)),
            ))
      ],
    );
  }
}
