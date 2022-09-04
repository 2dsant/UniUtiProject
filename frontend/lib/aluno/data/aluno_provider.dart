import 'package:flutter/material.dart';

import '../domain/aluno.dart';

@immutable
class AlunoProvider extends InheritedWidget {
  const AlunoProvider({
    Key? key,
    required this.aluno,
    required Widget child,
  }) : super(key: key, child: child);

  static AlunoProvider? of(BuildContext context) {
    return context.dependOnInheritedWidgetOfExactType<AlunoProvider>();
  }

  final Aluno aluno;

  @override
  bool updateShouldNotify(AlunoProvider oldWidget) {
    return true;
  }
}
