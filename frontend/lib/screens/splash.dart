import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:get_it/get_it.dart';
import '../models/models.dart';
import 'signin.dart';
import '../transicao.dart';
import '../styles.dart';

class SplashScreen extends StatefulWidget {
  const SplashScreen({Key? key}) : super(key: key);

  @override
  State<SplashScreen> createState() => _SplashScreenState();
}

class _SplashScreenState extends State<SplashScreen> {
  Future<void> initializer() async {
    await Future.delayed(const Duration(milliseconds: 2000));
    GetIt.I.registerSingleton(Usuario(id: 1, login: '', senha: '', token: ''));
    await GetIt.I.allReady();
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
