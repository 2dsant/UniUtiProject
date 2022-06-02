import 'package:get_it/get_it.dart';

import '../models/models.dart';

Future<Monitoria> getMockMonitoria() async {
  return Monitoria(
    id: -1,
    titulo: 'TITULO',
    descricao:
        'Um produto/monitoria com uma Descricao bem descrita e que parece que nao acaba nunca',
    disciplina: Disciplina(
      id: -1,
      descricao: 'Prog 3',
      nome: 'Prog 3',
      periodicidade: 'sim',
    ),
    pendencias: [],
    solicitante: GetIt.I.get<Aluno>(),
    status: Status(id: 0, descricao: 'OK'),
  );
}
