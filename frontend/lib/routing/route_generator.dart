import 'package:flutter/material.dart';
import 'package:uniuti/aluno/data/aluno_provider.dart';
import 'package:uniuti/aluno/presentation/dashboard.dart';
import 'package:uniuti/aluno/presentation/dashboard_store.dart';
import 'package:uniuti/auth/data/usuario_provider.dart';
import 'package:uniuti/auth/presentation/login.dart';
import 'package:uniuti/auth/presentation/register.dart';
import 'package:uniuti/auth/presentation/register_store.dart';
import 'package:uniuti/auth/presentation/signin.dart';
import 'package:uniuti/auth/presentation/splash.dart';
import 'package:uniuti/monitoria/presentation/monitorias.dart';
import 'package:uniuti/monitoria/presentation/monitorias_store.dart';

import '../monitoria/domain/monitoria.dart';
import '../monitoria/presentation/form_monitoria.dart';
import '../monitoria/presentation/form_monitoria_store.dart';
import '../monitoria/presentation/monitoria.dart';

class RouteGenerator {
  static Route<dynamic>? generateRoute(RouteSettings settings) {
    late WidgetBuilder builder;
    switch (settings.name) {
      case SplashScreen.route:
        builder = ((context) {
          return const SplashScreen();
        });
        break;
      case SigninScreen.route:
        builder = ((context) {
          return const SigninScreen();
        });
        break;
      case RegisterScreen.route:
        builder = (context) => RegisterScreen(
              controller: RegisterController(),
              aluno: AlunoProvider.of(context)!.aluno,
            );
        break;
      case LoginScreen.route:
        builder = (context) => LoginScreen(
              user: UsuarioProvider.of(context)!.usuario,
            );
        break;
      case MonitoriasScreen.route:
        builder =
            (context) => MonitoriasScreen(controller: MonitoriaController());
        break;
      case MonitoriaScreen.route:
        if (settings.arguments.runtimeType != Monitoria) return null;
        builder = (_) => MonitoriaScreen(
              monitoria: settings.arguments! as Monitoria,
            );
        break;
      case DashboardScreen.route:
        builder = (context) => DashboardScreen(
              controller: DashboardStore(),
              aluno: AlunoProvider.of(context)!.aluno,
            );
        break;
      case FormMonitoriaScreen.route:
        builder = (context) => FormMonitoriaScreen(
              controller: FormMonitoriaController(
                AlunoProvider.of(context)!.aluno,
              ),
            );
        break;
      default:
        return null;
    }
    return MaterialPageRoute(builder: builder);
  }

  static Route<dynamic>? unknownRoute(RouteSettings settings) {
    return MaterialPageRoute(
      builder: (_) => Scaffold(
        appBar: AppBar(title: const Text('Error')),
        body: const Center(
          child: Text('Pagina nao encontrada'),
        ),
      ),
    );
  }
}
