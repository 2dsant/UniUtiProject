import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'screens/screens.dart';

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
      scrollBehavior: const CupertinoScrollBehavior(),
      routes: {
        '/signin': (_) => const SigninScreen(),
        '/register': (_) => const RegisterScreen(),
        '/login': (_) => const LoginScreen(),
        '/monitorias': (_) => const MonitoriasScreen(),
        '/dashboard': (_) => const DashboardScreen(),
        '/monitoria': (_) => const MonitoriaScreen(),
      },
      home: const SplashScreen(),
    );
  }
}
