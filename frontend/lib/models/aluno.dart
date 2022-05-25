import 'dart:convert';

import 'package:flutter/foundation.dart';

import 'models.dart';

class Aluno {
  int id;
  String nome;
  List<Curso> cursos = [];
  List<Contato> contatos = [];
  Usuario usuario;
  Aluno({
    required this.id,
    required this.nome,
    required this.usuario,
  });

  Aluno copyWith({
    int? id,
    String? nome,
    List<Curso>? cursos,
    List<Contato>? contatos,
    Usuario? usuario,
  }) {
    return Aluno(
      id: id ?? this.id,
      nome: nome ?? this.nome,
      usuario: usuario ?? this.usuario,
    );
  }

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'nome': nome,
      'cursos': cursos.map((x) => x.toMap()).toList(),
      'contatos': contatos.map((x) => x.toMap()).toList(),
      'usuario': usuario.toMap(),
    };
  }

  factory Aluno.fromMap(Map<String, dynamic> map) {
    return Aluno(
      id: map['id']?.toInt() ?? 0,
      nome: map['nome'] ?? '',
      usuario: Usuario.fromMap(map['usuario']),
    )
      ..cursos.addAll(
        List<Curso>.from(map['cursos']?.map((x) => Curso.fromMap(x))),
      )
      ..contatos.addAll(
        List<Contato>.from(map['contatos']?.map((x) => Contato.fromMap(x))),
      );
  }

  String toJson() => json.encode(toMap());

  factory Aluno.fromJson(String source) => Aluno.fromMap(json.decode(source));

  @override
  String toString() {
    return 'Aluno(id: $id, nome: $nome, cursos: $cursos, contatos: $contatos, usuario: $usuario)';
  }

  @override
  bool operator ==(Object other) {
    if (identical(this, other)) return true;

    return other is Aluno &&
        other.id == id &&
        other.nome == nome &&
        listEquals(other.cursos, cursos) &&
        listEquals(other.contatos, contatos) &&
        other.usuario == usuario;
  }

  @override
  int get hashCode {
    return id.hashCode ^
        nome.hashCode ^
        cursos.hashCode ^
        contatos.hashCode ^
        usuario.hashCode;
  }
}
