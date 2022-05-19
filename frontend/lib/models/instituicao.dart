import 'dart:convert';

import 'package:flutter/foundation.dart';

import 'models.dart';

class Instituicao {
  int id;
  String nome;
  List<Curso> cursos;
  List<Contato> contatos;
  Instituicao({
    required this.id,
    required this.nome,
    required this.cursos,
    required this.contatos,
  });

  Instituicao copyWith({
    int? id,
    String? nome,
    List<Curso>? cursos,
    List<Contato>? contatos,
  }) {
    return Instituicao(
      id: id ?? this.id,
      nome: nome ?? this.nome,
      cursos: cursos ?? this.cursos,
      contatos: contatos ?? this.contatos,
    );
  }

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'nome': nome,
      'cursos': cursos.map((x) => x.toMap()).toList(),
      'contatos': contatos.map((x) => x.toMap()).toList(),
    };
  }

  factory Instituicao.fromMap(Map<String, dynamic> map) {
    return Instituicao(
      id: map['id']?.toInt() ?? 0,
      nome: map['nome'] ?? '',
      cursos: List<Curso>.from(map['cursos']?.map((x) => Curso.fromMap(x))),
      contatos:
          List<Contato>.from(map['contatos']?.map((x) => Contato.fromMap(x))),
    );
  }

  String toJson() => json.encode(toMap());

  factory Instituicao.fromJson(String source) =>
      Instituicao.fromMap(json.decode(source));

  @override
  String toString() {
    return 'Instituicao(id: $id, nome: $nome, cursos: $cursos, contatos: $contatos)';
  }

  @override
  bool operator ==(Object other) {
    if (identical(this, other)) return true;

    return other is Instituicao &&
        other.id == id &&
        other.nome == nome &&
        listEquals(other.cursos, cursos) &&
        listEquals(other.contatos, contatos);
  }

  @override
  int get hashCode {
    return id.hashCode ^ nome.hashCode ^ cursos.hashCode ^ contatos.hashCode;
  }
}
