import '../../auth/domain/usuario.dart';
import '../../contato/domain/contato.dart';
import '../../curso/domain/curso.dart';
import '../../instituicao/domain/instituicao.dart';

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
