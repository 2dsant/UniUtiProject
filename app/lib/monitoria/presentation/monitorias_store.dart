import '../data/monitoria_repository.dart';
import '../domain/monitoria.dart';
import 'recents_list_item.dart';

class MonitoriaController {
  final _monitoriaRepos = <String, MonitoriaRepository>{
    'localDb': MockMonitoriaRepository(),
    'remote': MockMonitoriaRepository(),
  };

  Future<List<RecentsListItem>> getMonitorias() async {
    Monitoria? monitoria;
    for (var repo in _monitoriaRepos.values) {
      monitoria = await repo.byId(-1);
      if (monitoria != null) {
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
