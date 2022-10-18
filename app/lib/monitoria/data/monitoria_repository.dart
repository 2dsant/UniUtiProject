import '../../shared/application/uniuti_client_mixin.dart';
import 'package:uniuti_core/uniuti_core.dart';

class MonitoriaRemoteRepository extends UniUtiHttpRemoteRepository
    implements MonitoriaRepository {
  MonitoriaRemoteRepository(super.client);

  @override
  Future<Monitoria?> byId(int id) {
    // TODO: implement byId
    throw UnimplementedError();
  }

  @override
  Future<List<Monitoria>> getAll() {
    // TODO: implement getAll
    throw UnimplementedError();
  }

  @override
  Future<List<Monitoria>> getMany(RepoFilter filter) {
    // TODO: implement getMany
    throw UnimplementedError();
  }
}
