import 'dart:developer' as dev;
import 'dart:ui';
import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';
import 'package:google_fonts/google_fonts.dart';

import '../components/buttons.dart';
import '../styles.dart';

class RegisterScreen extends StatefulWidget {
  const RegisterScreen({Key? key}) : super(key: key);

  @override
  State<RegisterScreen> createState() => _RegisterScreenState();
}

class _RegisterScreenState extends State<RegisterScreen> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        decoration: BoxDecoration(gradient: UniUtiBgGradient()),
        child: Form(
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
                formField(placeholder: 'Email'),
                formField(placeholder: 'Confirme seu email'),
                formField(placeholder: 'Nome'),
                dropdown(placeholder: 'Curso'),
                formField(placeholder: 'Telefone'),
                formField(placeholder: 'Senha', password: true),
                Container(
                  margin: const EdgeInsets.only(top: 15),
                  child: UniUtiPrimaryButton(
                    title: 'Entrar',
                    onTap: () => dev.log('entrar'),
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
    return Container(
      margin: const EdgeInsets.only(bottom: 25),
      child: DropdownButtonFormField<int>(
        decoration: uniUtiInputDecoration(placeholder),
        // TODO: listagem de cursos a partir de uma lista da model Curso
        items: List.generate(
          5,
          (index) => DropdownMenuItem(
            child: Text(index.toString()),
            value: index,
          ),
        ),
        onChanged: (_) => dev.log('lol'),
      ),
    );
  }

  formField({required String placeholder, bool password = false}) {
    return Container(
      margin: const EdgeInsets.only(bottom: 25),
      child: TextFormField(
        textInputAction: TextInputAction.next,
        decoration: uniUtiInputDecoration(placeholder),
        obscureText: password,
      ),
    );
  }
}
