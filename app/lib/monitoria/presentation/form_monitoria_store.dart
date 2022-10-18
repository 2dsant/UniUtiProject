import 'package:uniuti_core/uniuti_core.dart';

class FormMonitoriaController {
  final _disciplinaRepos = <String, DisciplinaRepository>{
    'localDb': MockDisciplinaRepository(),
    'remote': MockDisciplinaRepository()
  };
  final Aluno _aluno;

  FormMonitoriaController(this._aluno);

  Future<List<Disciplina>> getDisciplinas() async {
    late List<Disciplina> disciplinas;
    for (var repo in _disciplinaRepos.values) {
      disciplinas = await repo.getMany(RepoFilter(
        property: 'disciplina',
        operation: FilterOperation.equals,
        value: _aluno.curso.toString(),
      ));
      if (disciplinas.isNotEmpty) {
        break;
      }
    }
    return disciplinas;
  }
}
