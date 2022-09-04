import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

import 'aluno/domain/aluno.dart';
import 'aluno/presentation/dashboard.dart';
import 'aluno/presentation/dashboard_store.dart';
import 'auth/domain/usuario.dart';
import 'auth/presentation/login.dart';
import 'auth/presentation/register.dart';
import 'auth/presentation/register_store.dart';
import 'auth/presentation/signin.dart';
import 'auth/presentation/splash.dart';
import 'monitoria/presentation/form_monitoria.dart';
import 'monitoria/presentation/form_monitoria_store.dart';
import 'monitoria/presentation/monitoria.dart';
import 'monitoria/presentation/monitorias.dart';
import 'monitoria/presentation/monitorias_store.dart';
import 'shared/presentation/styles.dart';

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
        '/formMonitoria': (_) =>
            FormMonitoriaScreen(controller: FormMonitoriaController(aluno)),
      },
      home: const SplashScreen(),
    );
  }
}
