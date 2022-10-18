part of '../../uniuti_core.dart';

class Aluno {
  int id;
  String nome;
  Curso? curso;
  Contato? celular;
  Usuario? usuario;
  Instituicao? instituicao;
  Aluno({
    required this.id,
    required this.nome,
    required this.curso,
    required this.celular,
    required this.instituicao,
    this.usuario,
  });
}
