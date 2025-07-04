import 'package:flutter/material.dart';
import 'package:tcc_teste/pages/cadastro_page.dart';
import 'package:tcc_teste/pages/esqueceu_page.dart';
import 'package:tcc_teste/pages/inicio.dart';

class LoginPage extends StatefulWidget {
  const LoginPage({Key? key}) : super(key: key);

  @override
  State<LoginPage> createState() => _LoginPageState();

}

class _LoginPageState extends State<LoginPage> {
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
              _cadastreSe(context),
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

  final TextEditingController _usuarioController = TextEditingController();

  final TextEditingController _senhaController = TextEditingController();

  _inputField(context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.stretch,
      children: [
        TextField(
          controller: _usuarioController,
          decoration: InputDecoration(
              hintText: "Usuário",
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
          controller: _senhaController,
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
            ),
          ),
          obscureText: true,
        ),
        const SizedBox(height: 10),
        ElevatedButton(
          onPressed: () {
            String usuario = _usuarioController.text.trim();
            String senha = _senhaController.text.trim();
            if (usuario == "admin" && senha == "123") {
              Navigator.push(context,
                  MaterialPageRoute(builder: (context) => const HomePage()));
            } else {
              showDialog(
                context: context,
                builder: (context) => AlertDialog(
                  title: const Text("Usuário ou senha incorretos"),
                  content: const Text("Por favor, tente novamente."),
                  actions: [
                    TextButton(
                      onPressed: () {
                        Navigator.of(context).pop();
                      },
                      child: const Text("OK"),
                    ),
                  ],
                ),
              );
            }
          },
          style: ElevatedButton.styleFrom(
            shape: const StadiumBorder(),
            backgroundColor: const Color(0xFFffc966),
            padding: const EdgeInsets.symmetric(vertical: 16),
          ),
          child: const Text(
            "Login",
            style: TextStyle(fontSize: 20),
          ),
        ),
      ],
    );
  }

  _esqcSenha(context) {
    return TextButton(
        onPressed: () {
          Navigator.push(context,
              MaterialPageRoute(builder: (context) => const EsqueceuPage()));
        },
        child: const Text(
          "Esqueceu sua senha?",
          style: TextStyle(color: Color(0xFFffa430)),
        ));
  }

  _cadastreSe(context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        const Text(
          "Ainda não tem uma conta?",
          style: TextStyle(color: Colors.grey),
        ),
        TextButton(
            onPressed: () {
              Navigator.push(
                  context,
                  MaterialPageRoute(
                      builder: (context) => const CadastroPage()));
            },
            child: const Text(
              "Cadastre-se já.",
              style: TextStyle(color: Color(0xFFffa430)),
            ))
      ],
    );
  }
}
