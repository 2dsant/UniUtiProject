part of '../../uniuti_core.dart';

abstract class AlunoRepository implements Repository<Aluno> {
  Future<Aluno> performRegister(Aluno aluno);
}

class MockAlunoRepository implements AlunoRepository {
  @override
  Future<Aluno?> byId(int id) async {
    final usuario = await MockUsuarioRepository().byId(-1);
    final curso = await MockCursoRepository().byId(-1);
    final instituicao = await MockInstituicaoRepository().byId(-1);
    return Aluno(
      id: -1,
      nome: 'Mock',
      usuario: usuario!,
      celular: Contato('1234456789'),
      curso: curso!,
      instituicao: instituicao!,
    );
  }

  @override
  Future<List<Aluno>> getAll() {
    // TODO: implement getAll
    throw UnimplementedError();
  }

  @override
  Future<List<Aluno>> getMany(RepoFilter filter) {
    // TODO: implement getMany
    throw UnimplementedError();
  }

  @override
  Future<Aluno> performRegister(Aluno aluno) async {
    return aluno;
  }
}
