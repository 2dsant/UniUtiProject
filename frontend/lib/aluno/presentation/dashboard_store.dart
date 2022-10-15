import '../../instituicao/data/instituicao_repository.dart';
import '../../instituicao/domain/instituicao.dart';
import '../../monitoria/data/monitoria_repository.dart';
import '../../monitoria/presentation/recents_list_item.dart';
import '../../shared/data/repository.dart';
import '../domain/aluno.dart';

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
}
