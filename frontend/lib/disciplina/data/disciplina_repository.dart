import '../../shared/data/repository.dart';
import '../domain/disciplina.dart';

abstract class DisciplinaRepository implements Repository<Disciplina> {}

class MockDisciplinaRepository implements DisciplinaRepository {
  @override
  Future<Disciplina> byId(int id) async {
    return Disciplina.fromMap({
      'id': id,
      'nome': 'DisciplinaMock',
      'descricao': 'Disciplina teste',
      'periodicidade': 'tempos em tempos',
      'cursos': [01]
    });
  }

  @override
  Future<List<Disciplina>> getAll() {
    // TODO: implement getAll
    throw UnimplementedError();
  }

  @override
  Future<List<Disciplina>> getMany(RepoFilter filter) async {
    return [
      await byId(0),
      await byId(1),
      await byId(2),
      await byId(3),
      await byId(4),
    ];
  }
}
  // TODO: Buscar na API/SQLite
