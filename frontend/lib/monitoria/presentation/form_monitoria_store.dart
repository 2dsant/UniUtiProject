import '../../aluno/domain/aluno.dart';
import '../../disciplina/data/disciplina_repository.dart';
import '../../disciplina/domain/disciplina.dart';
import '../../shared/data/repository.dart';

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
        value: _aluno.getCursos().first.toString(),
      ));
      if (disciplinas.isNotEmpty) {
        break;
      }
    }
    return disciplinas;
  }
}
