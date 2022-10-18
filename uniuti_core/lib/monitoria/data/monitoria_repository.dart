part of '../../uniuti_core.dart';

abstract class MonitoriaRepository implements Repository<Monitoria> {}

class MockMonitoriaRepository implements MonitoriaRepository {
  @override
  Future<Monitoria> byId(int id) async {
    final aluno = await MockAlunoRepository().byId(-1);
    final disciplina = await MockDisciplinaRepository().byId(-1);
    return Monitoria(
      id: -1,
      titulo: 'TITULO',
      descricao:
          'Um produto/monitoria com uma Descricao bem descrita e que parece que nao acaba nunca',
      disciplina: disciplina,
      pendencias: [],
      solicitante: aluno,
      status: Status('OK'),
    );
  }

  @override
  Future<List<Monitoria>> getAll() async {
    final monitorias = <Monitoria>[];
    for (var i = 0; i < 5; i++) {
      monitorias.add(await MockMonitoriaRepository().byId(-1));
    }
    return monitorias;
  }

  @override
  Future<List<Monitoria>> getMany(RepoFilter filter) async {
    return await getAll();
  }
}
