import 'package:uniuti/shared/data/repository.dart';

import '../domain/curso.dart';

abstract class CursoRepository extends Repository<Curso> {}

class MockCursoRepository extends CursoRepository {
  static late final MockCursoRepository _instance =
      MockCursoRepository._internal();
  MockCursoRepository._internal();
  factory MockCursoRepository() => _instance;

  @override
  Future<List<Curso>> getAll() async {
    return [
      Curso(
        id: 01,
        nome: 'ADS',
        duracao: 'SIM',
        instituicao: -1,
      ),
      Curso(
        id: 02,
        nome: 'ADM',
        duracao: 'SIM',
        instituicao: -1,
      ),
    ];
  }

  @override
  Future<Curso> byId(int id) async {
    return Curso(id: id, nome: 'Curso', duracao: '1', instituicao: -1);
  }

  @override
  Future<List<Curso>> getMany(RepoFilter filter) {
    // TODO: implement getMany
    throw UnimplementedError();
  }
}
