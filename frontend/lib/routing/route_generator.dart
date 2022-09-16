import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../aluno/presentation/dashboard.dart';
import '../aluno/presentation/dashboard_store.dart';
import '../auth/presentation/login.dart';
import '../auth/presentation/register.dart';
import '../auth/presentation/register_store.dart';
import '../auth/presentation/signin.dart';
import '../auth/presentation/splash.dart';
import '../monitoria/domain/monitoria.dart';
import '../monitoria/presentation/monitorias.dart';
import '../monitoria/presentation/monitorias_store.dart';
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
              aluno: context.read(),
            );
        break;
      case LoginScreen.route:
        builder = (context) => LoginScreen(user: context.read());
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
            controller: DashboardStore(), aluno: context.read());
        break;
      case FormMonitoriaScreen.route:
        builder = (context) => FormMonitoriaScreen(
              controller: FormMonitoriaController(context.read()),
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
