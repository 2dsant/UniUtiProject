part of '../../uniuti_core.dart';

abstract class UsuarioParser {
  static Map<String, dynamic> toMap(Usuario usuario) {
    return {
      'id': usuario.id,
      'login': usuario.login,
      'senha': usuario.senha,
      'token': usuario.token,
    };
  }

  static Usuario fromMap(Map<String, dynamic> map) {
    return Usuario(
      id: map['id']?.toInt() ?? 0,
      login: map['login'] ?? '',
      senha: map['senha'] ?? '',
      token: map['token'] ?? '',
    );
  }

  static String toJson(Usuario usuario) => json.encode(toMap(usuario));

  static Usuario fromJson(String source) => fromMap(json.decode(source));
}
