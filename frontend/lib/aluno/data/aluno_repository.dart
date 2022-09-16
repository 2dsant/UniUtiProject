import 'package:uniuti/aluno/domain/aluno.dart';
import 'package:uniuti/shared/data/repository.dart';

import '../../auth/data/usuario_repository.dart';

abstract class AlunoRepository extends Repository<Aluno> {}

class MockAlunoRepository extends AlunoRepository {
  @override
  Future<Aluno?> byId(int id) async {
    final usuario = await MockUsuarioRepository().byId(-1);
    return Aluno(
      id: -1,
      nome: 'Mock',
      usuario: usuario!,
    )..addIdCurso(-1);
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
}
