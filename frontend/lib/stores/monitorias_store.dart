import '../components/recents_list_item.dart';
import '../repositories/monitoria_repository.dart';

Future<List<RecentsListItem>> getMonitorias() async {
  // TODO: implementar de fato busca na API / SQLite
  return [
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
  ];
}
