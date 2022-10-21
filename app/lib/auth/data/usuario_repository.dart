import 'package:http_client/http_client.dart';
import 'package:uniuti_core/uniuti_core.dart';

class RemoteUsuarioRepository implements UsuarioRepository {
  RemoteUsuarioRepository(this.client);
  RemoteClient client;

  @override
  Future<bool> performRefreshToken(Usuario usuario) async {
    var response = await client.post('/refresh-login', body: {});
    if (response.statusCode >= 500) {
      throw RemoteClientException(response.reasonPhrase ?? 'Erro inesperado!');
    }
    return response.body['token'];
  }

  @override
  Future<bool> performLogin(Usuario usuario) async {
    var response = await client.post(
      '/LoginUser',
      body: {'email': usuario.login, 'senha': usuario.senha},
    );
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
