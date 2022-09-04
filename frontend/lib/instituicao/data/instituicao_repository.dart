import 'package:uniuti/shared/data/repository.dart';

import '../domain/instituicao.dart';

abstract class InstituicaoRepository extends Repository<Instituicao> {}

class MockInstituicaoRepository extends InstituicaoRepository {
  static late final MockInstituicaoRepository _instance =
      MockInstituicaoRepository._internal();
  MockInstituicaoRepository._internal();
  factory MockInstituicaoRepository() => _instance;
  // TODO: Buscar na API/SQLite
  Future<List<Instituicao>> byCurso(int id) async {
    return [
      await byId(0),
      await byId(1),
      await byId(2),
      await byId(3),
      await byId(4),
    ];
  }

  @override
  Future<Instituicao> byId(int id) async {
    return Instituicao(
      id: id,
      nome: 'InstituicaoMock',
    );
  }

  @override
  Future<List<Instituicao>> getAll() {
    // TODO: implement getAll
    throw UnimplementedError();
  }

  @override
  Future<List<Instituicao>> getMany(RepoFilter filter) {
    // TODO: implement getMany
    throw UnimplementedError();
  }
}
