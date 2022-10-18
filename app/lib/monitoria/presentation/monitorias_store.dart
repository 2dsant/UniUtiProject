import 'package:uniuti/shared/application/uniuti_client.dart';
import 'package:uniuti_core/uniuti_core.dart';

import '../data/monitoria_repository.dart';
import 'recents_list_item.dart';

class MonitoriaController {
  MonitoriaController(UniUtiHttpClient client)
      : _monitoriaRepos = {
          'localDb': MockMonitoriaRepository(),
          'remote': MonitoriaRemoteRepository(client),
        };
  final Map<String, MonitoriaRepository> _monitoriaRepos;

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
