part of '../../uniuti_core.dart';

class Disciplina {
  int id;
  String nome;
  String descricao;
  String periodicidade;
  Disciplina({
    required this.id,
    required this.nome,
    required this.descricao,
    this.periodicidade = '',
  });
}
