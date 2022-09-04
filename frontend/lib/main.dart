import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

import 'aluno/data/aluno_provider.dart';
import 'aluno/domain/aluno.dart';
import 'auth/data/usuario_provider.dart';
import 'auth/domain/usuario.dart';
import 'routing/route_generator.dart';
import 'shared/presentation/styles.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    final usuario =
        Usuario(id: -1, login: 'mock', senha: 'mock@123', token: '');
    return AlunoProvider(
      aluno: Aluno(
        id: -1,
        nome: 'Mock',
        usuario: usuario,
      )..addIdCurso(-1),
      child: UsuarioProvider(
        usuario: usuario,
        child: MaterialApp(
          title: 'UniUti',
          theme: uniUtiThemeData,
          scrollBehavior: const CupertinoScrollBehavior(),
          onGenerateRoute: RouteGenerator.generateRoute,
          onUnknownRoute: RouteGenerator.unknownRoute,
        ),
      ),
    );
  }
}
