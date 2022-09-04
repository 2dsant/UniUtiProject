import '../components/recents_list_item.dart';
import '../models/models.dart';
import '../repositories/repositories.dart';

class MonitoriaController {
  final _monitoriaRepos = <String, MonitoriaRepository>{
    'localDb': MockMonitoriaRepository(),
    'remote': MockMonitoriaRepository(),
  };

  Future<List<RecentsListItem>> getMonitorias() async {
    Monitoria? monitoria;
    for (var repo in _monitoriaRepos.values) {
      monitoria = await repo.byId(-1);
      if (repo.lastStatus == LastStatus.found) {
        break;
      }
    }
    if (monitoria == null) return [];
    final list = [RecentsListItem(model: monitoria)];
    for (var i = 0; i < 5; i++) {
      list.add(RecentsListItem(model: monitoria));
    }
    return list;
  }
}
