import '../models/models.dart';

class CursoRepository {
  Future<List<Curso>> getCursos() async {
    return [
      Curso(
        id: 01,
        nome: 'ADS',
        duracao: 'SIM',
        instituicao:
            Instituicao(id: 01, nome: 'Unicesumar', cursos: [], contatos: []),
        disciplinas: [],
      ),
      Curso(
        id: 02,
        nome: 'ADM',
        duracao: 'SIM',
        instituicao:
            Instituicao(id: 01, nome: 'Unicesumar', cursos: [], contatos: []),
        disciplinas: [],
      ),
    ];
  }
}
