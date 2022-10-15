import '../../aluno/domain/aluno.dart';
import '../../disciplina/domain/disciplina.dart';
import 'status.dart';

class Monitoria {
  int id;
  String titulo;
  String descricao;
  Disciplina disciplina;
  Aluno? prestador;
  Aluno? solicitante;
  Status status;
  List<Aluno> pendencias;
  Monitoria({
    required this.id,
    required this.titulo,
    required this.descricao,
    required this.disciplina,
    this.prestador,
    this.solicitante,
    required this.status,
    required this.pendencias,
  }) {
    assert((prestador != null && solicitante != null) ||
        (prestador == null && solicitante != null) ||
        (prestador != null && solicitante == null));
  }
}
