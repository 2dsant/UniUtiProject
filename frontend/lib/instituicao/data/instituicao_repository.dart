import '../../shared/data/repository.dart';
import '../domain/instituicao.dart';

abstract class InstituicaoRepository implements Repository<Instituicao> {}

class MockInstituicaoRepository implements InstituicaoRepository {
  Future<List<Instituicao>> byCurso(int id) async {
    return [
      (await byId(0))!,
      (await byId(1))!,
      (await byId(2))!,
      (await byId(3))!,
      (await byId(4))!,
    ];
  }

  @override
  Future<Instituicao?> byId(int id) async {
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
