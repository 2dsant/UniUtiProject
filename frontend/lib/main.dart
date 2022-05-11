import 'package:flutter/material.dart';
import 'screens/signin.dart';
import 'screens/splash.dart';

import 'styles.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'UniUti',
      theme: uniUtiThemeData,
      routes: {
        '/login': (_) => const LoginScreen(),
      },
      home: const SplashScreen(),
    );
  }
}
