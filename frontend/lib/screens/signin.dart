import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:google_fonts/google_fonts.dart';
import '../components/buttons.dart'
    show UniUtiPrimaryButton, UniUtiSecondaryButton;
import '../styles.dart' show UniUtiBgGradient;

class LoginScreen extends StatefulWidget {
  const LoginScreen({Key? key}) : super(key: key);

  @override
  State<LoginScreen> createState() => _LoginScreenState();
}

class _LoginScreenState extends State<LoginScreen> {
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
              padding: const EdgeInsets.symmetric(horizontal: 60),
              child: Text(
                'Sua vida acadêmica pode ser mais fácil.',
                style: TextStyle(
                  fontSize: 24,
                  fontFamily: GoogleFonts.inter().fontFamily,
                  color: Colors.white,
                ),
              ),
            ),
            const Spacer(),
            UniUtiPrimaryButton(
              title: 'Entrar',
              onTap: () => print('entrar'),
            ),
            const SizedBox(height: 16),
            UniUtiSecondaryButton(
              title: 'Registrar',
              onTap: () => print('registrar'),
            ),
          ],
        ),
      ),
    );
  }
}
