import '../../shared/application/uniuti_client_mixin.dart';

import 'package:uniuti_core/uniuti_core.dart';

class DisciplinaRemoteRepository extends UniUtiHttpRemoteRepository
    implements DisciplinaRepository {
  DisciplinaRemoteRepository(super.client);

  @override
  Future<Disciplina?> byId(int id) {
    // TODO: implement byId
    throw UnimplementedError();
  }

  @override
  Future<List<Disciplina>> getAll() {
    // TODO: implement getAll
    throw UnimplementedError();
  }

  @override
  Future<List<Disciplina>> getMany(RepoFilter filter) {
    // TODO: implement getMany
    throw UnimplementedError();
  }
}
