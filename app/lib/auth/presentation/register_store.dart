import 'dart:collection';

import 'package:http_client/http_client.dart';
import 'package:uniuti_core/uniuti_core.dart';

import '../../aluno/data/aluno_repository.dart';
import '../../curso/data/curso_repository.dart';

class RegisterController {
  RegisterState state = RegisterInitial();
  final _cursoRepos = <String, CursoRepository>{
    'localDb': MockCursoRepository(),
  };
  final _alunoRepos = <String, AlunoRepository>{
    'localDb': MockAlunoRepository(),
  };

  RegisterController(RemoteClient client) {
    _alunoRepos['remote'] = RemoteAlunoRepository(client);
    _cursoRepos['remote'] = RemoteCursoRepository(client);
  }

  Future<List<Curso>> getAllCursos() async {
    List<Curso> cursos = [];
    return await ((_cursoRepos['remote']! as RemoteCursoRepository).getAll());
    // return cursos;
  }

  Future<RegisterState> register(Aluno aluno) async {
    final registered = await _alunoRepos['remote']!.performRegister(aluno);
    return RegisterSuccess(registered);
  }
}

abstract class RegisterState {}

class RegisterSuccess implements RegisterState {
  final Aluno aluno;

  RegisterSuccess(this.aluno);
}

class RegisterFail implements RegisterState {
  final String message;

  RegisterFail(this.message);
}

class RegisterInitial implements RegisterState {}
