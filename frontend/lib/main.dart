import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:uniuti/stores/dashboard_store.dart';
import 'package:uniuti/stores/monitorias_store.dart';
import 'models/models.dart';
import 'screens/screens.dart';

import 'stores/register_store.dart';
import 'styles.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    var _user = Usuario(id: -1, login: 'mock', senha: 'mock@123', token: '');
    final aluno = Aluno(id: -1, nome: 'Mock', usuario: _user)..addIdCurso(-1);
    return MaterialApp(
      title: 'UniUti',
      theme: uniUtiThemeData,
      scrollBehavior: const CupertinoScrollBehavior(),
      routes: {
        '/signin': (_) => const SigninScreen(),
        '/register': (_) => RegisterScreen(
              controller: RegisterController(),
              user: aluno,
            ),
        '/login': (_) => LoginScreen(user: aluno.usuario),
        '/monitorias': (_) =>
            MonitoriasScreen(controller: MonitoriaController()),
        '/dashboard': (_) => DashboardScreen(
              controller: DashboardStore(),
              aluno: aluno,
            ),
        '/monitoria': (_) => const MonitoriaScreen(),
      },
      home: const SplashScreen(),
    );
  }
}
