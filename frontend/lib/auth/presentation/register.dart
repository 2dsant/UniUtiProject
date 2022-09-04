import 'dart:developer' as dev;

import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:uniuti/auth/presentation/register_store.dart';

import '../../aluno/domain/aluno.dart';
import '../../contato/domain/contato.dart';
import '../../curso/domain/curso.dart';
import '../../shared/presentation/buttons.dart';
import '../../shared/presentation/inputs.dart';
import '../../shared/presentation/styles.dart';

class RegisterScreen extends StatefulWidget {
  static const String route = '/register';

  const RegisterScreen({Key? key, required this.controller, required this.aluno})
      : super(key: key);
  final RegisterController controller;
  final Aluno aluno;
  @override
  State<RegisterScreen> createState() => _RegisterScreenState();
}

class _RegisterScreenState extends State<RegisterScreen> {
  final _formKey = GlobalKey<FormState>();
  final _emailController = TextEditingController();

  var _autoValidMode = AutovalidateMode.disabled;
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        decoration: BoxDecoration(gradient: UniUtiBgGradient()),
        child: Form(
          autovalidateMode: _autoValidMode,
          key: _formKey,
          child: SingleChildScrollView(
            padding: const EdgeInsets.fromLTRB(35, 125, 35, 80),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              crossAxisAlignment: CrossAxisAlignment.stretch,
              children: [
                SvgPicture.asset('assets/logo.svg'),
                Container(
                  padding: const EdgeInsets.symmetric(horizontal: 10),
                  margin: const EdgeInsets.only(bottom: 40),
                  child: Text(
                    'Bora fazer teu registro? Preencha os dados abaixo e faça parte da comunidade.',
                    style: TextStyle(
                      fontSize: 18,
                      fontFamily: GoogleFonts.inter().fontFamily,
                      color: Colors.white,
                    ),
                  ),
                ),
                dropdown(placeholder: 'Curso'),
                UniUtiInput(
                  placeholder: 'Nome',
                  save: (str) => widget.aluno.nome = str ?? '',
                  valid: (text) => (text == null ||
                          text.isEmpty ||
                          (text.split(' ').length < 2))
                      ? 'Nome inválido'
                      : null,
                ),
                UniUtiInput(
                  placeholder: 'Telefone',
                  type: TextInputType.phone,
                  save: (str) => widget.aluno.addContato(
                    Contato(id: -1, contato: str!),
                  ),
                  valid: (text) {
                    var rgx = RegExp(r'.*\D+.*');
                    return (text == null ||
                            rgx.hasMatch(text) ||
                            text.length < 11)
                        ? 'Telefone inválido'
                        : null;
                  },
                ),
                UniUtiInput(
                  placeholder: 'Email',
                  type: TextInputType.emailAddress,
                  controller: _emailController,
                  save: (str) => widget.aluno.usuario.login = str ?? '',
                  valid: (text) {
                    var rgx = RegExp(r'[a-zA-Z0-9.]+@[a-z]+\.[a-z.]');
                    if (text == null || text.isEmpty || !(rgx.hasMatch(text))) {
                      return 'Email inválido';
                    }
                    return null;
                  },
                ),
                UniUtiInput(
                  placeholder: 'Confirme seu email',
                  type: TextInputType.emailAddress,
                  valid: (text) {
                    var rgx = RegExp(r'[a-zA-Z0-9.]+@[a-z]+\.[a-z.]');
                    if (text == null || text.isEmpty || !(rgx.hasMatch(text))) {
                      return 'Email inválido';
                    } else if (_emailController.text != text) {
                      return 'Email não corresponde';
                    }
                    return null;
                  },
                ),
                UniUtiInput(
                  placeholder: 'Senha',
                  password: true,
                  last: true,
                  editingComplete: _validateForm,
                  save: (str) => widget.aluno.usuario.senha = str ?? '',
                  valid: (text) => (text == null || text.length < 8)
                      ? 'Senha deve ter mais que 8 caracteres'
                      : null,
                ),
                Container(
                  margin: const EdgeInsets.only(top: 15),
                  child: UniUtiPrimaryButton(
                    title: 'Entrar',
                    onTap: _validateForm,
                  ),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }

  dropdown({required String placeholder}) {
    return FutureBuilder<List<Curso>>(
      future: widget.controller.getAllCursos(),
      builder: (BuildContext context, AsyncSnapshot<List<Curso>> snapshot) {
        var items = 0;
        if (snapshot.hasData) items = snapshot.data!.length;
        return Container(
          margin: const EdgeInsets.only(bottom: 25),
          child: DropdownButtonFormField<Curso>(
            decoration: uniUtiInputDecoration(placeholder),
            items: List.generate(
              items,
              (index) => DropdownMenuItem(
                child: Text(snapshot.data![index].nome),
                value: snapshot.data![index],
              ),
            ),
            onChanged: (sel) => dev.log(sel.toString()),
          ),
        );
      },
    );
  }

  _validateForm() {
    if (!_formKey.currentState!.validate()) {
      setState(() {
        _autoValidMode = AutovalidateMode.onUserInteraction;
      });
      return;
    }
    _formKey.currentState!.save();
    dev.log(widget.aluno.toString());
    Navigator.of(context).pushReplacementNamed('/signin');
  }
}
