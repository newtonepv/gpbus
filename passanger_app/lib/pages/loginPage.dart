import 'package:flutter/material.dart';
import 'package:tcc_teste/pages/cadastro_page.dart';
import 'package:tcc_teste/pages/esqueceu_page.dart';
import 'package:tcc_teste/pages/homePage/homePage.dart';
import 'package:tcc_teste/utils/customExceptions/custom_server_exceptions.dart';
import 'package:tcc_teste/utils/server_requests.dart';
import 'package:tcc_teste/widgets/infoTextBox.dart';

class LoginPage extends StatefulWidget {
  final String errorMsg;
  const LoginPage({super.key, this.errorMsg=""});

  @override
  State<LoginPage> createState() => _LoginPageState();

}

class _LoginPageState extends State<LoginPage> {
  String errorMsg="";
  bool _isloading= false;

  @override void initState() {
    errorMsg=widget.errorMsg;
    super.initState();
  }
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
              _form(context),
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

  final TextEditingController _userNameController = TextEditingController();

  final TextEditingController _passwordController = TextEditingController();

  _form(context) {
    return SizedBox(
      width: 500,
      child: Column(
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
              ),
            ),
            obscureText: true,
          ),
          const SizedBox(height: 10),
          ElevatedButton(
            onPressed: () async {
              if(!_isloading){
                setState(() {
                  _isloading=true;
                });
                String userName = _userNameController.text.trim();
                String password = _passwordController.text.trim();
                //DEBUG 
                try{
                  bool hasAccess = await autenticateUser(userName,password);
                  if(hasAccess){
                    Navigator.push(context,
                    MaterialPageRoute(builder: (context) => const HomePage()));
                  }else {
                    setState(() {
                      errorMsg = "Usuário ou senha incorretos. Tente novamente.";
                    });
                  }
                }on CustomServerFullException catch (e) {
                  setState(() {
                      errorMsg = e.toString();
                  });
                }
                
                setState(() {
                  _isloading=false;
                });
              }
            },
            style: ElevatedButton.styleFrom(
              shape: const StadiumBorder(),
              backgroundColor: const Color(0xFFffc966),
              padding: const EdgeInsets.symmetric(vertical: 16),
            ),
            child: buttonContentBuilder(_isloading, const Color.fromARGB(255, 0, 0, 0))
          ),
          if(infoTextBox(errorMsg, -1)!=null)infoTextBox(errorMsg , -1)!
        ],
      ),
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
                      builder: (context) => const CreateAccount()));
            },
            child: const Text(
              "Cadastre-se já.",
              style: TextStyle(color: Color(0xFFffa430)),
            ))
      ],
    );
  }
}

SizedBox buttonContentBuilder(bool isloading, Color contrasteFormbg)=>
  SizedBox(
    child: Padding(padding: EdgeInsets.all(5), 
      child: isloading 
      ? CircularProgressIndicator(color: contrasteFormbg) 
      : Text('Acessar',style: TextStyle(fontSize: 20, color: contrasteFormbg)))
  );
