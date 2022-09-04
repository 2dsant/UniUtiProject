import '../models/models.dart';
import '../repositories/repositories.dart';

class RegisterController {
  final _cursoRepos = <String, CursoRepository>{
    'localDb': MockCursoRepository(),
    'remote': MockCursoRepository()
  };

  Future<List<Curso>> getAllCursos() async {
    List<Curso> cursos = [];
    for (var repo in _cursoRepos.values) {
      cursos = await repo.getAll();
      if (repo.lastStatus == LastStatus.notFound) {
        break;
      }
    }
    return cursos;
  }
}
