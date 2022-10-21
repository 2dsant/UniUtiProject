import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:http_client/http_client.dart';
import 'package:uniuti_core/uniuti_core.dart';

import 'auth/data/usuario_repository.dart';
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

class MyApp extends StatefulWidget {
  const MyApp({Key? key, required this.aluno}) : super(key: key);
  final Aluno aluno;

  @override
  State<MyApp> createState() => _MyAppState();
}

class _MyAppState extends State<MyApp> {
  late final RemoteClientImpl client;

  @override
  void initState() {
    super.initState();
    client = RemoteClientImpl(host: 'uniuti.azurewebsites.net/api');
  }

  @override
  void dispose() {
    client.close();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return MultiProvider(
      providers: [
        Provider<Aluno>(create: (_) => widget.aluno),
        Provider<Usuario>(create: (_) => widget.aluno.usuario!),
        Provider<RemoteClient>(create: (_) => client),
        Provider<UsuarioRepository>(
          create: (_) {
            final repo = RemoteUsuarioRepository(client);
            client.addInteceptor(AuthInterceptor(
                getToken: () async => widget.aluno.usuario!.token));
            client.setRetryPolicy(RetryPolicyImpl(
                () async => repo.performLogin(widget.aluno.usuario!)));
            return repo;
          },
        )
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
