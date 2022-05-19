import 'dart:convert';

import 'package:flutter/foundation.dart';

import 'disciplina.dart';
import 'instituicao.dart';

class Curso {
  int id;
  String nome;
  String duracao;
  Instituicao instituicao;
  List<Disciplina> disciplinas;
  Curso({
    required this.id,
    required this.nome,
    required this.duracao,
    required this.instituicao,
    required this.disciplinas,
  });

  Curso copyWith({
    int? id,
    String? nome,
    String? duracao,
    Instituicao? instituicao,
    List<Disciplina>? disciplinas,
  }) {
    return Curso(
      id: id ?? this.id,
      nome: nome ?? this.nome,
      duracao: duracao ?? this.duracao,
      instituicao: instituicao ?? this.instituicao,
      disciplinas: disciplinas ?? this.disciplinas,
    );
  }

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'nome': nome,
      'duracao': duracao,
      'instituicao': instituicao.toMap(),
      'disciplinas': disciplinas.map((x) => x.toMap()).toList(),
    };
  }

  factory Curso.fromMap(Map<String, dynamic> map) {
    return Curso(
      id: map['id']?.toInt() ?? 0,
      nome: map['nome'] ?? '',
      duracao: map['duracao'] ?? '',
      instituicao: Instituicao.fromMap(map['instituicao']),
      disciplinas: List<Disciplina>.from(
          map['disciplinas']?.map((x) => Disciplina.fromMap(x))),
    );
  }

  String toJson() => json.encode(toMap());

  factory Curso.fromJson(String source) => Curso.fromMap(json.decode(source));

  @override
  String toString() {
    return 'Curso(id: $id, nome: $nome, duracao: $duracao, instituicao: $instituicao, disciplinas: $disciplinas)';
  }

  @override
  bool operator ==(Object other) {
    if (identical(this, other)) return true;

    return other is Curso &&
        other.id == id &&
        other.nome == nome &&
        other.duracao == duracao &&
        other.instituicao == instituicao &&
        listEquals(other.disciplinas, disciplinas);
  }

  @override
  int get hashCode {
    return id.hashCode ^
        nome.hashCode ^
        duracao.hashCode ^
        instituicao.hashCode ^
        disciplinas.hashCode;
  }
}
