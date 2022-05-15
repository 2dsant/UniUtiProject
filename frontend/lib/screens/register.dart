import 'dart:developer' as dev;
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
        padding: const EdgeInsets.fromLTRB(35, 175, 35, 130),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            SvgPicture.asset('assets/logo.svg'),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 10),
              child: Text(
                'Bora fazer teu registro? Preencha os dados abaixo e faça parte da comunidade.',
                style: TextStyle(
                  fontSize: 24,
                  fontFamily: GoogleFonts.inter().fontFamily,
                  color: Colors.white,
                ),
              ),
            ),
            const SizedBox(height: 32),
            UniUtiPrimaryButton(
              title: 'Entrar',
              onTap: () => dev.log('entrar'),
            ),
          ],
        ),
      ),
    );
  }
}
