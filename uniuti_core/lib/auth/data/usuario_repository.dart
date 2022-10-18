part of '../../uniuti_core.dart';

abstract class UsuarioRepository implements Repository<Usuario> {
  Future<bool> performLogin(Usuario usuario);
  Future<bool> performRefreshToken(Usuario usuario);
}

class MockUsuarioRepository implements UsuarioRepository {
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
