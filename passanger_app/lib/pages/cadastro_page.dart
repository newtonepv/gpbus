import 'package:flutter/material.dart';

class CreateAccount extends StatefulWidget {
  const CreateAccount({Key? key}) : super(key: key);

  @override
  State<CreateAccount> createState() => _CreateAccountState();
}

class _CreateAccountState extends State<CreateAccount> {
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

  void _logica_cadastrar() {
    
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
          decoration: InputDecoration(
              hintText: "Nome completo",
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
          decoration: InputDecoration(
              hintText: "E-mail",
              border: OutlineInputBorder(
                  borderRadius: BorderRadius.circular(18),
                  borderSide: BorderSide.none),
              fillColor: const Color(0xFFffc966).withOpacity(0.1),
              filled: true,
              prefixIcon: const Icon(
                Icons.mail,
                color: Color(0xFFffc966),
              )),
        ),
        const SizedBox(height: 10),
        TextField(
          decoration: InputDecoration(
              hintText: "Senha",
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
          onPressed: () {
            _logica_cadastrar();
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
        )
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
