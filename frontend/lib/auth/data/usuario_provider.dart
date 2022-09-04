import 'package:flutter/material.dart';
import 'package:uniuti/auth/domain/usuario.dart';

@immutable
class UsuarioProvider extends InheritedWidget {
  const UsuarioProvider({
    Key? key,
    required this.usuario,
    required Widget child,
  }) : super(key: key, child: child);

  static UsuarioProvider? of(BuildContext context) {
    return context.dependOnInheritedWidgetOfExactType<UsuarioProvider>();
  }

  final Usuario usuario;

  @override
  bool updateShouldNotify(UsuarioProvider oldWidget) {
    return true;
  }
}
