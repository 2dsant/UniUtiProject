import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';
import 'package:get_it/get_it.dart';
import 'package:uniuti/components/inputs.dart';
import 'package:uniuti/models/usuario.dart';

import '../components/buttons.dart';
import '../styles.dart';
import '../transicao.dart';
import 'screens.dart';

class LoginScreen extends StatefulWidget {
  const LoginScreen({Key? key}) : super(key: key);

  @override
  _LoginScreenState createState() => _LoginScreenState();
}

class _LoginScreenState extends State<LoginScreen> {
  final _formKey = GlobalKey<FormState>();
  final _senhaController = TextEditingController();
  var _autoValidateMode = AutovalidateMode.disabled;

  @override
  Widget build(BuildContext context) {
    var _user = GetIt.I.get<Usuario>();
    return Scaffold(
      body: Form(
        key: _formKey,
        autovalidateMode: _autoValidateMode,
        child: Container(
          decoration: BoxDecoration(gradient: UniUtiBgGradient()),
          padding: const EdgeInsets.fromLTRB(35, 0, 35, 0),
          child: SingleChildScrollView(
            child: Container(
              constraints: BoxConstraints(
                maxHeight: MediaQuery.of(context).size.height,
              ),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                crossAxisAlignment: CrossAxisAlignment.stretch,
                children: [
                  SvgPicture.asset('assets/logo.svg'),
                  const Padding(
                    padding: EdgeInsets.symmetric(horizontal: 30),
                    child: Text(
                      'Sua vida acadêmica pode ser mais fácil.',
                      style: TextStyle(
                        fontSize: 18,
                        color: Colors.white,
                      ),
                    ),
                  ),
                  const SizedBox(height: 148),
                  UniUtiInput(
                    placeholder: 'Login',
                    save: (login) => _user.login = login ?? '',
                    valid: (login) => (login == null || login.isEmpty)
                        ? 'Login Inválido'
                        : null,
                  ),
                  UniUtiInput(
                    placeholder: 'Senha',
                    password: true,
                    controller: _senhaController,
                    save: (senha) => _user.senha = senha ?? '',
                    valid: (senha) =>
                        (senha == null || senha.isEmpty || senha.length < 9)
                            ? 'Senha Inválida'
                            : null,
                    last: true,
                    editingComplete: _validateInputs,
                  ),
                  UniUtiPrimaryButton(
                    title: 'Entrar',
                    onTap: _validateInputs,
                  ),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }

  void _validateInputs() {
    if (!_formKey.currentState!.validate()) {
      _senhaController.clear();
      setState(() {
        _autoValidateMode = AutovalidateMode.onUserInteraction;
      });
      return;
    }
    Navigator.of(context).pushReplacement(
      // TODO: Redirecionar para tela principal
      CustomTransition(target: const SigninScreen()),
    );
  }
}
