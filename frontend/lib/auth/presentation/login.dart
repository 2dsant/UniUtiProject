import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';

import '../../shared/presentation/buttons.dart';
import '../../shared/presentation/inputs.dart';
import '../../shared/presentation/styles.dart';
import '../domain/usuario.dart';

class LoginScreen extends StatefulWidget {
  const LoginScreen({Key? key, required this.user}) : super(key: key);
  final Usuario user;
  static const String route = '/login';

  @override
  _LoginScreenState createState() => _LoginScreenState();
}

class _LoginScreenState extends State<LoginScreen> {
  final _formKey = GlobalKey<FormState>();
  final _senhaController = TextEditingController();
  var _autoValidateMode = AutovalidateMode.disabled;

  @override
  Widget build(BuildContext context) {
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
                    save: (login) => widget.user.login = login ?? '',
                    valid: (login) => (login == null || login.isEmpty)
                        ? 'Login Inválido'
                        : null,
                  ),
                  UniUtiInput(
                    placeholder: 'Senha',
                    password: true,
                    controller: _senhaController,
                    save: (senha) => widget.user.senha = senha ?? '',
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
    Navigator.of(context).pushReplacementNamed('/dashboard');
  }
}
