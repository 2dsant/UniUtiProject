import '../domain/aluno.dart';

class AlunoParser {
  static Map<String, dynamic> toMap(Aluno aluno) {
    return {
      'id': aluno.id,
      'nome': aluno.nome,
      'cursoId': aluno.curso,
      'celular': aluno.celular,
      'usuario': aluno.usuario,
      'instituicaoId': aluno.instituicao,
    };
  }

  static String toJson(Aluno aluno) {
    return toMap(aluno).toString();
  }

  static Aluno fromMap(Map<String, dynamic> map) {
    return Aluno(
      id: map['id'],
      nome: map['nome'],
      curso: map['cursoId'],
      celular: map['celular'],
      usuario: null,
      instituicao: map['instituicaoId'],
    );
  }
}
