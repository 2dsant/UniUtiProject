import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';

import '../../shared/presentation/styles.dart';
import '../../shared/presentation/transicao.dart';
import 'signin.dart';

class SplashScreen extends StatefulWidget {
  const SplashScreen({Key? key}) : super(key: key);

  @override
  State<SplashScreen> createState() => _SplashScreenState();
}

class _SplashScreenState extends State<SplashScreen> {
  Future<void> initializer() async {
    await Future.delayed(const Duration(milliseconds: 2000));
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        decoration: BoxDecoration(
          gradient: UniUtiBgGradient(),
        ),
        child: FutureBuilder(
          future: initializer(),
          builder: (context, snap) {
            if (snap.connectionState == ConnectionState.done) {
              Future.microtask(
                () => Navigator.of(context).pushReplacement(
                  CustomTransition(
                    target: const SigninScreen(),
                    miliseconds: 1000,
                    transitionsBuilder: CustomTransition.fade,
                    barrierColor: false,
                  ),
                ),
              );
            }
            return Center(child: SvgPicture.asset('assets/logo.svg'));
          },
        ),
      ),
    );
  }
}
