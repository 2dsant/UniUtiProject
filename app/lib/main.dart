import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:uniuti/shared/application/uniuti_client.dart';
import 'package:uniuti_core/uniuti_core.dart';

import 'routing/route_generator.dart';
import 'shared/presentation/styles.dart';

Future<void> main() async {
  final aluno = await MockAlunoRepository().byId(-1);
  if (aluno == null) {
    throw Exception('Failed to initialize Aluno');
  }
  runApp(MyApp(
    aluno: aluno,
  ));
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key, required this.aluno}) : super(key: key);
  final Aluno aluno;

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    final client = UniUtiHttpClient(usuario: aluno.usuario!, version: 'v1');
    return MultiProvider(
      providers: [
        Provider<Aluno>(create: (_) => aluno),
        Provider<Usuario>(create: (_) => aluno.usuario!),
        Provider<UniUtiHttpClient>(create: (_) => client),
      ],
      child: MaterialApp(
        title: 'UniUti',
        theme: uniUtiThemeData,
        scrollBehavior: const CupertinoScrollBehavior(),
        onGenerateRoute: RouteGenerator.generateRoute,
        onUnknownRoute: RouteGenerator.unknownRoute,
      ),
    );
  }
}
