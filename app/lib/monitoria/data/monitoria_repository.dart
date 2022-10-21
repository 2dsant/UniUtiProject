import 'package:http_client/http_client.dart';
import 'package:uniuti_core/uniuti_core.dart';

class MonitoriaRemoteRepository implements MonitoriaRepository {
  MonitoriaRemoteRepository(this.client);
  RemoteClient client;

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
