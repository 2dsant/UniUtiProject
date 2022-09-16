import 'dart:math';

import 'package:uniuti/auth/domain/usuario.dart';
import 'package:uniuti/shared/data/repository.dart';
import 'package:uniuti/shared/data/uniuti_client.dart';

abstract class UsuarioRepository extends Repository<Usuario> {
  Future<bool> performLogin(Usuario usuario);
  Future<bool> performRefreshToken(Usuario usuario);
}

class MockUsuarioRepository extends UsuarioRepository {
  @override
  Future<Usuario?> byId(int id) async {
    return Usuario(id: -1, login: 'mock', senha: 'mock@123', token: '');
  }

  @override
  Future<List<Usuario>> getAll() {
    // TODO: implement getAll
    throw UnimplementedError();
  }

  @override
  Future<List<Usuario>> getMany(RepoFilter filter) {
    // TODO: implement getMany
    throw UnimplementedError();
  }

  @override
  Future<bool> performLogin(Usuario usuario) async {
    final val = Random().nextInt(2) == 1;
    return val;
  }

  @override
  Future<bool> performRefreshToken(Usuario usuario) {
    return performLogin(usuario);
  }
}

class RemoteUsuarioRepository extends UsuarioRepository {
  final UniUtiHttpClient client;

  RemoteUsuarioRepository(this.client);

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
