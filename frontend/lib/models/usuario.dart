import 'dart:convert';

class Usuario {
  int id;
  String login;
  String senha;
  String token;
  Usuario({
    required this.id,
    required this.login,
    required this.senha,
    required this.token,
  });
  // List<Papel> papeis;

  Usuario copyWith({
    int? id,
    String? login,
    String? senha,
    String? token,
  }) {
    return Usuario(
      id: id ?? this.id,
      login: login ?? this.login,
      senha: senha ?? this.senha,
      token: token ?? this.token,
    );
  }

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'login': login,
      'senha': senha,
      'token': token,
    };
  }

  factory Usuario.fromMap(Map<String, dynamic> map) {
    return Usuario(
      id: map['id']?.toInt() ?? 0,
      login: map['login'] ?? '',
      senha: map['senha'] ?? '',
      token: map['token'] ?? '',
    );
  }

  String toJson() => json.encode(toMap());

  factory Usuario.fromJson(String source) => Usuario.fromMap(json.decode(source));

  @override
  String toString() {
    return 'Usuario(id: $id, login: $login, senha: $senha, token: $token)';
  }

  @override
  bool operator ==(Object other) {
    if (identical(this, other)) return true;
  
    return other is Usuario &&
      other.id == id &&
      other.login == login &&
      other.senha == senha &&
      other.token == token;
  }

  @override
  int get hashCode {
    return id.hashCode ^
      login.hashCode ^
      senha.hashCode ^
      token.hashCode;
  }
}
