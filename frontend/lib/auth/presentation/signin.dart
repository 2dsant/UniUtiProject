import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import '../../shared/presentation/buttons.dart';
import '../../shared/presentation/styles.dart';

class SigninScreen extends StatefulWidget {
  const SigninScreen({Key? key}) : super(key: key);

  @override
  State<SigninScreen> createState() => _SigninScreenState();
}

class _SigninScreenState extends State<SigninScreen> {
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
            const Spacer(),
            UniUtiPrimaryButton(
              title: 'Entrar',
              onTap: () => Navigator.of(context).pushNamed('/login'),
            ),
            const SizedBox(height: 16),
            UniUtiSecondaryButton(
              title: 'Registrar',
              onTap: () => Navigator.of(context).pushNamed('/register'),
            ),
          ],
        ),
      ),
    );
  }
}
