import 'package:uniuti/shared/data/repository.dart';

import '../domain/disciplina.dart';

abstract class DisciplinaRepository extends Repository<Disciplina> {}

class MockDisciplinaRepository extends DisciplinaRepository {
  static late final MockDisciplinaRepository _instance =
      MockDisciplinaRepository._internal();
  MockDisciplinaRepository._internal();
  factory MockDisciplinaRepository() => _instance;

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
