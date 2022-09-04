import 'dart:convert';

import 'package:flutter/foundation.dart';
import 'models.dart';

class Aluno {
  int id;
  String nome;
  final List<int> _cursos = [];
  final List<int> _contatos = [];
  Usuario usuario;
  int? instituicaoId;
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
      'cursos': _cursos,
      'contatos': _contatos,
      'usuario': usuario.toMap(),
    };
  }

  factory Aluno.fromMap(Map<String, dynamic> map) {
    return Aluno(
      id: map['id']?.toInt() ?? 0,
      nome: map['nome'] ?? '',
      usuario: Usuario.fromMap(map['usuario']),
    )
      ..setContatosId(map['contatos']!)
      ..setCursosId(map['cursos']);
  }

  String toJson() => json.encode(toMap());

  factory Aluno.fromJson(String source) => Aluno.fromMap(json.decode(source));

  @override
  String toString() {
    return 'Aluno(id: $id, nome: $nome, cursos: $_cursos, contatos: $_contatos, usuario: $usuario)';
  }

  @override
  bool operator ==(Object other) {
    if (identical(this, other)) return true;

    return other is Aluno &&
        other.id == id &&
        other.nome == nome &&
        listEquals(other._cursos, _cursos) &&
        listEquals(other._contatos, _contatos) &&
        other.usuario == usuario;
  }

  @override
  int get hashCode {
    return id.hashCode ^
        nome.hashCode ^
        _cursos.hashCode ^
        _contatos.hashCode ^
        usuario.hashCode;
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

  List<int> getCursos() => _cursos;

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

  List<int> getContatos() => _contatos;
}
