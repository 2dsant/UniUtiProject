import 'dart:developer' as dev;
import 'dart:ui';

import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';
import 'package:get_it/get_it.dart';
import 'package:google_fonts/google_fonts.dart';

import '../repositories/curso_repository.dart';
import 'screens.dart';
import '../transicao.dart';
import '../components/buttons.dart';
import '../models/models.dart';
import '../styles.dart';

class RegisterScreen extends StatefulWidget {
  const RegisterScreen({Key? key}) : super(key: key);

  @override
  State<RegisterScreen> createState() => _RegisterScreenState();
}

class _RegisterScreenState extends State<RegisterScreen> {
  final _formKey = GlobalKey<FormState>();
  final _user = GetIt.I.get<Aluno>();
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        decoration: BoxDecoration(gradient: UniUtiBgGradient()),
        child: Form(
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
                formField(
                  placeholder: 'Nome',
                  save: (str) => _user.nome = str ?? '',
                ),
                formField(
                  placeholder: 'Telefone',
                  type: TextInputType.phone,
                  save: (str) => _user.contatos.add(
                    Contato(id: -1, contato: str!),
                  ),
                ),
                formField(
                  placeholder: 'Email',
                  type: TextInputType.emailAddress,
                  save: (str) => _user.usuario.login = str ?? '',
                ),
                formField(
                  placeholder: 'Confirme seu email',
                  type: TextInputType.emailAddress,
                ),
                formField(
                  placeholder: 'Senha',
                  password: true,
                  save: (str) => _user.usuario.senha = str ?? '',
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
      future: GetIt.I.get<CursoRepository>().getCursos(),
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

  formField(
      {required String placeholder,
      bool password = false,
      TextInputType? type,
      FormFieldSetter<String>? save}) {
    return Container(
      margin: const EdgeInsets.only(bottom: 25),
      child: TextFormField(
        textInputAction: TextInputAction.next,
        decoration: uniUtiInputDecoration(placeholder),
        obscureText: password,
        keyboardType: type,
        onSaved: save,
      ),
    );
  }

  _validateForm() {
    if (!_formKey.currentState!.validate()) {
      return;
    }
    _formKey.currentState!.save();
    dev.log(_user.toString());
    Navigator.of(context)
        .pushReplacement(CustomTransition(target: const SigninScreen()));
  }
}
