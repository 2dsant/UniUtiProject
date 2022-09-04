import 'dart:convert';

import 'package:flutter/foundation.dart';

import 'models.dart';

class Instituicao {
  int id;
  String nome;
  final List<int> _cursos = [];
  final List<int> _contatos = [];
  Instituicao({
    required this.id,
    required this.nome,
  });

  Instituicao copyWith({
    int? id,
    String? nome,
    List<int>? cursos,
    List<int>? contatos,
  }) {
    return Instituicao(
      id: id ?? this.id,
      nome: nome ?? this.nome,
    )
      ..setContatosId(contatos ?? _contatos)
      ..setCursosId(cursos ?? _cursos);
  }

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'nome': nome,
      'cursos': _cursos,
      'contatos': _contatos,
    };
  }

  factory Instituicao.fromMap(Map<String, dynamic> map) {
    return Instituicao(
      id: map['id']?.toInt() ?? 0,
      nome: map['nome'] ?? '',
    )
      ..setContatosId(map['contatos']!)
      ..setCursosId(map['cursos']);
  }

  String toJson() => json.encode(toMap());

  factory Instituicao.fromJson(String source) =>
      Instituicao.fromMap(json.decode(source));

  @override
  String toString() {
    return 'Instituicao(id: $id, nome: $nome, cursos: $_cursos, contatos: $_contatos)';
  }

  @override
  bool operator ==(Object other) {
    if (identical(this, other)) return true;

    return other is Instituicao &&
        other.id == id &&
        other.nome == nome &&
        listEquals(other._cursos, _cursos) &&
        listEquals(other._contatos, _contatos);
  }

  @override
  int get hashCode {
    return id.hashCode ^ nome.hashCode ^ _cursos.hashCode ^ _contatos.hashCode;
  }

  void setCursosId(List<int> cursos) {
    cursos.map((id) => _cursos.add(id));
  }

  void setCursos(List<Curso> cursos) {
    for (var curso in cursos) {
      _cursos.add(curso.id);
    }
  }

  void addCurso(Curso curso) {
    _cursos.add(curso.id);
  }

  void addIdCurso(int id) {
    _cursos.add(id);
  }

  void setContatosId(List<int> contatos) {
    contatos.map((id) => addIdContato(id));
  }

  void setContatos(List<Contato> contatos) {
    contatos.map((id) => addContato(id));
  }

  void addContato(Contato contato) {
    _contatos.add(contato.id);
  }

  void addIdContato(int id) {
    _contatos.add(id);
  }
}
