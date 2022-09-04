import 'dart:convert';

import 'package:flutter/foundation.dart';

import 'models.dart';

class Curso {
  int id;
  String nome;
  String duracao;
  int instituicao;
  final List<int> _disciplinas = [];
  Curso({
    required this.id,
    required this.nome,
    required this.duracao,
    required this.instituicao,
  });

  Curso copyWith({
    int? id,
    String? nome,
    String? duracao,
    int? instituicao,
    List<Disciplina>? disciplinas,
  }) {
    return Curso(
      id: id ?? this.id,
      nome: nome ?? this.nome,
      duracao: duracao ?? this.duracao,
      instituicao: instituicao ?? this.instituicao,
    );
  }

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'nome': nome,
      'duracao': duracao,
      'instituicao': instituicao,
      'disciplinas': _disciplinas.toList(),
    };
  }

  factory Curso.fromMap(Map<String, dynamic> map) {
    return Curso(
      id: map['id']?.toInt() ?? 0,
      nome: map['nome'] ?? '',
      duracao: map['duracao'] ?? '',
      instituicao: map['instituicao'],
    )..setDisciplinasId(map['disciplinas']?.map((x) => x['id'] ?? -1));
  }

  String toJson() => json.encode(toMap());

  factory Curso.fromJson(String source) => Curso.fromMap(json.decode(source));

  @override
  String toString() {
    return 'Curso(id: $id, nome: $nome, duracao: $duracao, instituicao: $instituicao, disciplinas: $_disciplinas)';
  }

  @override
  bool operator ==(Object other) {
    if (identical(this, other)) return true;

    return other is Curso &&
        other.id == id &&
        other.nome == nome &&
        other.duracao == duracao &&
        other.instituicao == instituicao &&
        listEquals(other._disciplinas, _disciplinas);
  }

  @override
  int get hashCode {
    return id.hashCode ^
        nome.hashCode ^
        duracao.hashCode ^
        instituicao.hashCode ^
        _disciplinas.hashCode;
  }

  Instituicao getInstituicao() {
    return Instituicao(
      id: -1,
      nome: 'Cesumar',
    );
  }

  void setDisciplinas(List<Disciplina> disciplinas) {
    disciplinas.map((e) => addDisciplina(e));
  }

  void setDisciplinasId(List<int> disciplinas) {
    disciplinas.map((e) => addIdDisciplina(e));
  }

  void addDisciplina(Disciplina disciplina) {
    _disciplinas.add(disciplina.id);
  }

  void addIdDisciplina(int disciplina) {
    _disciplinas.add(disciplina);
  }
}
