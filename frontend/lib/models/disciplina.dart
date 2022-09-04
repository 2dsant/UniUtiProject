import 'dart:convert';

import 'package:flutter/foundation.dart';

import 'models.dart';

class Disciplina {
  int id;
  String nome;
  String descricao;
  String periodicidade;
  final List<int> _cursos = [];
  Disciplina({
    required this.id,
    required this.nome,
    required this.descricao,
    required this.periodicidade,
  });

  Disciplina copyWith({
    int? id,
    String? nome,
    String? descricao,
    String? periodicidade,
    List<int>? cursos,
  }) {
    return Disciplina(
      id: id ?? this.id,
      nome: nome ?? this.nome,
      descricao: descricao ?? this.descricao,
      periodicidade: periodicidade ?? this.periodicidade,
    )..setCursosId(cursos ?? _cursos);
  }

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'nome': nome,
      'descricao': descricao,
      'periodicidade': periodicidade,
      'cursos': _cursos,
    };
  }

  factory Disciplina.fromMap(Map<String, dynamic> map) {
    return Disciplina(
      id: map['id']?.toInt() ?? 0,
      nome: map['nome'] ?? '',
      descricao: map['descricao'] ?? '',
      periodicidade: map['periodicidade'] ?? '',
    )..setCursosId(map['cursos']);
  }

  String toJson() => json.encode(toMap());

  factory Disciplina.fromJson(String source) =>
      Disciplina.fromMap(json.decode(source));

  @override
  String toString() {
    return 'Disciplina(id: $id, nome: $nome, descricao: $descricao, periodicidade: $periodicidade, cursos: $_cursos)';
  }

  @override
  bool operator ==(Object other) {
    if (identical(this, other)) return true;

    return other is Disciplina &&
        other.id == id &&
        other.nome == nome &&
        other.descricao == descricao &&
        other.periodicidade == periodicidade &&
        listEquals(other._cursos, _cursos);
  }

  @override
  int get hashCode {
    return id.hashCode ^
        nome.hashCode ^
        descricao.hashCode ^
        periodicidade.hashCode ^
        _cursos.hashCode;
  }

  void setCursos(List<Curso> cursos) {
    cursos.map((c) => addCurso(c));
  }

  void setCursosId(List<int> cursos) {
    cursos.map((id) => addIdCurso(id));
  }

  void addCurso(Curso curso) {
    _cursos.add(curso.id);
  }

  void addIdCurso(int id) {
    _cursos.add(id);
  }
}
