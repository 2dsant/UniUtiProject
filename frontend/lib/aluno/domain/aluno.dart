import '../../auth/domain/usuario.dart';
import '../../contato/domain/contato.dart';
import '../../curso/domain/curso.dart';
import '../../instituicao/domain/instituicao.dart';

class Aluno {
  int id;
  String nome;
  Curso cursoId;
  Contato celular;
  Usuario usuario;
  Instituicao instituicaoId;
  Aluno({
    required this.id,
    required this.nome,
    required this.cursoId,
    required this.celular,
    required this.usuario,
    required this.instituicaoId,
  });
}
