import 'dart:convert';

import 'package:flutter/foundation.dart';

import 'curso.dart';

class Disciplina {
  int id;
  String nome;
  String descricao;
  String periodicidade;
  List<Curso> cursos;
  Disciplina({
    required this.id,
    required this.nome,
    required this.descricao,
    required this.periodicidade,
    required this.cursos,
  });

  Disciplina copyWith({
    int? id,
    String? nome,
    String? descricao,
    String? periodicidade,
    List<Curso>? cursos,
  }) {
    return Disciplina(
      id: id ?? this.id,
      nome: nome ?? this.nome,
      descricao: descricao ?? this.descricao,
      periodicidade: periodicidade ?? this.periodicidade,
      cursos: cursos ?? this.cursos,
    );
  }

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'nome': nome,
      'descricao': descricao,
      'periodicidade': periodicidade,
      'cursos': cursos.map((x) => x.toMap()).toList(),
    };
  }

  factory Disciplina.fromMap(Map<String, dynamic> map) {
    return Disciplina(
      id: map['id']?.toInt() ?? 0,
      nome: map['nome'] ?? '',
      descricao: map['descricao'] ?? '',
      periodicidade: map['periodicidade'] ?? '',
      cursos: List<Curso>.from(map['cursos']?.map((x) => Curso.fromMap(x))),
    );
  }

  String toJson() => json.encode(toMap());

  factory Disciplina.fromJson(String source) =>
      Disciplina.fromMap(json.decode(source));

  @override
  String toString() {
    return 'Disciplina(id: $id, nome: $nome, descricao: $descricao, periodicidade: $periodicidade, cursos: $cursos)';
  }

  @override
  bool operator ==(Object other) {
    if (identical(this, other)) return true;

    return other is Disciplina &&
        other.id == id &&
        other.nome == nome &&
        other.descricao == descricao &&
        other.periodicidade == periodicidade &&
        listEquals(other.cursos, cursos);
  }

  @override
  int get hashCode {
    return id.hashCode ^
        nome.hashCode ^
        descricao.hashCode ^
        periodicidade.hashCode ^
        cursos.hashCode;
  }
}
