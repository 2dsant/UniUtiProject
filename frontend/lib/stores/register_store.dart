import 'package:uniuti/models/disciplina.dart';
import 'package:uniuti/models/instituicao.dart';

import '../models/curso.dart';

Future<List<Curso>> getCursos() async {
  return [
    Curso(
      nome: 'ADS',
      duracao: 'sim',
      id: 1,
      instituicao: Instituicao(
        id: 1,
        nome: 'Unicesumar',
        cursos: [],
        contatos: [],
      ),
      disciplinas: [],
    ),
  ];
}
