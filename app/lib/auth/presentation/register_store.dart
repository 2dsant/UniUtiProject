import 'package:uniuti_core/uniuti_core.dart';

import '../../shared/application/uniuti_client.dart';

import '../../aluno/data/aluno_repository.dart';

class RegisterController {
  RegisterState state = RegisterInitial();
  final _cursoRepos = <String, CursoRepository>{
    'localDb': MockCursoRepository(),
    'remote': MockCursoRepository()
  };
  final _alunoRepos = <String, AlunoRepository>{
    'localDb': MockAlunoRepository(),
  };

  RegisterController(UniUtiHttpClient client) {
    _alunoRepos['remote'] = RemoteAlunoRepository(client);
  }

  Future<List<Curso>> getAllCursos() async {
    List<Curso> cursos = [];
    for (var repo in _cursoRepos.values) {
      cursos = await repo.getAll();
      if (cursos.isNotEmpty) {
        break;
      }
    }
    return cursos;
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
