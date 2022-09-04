import 'package:uniuti/shared/data/repository.dart';

import '../../aluno/domain/aluno.dart';
import '../../auth/domain/usuario.dart';
import '../domain/monitoria.dart';
import '../domain/status.dart';

abstract class MonitoriaRepository extends Repository<Monitoria> {}

class MockMonitoriaRepository extends MonitoriaRepository {
  static late final MockMonitoriaRepository _instance =
      MockMonitoriaRepository._internal();
  MockMonitoriaRepository._internal();
  factory MockMonitoriaRepository() => _instance;
  @override
  Future<Monitoria> byId(int id) async {
    var _user = Usuario(id: -1, login: 'mock', senha: 'mock@123', token: '');
    final aluno = Aluno(id: -1, nome: 'Mock', usuario: _user)..addIdCurso(-1);
    return Monitoria(
      id: -1,
      titulo: 'TITULO',
      descricao:
          'Um produto/monitoria com uma Descricao bem descrita e que parece que nao acaba nunca',
      disciplina: -1,
      pendencias: [],
      solicitante: aluno,
      status: Status(id: 0, descricao: 'OK'),
    );
  }

  @override
  Future<List<Monitoria>> getAll() async {
    // TODO: implement getAll
    throw UnimplementedError();
  }

  @override
  Future<List<Monitoria>> getMany(RepoFilter filter) async {
    // TODO: implement getMany
    throw UnimplementedError();
  }
}
