import 'dart:convert';

import 'package:flutter/foundation.dart';

import '../../aluno/domain/aluno.dart';
import '../../disciplina/domain/disciplina.dart';
import 'status.dart';

class Monitoria {
  int id;
  String titulo;
  String descricao;
  late int _disciplina;
  Aluno? prestador;
  Aluno? solicitante;
  Status status;
  List<Aluno> pendencias;
  Monitoria({
    required this.id,
    required this.titulo,
    required this.descricao,
    required int disciplina,
    this.prestador,
    this.solicitante,
    required this.status,
    required this.pendencias,
  }) {
    assert((prestador != null && solicitante != null) ||
        (prestador == null && solicitante != null) ||
        (prestador != null && solicitante == null));
    setDisciplina(disciplina);
  }

  Monitoria copyWith({
    int? id,
    String? titulo,
    String? descricao,
    Disciplina? disciplina,
    Aluno? prestador,
    Aluno? solicitante,
    Status? status,
    List<Aluno>? pendencias,
  }) {
    return Monitoria(
      id: id ?? this.id,
      titulo: titulo ?? this.titulo,
      descricao: descricao ?? this.descricao,
      disciplina: disciplina?.id ?? _disciplina,
      prestador: prestador ?? this.prestador,
      solicitante: solicitante ?? this.solicitante,
      status: status ?? this.status,
      pendencias: pendencias ?? this.pendencias,
    );
  }

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'titulo': titulo,
      'descricao': descricao,
      'disciplina': _disciplina,
      'prestador': prestador?.toMap(),
      'solicitante': solicitante?.toMap(),
      'status': status.toMap(),
      'pendencias': pendencias.map((x) => x.toMap()).toList(),
    };
  }

  factory Monitoria.fromMap(Map<String, dynamic> map) {
    return Monitoria(
      id: map['id']?.toInt() ?? 0,
      titulo: map['titulo'] ?? '',
      descricao: map['descricao'] ?? '',
      disciplina: map['disciplina'],
      prestador:
          map['prestador'] != null ? Aluno.fromMap(map['prestador']) : null,
      solicitante:
          map['solicitante'] != null ? Aluno.fromMap(map['solicitante']) : null,
      status: Status.fromMap(map['status']),
      pendencias:
          List<Aluno>.from(map['pendencias']?.map((x) => Aluno.fromMap(x))),
    );
  }

  String toJson() => json.encode(toMap());

  factory Monitoria.fromJson(String source) =>
      Monitoria.fromMap(json.decode(source));

  @override
  String toString() {
    return 'Monitoria(id: $id, titulo: $titulo, descricao: $descricao, disciplina: $_disciplina, prestador: $prestador, solicitante: $solicitante, status: $status, pendencias: $pendencias)';
  }

  @override
  bool operator ==(Object other) {
    if (identical(this, other)) return true;

    return other is Monitoria &&
        other.id == id &&
        other.titulo == titulo &&
        other.descricao == descricao &&
        other._disciplina == _disciplina &&
        other.prestador == prestador &&
        other.solicitante == solicitante &&
        other.status == status &&
        listEquals(other.pendencias, pendencias);
  }

  @override
  int get hashCode {
    return id.hashCode ^
        titulo.hashCode ^
        descricao.hashCode ^
        _disciplina.hashCode ^
        prestador.hashCode ^
        solicitante.hashCode ^
        status.hashCode ^
        pendencias.hashCode;
  }

  void setDisciplina(int id) {
    _disciplina = id;
  }
}
