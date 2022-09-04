import '../components/recents_list_item.dart';
import '../models/models.dart';
import '../repositories/repositories.dart';

class DashboardStore {
  final _instituicaoRepos = <String, InstituicaoRepository>{
    'localDb': MockInstituicaoRepository(),
    'remote': MockInstituicaoRepository(),
  };
  final _monitoriaRepos = <String, MonitoriaRepository>{
    'localDb': MockMonitoriaRepository(),
    'remote': MockMonitoriaRepository(),
  };
  Future<List<RecentsListItem>> getRecentes() async {
    final monitoria = await _monitoriaRepos['localDb']!.byId(-1);
    final list = <RecentsListItem>[];
    if (monitoria != null) {
      for (var i = 0; i < 5; i++) {
        list.add(RecentsListItem(model: monitoria));
      }
    }
    return list;
  }

  Future<Instituicao?> getInstituicaoDoAluno(Aluno aluno) async {
    if (aluno.instituicaoId == null) return null;
    late Instituicao? instituicao;
    for (var repo in _instituicaoRepos.values) {
      instituicao = await repo.byId(aluno.instituicaoId!);
      if (repo.lastStatus == LastStatus.found) {
        break;
      }
    }
    return instituicao;
  }
}
