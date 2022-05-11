import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import '../styles.dart';

class SplashScreen extends StatefulWidget {
  const SplashScreen({Key? key}) : super(key: key);

  @override
  State<SplashScreen> createState() => _SplashScreenState();
}

class _SplashScreenState extends State<SplashScreen> {
  Future<void> initializer() async {
    await Future.delayed(const Duration(milliseconds: 2500));
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
                () => Navigator.pushReplacementNamed(context, '/login'),
              );
            }
            return Center(child: SvgPicture.asset('assets/logo.svg'));
          },
        ),
      ),
    );
  }
}
