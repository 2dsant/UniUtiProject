import 'package:uniuti_core/uniuti_core.dart';

import '../../shared/application/uniuti_client.dart';
import '../../shared/application/uniuti_client_mixin.dart';

class RemoteUsuarioRepository extends UniUtiHttpRemoteRepository
    implements UsuarioRepository {
  RemoteUsuarioRepository(UniUtiHttpClient client) : super(client);

  @override
  Future<bool> performRefreshToken(Usuario usuario) async {
    var response = await client.post(endpoint: '/refresh-login', body: {});
    if (response.statusCode >= 500) {
      throw RemoteClientException(response);
    }
    return response.body['token'];
  }

  @override
  Future<bool> performLogin(Usuario usuario) async {
    var response = await client.post(endpoint: '/LoginUser', body: {
      'email': usuario.login,
      'senha': usuario.senha,
    });
    if (response.statusCode >= 400) {
      false;
    }
    usuario.token = response.body['token'];
    return true;
  }

  @override
  Future<Usuario?> byId(int id) async {
    return null;
  }

  @override
  Future<List<Usuario>> getAll() async {
    return [];
  }

  @override
  Future<List<Usuario>> getMany(RepoFilter filter) async {
    return [];
  }
}
