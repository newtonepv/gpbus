import 'package:flutter/material.dart';
class EsqueceuPage extends StatelessWidget {
  const EsqueceuPage({super.key});

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
              _header(),
              _inputField(context),
              _cancelButton(context),
            ],
          ),
        ),
      ),
    );
  }

  _header() {
    return const Column(
      children: [
        Text(
          "Esqueceu a senha?",
          style: TextStyle(
              fontSize: 30,
              fontWeight: FontWeight.bold,
              color: Color(0xFFffa430)),
        ),
        Text(
          "Digite seu email para redefinir sua senha.",
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
              hintText: "Email",
              border: OutlineInputBorder(
                  borderRadius: BorderRadius.circular(18),
                  borderSide: BorderSide.none),
              fillColor: const Color(0xFFffc966).withOpacity(0.1),
              filled: true,
              prefixIcon: const Icon(
                Icons.email,
                color: Color(0xFFffc966),
              )),
        ),
        const SizedBox(height: 10),
        ElevatedButton(
          onPressed: () {},
          style: ElevatedButton.styleFrom(
            shape: const StadiumBorder(),
            backgroundColor: const Color(0xFFffc966),
            padding: const EdgeInsets.symmetric(vertical: 16),
          ),
          child: const Text(
            "Enviar",
            style: TextStyle(fontSize: 20),
          ),
        )
      ],
    );
  }

  _cancelButton(context) {
    return TextButton(
        onPressed: () {
          Navigator.pop(context);
        },
        child: const Text(
          "Cancelar",
          style: TextStyle(color: Colors.grey),
        ));
  }
}
