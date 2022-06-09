import '../components/recents_list_item.dart';
import '../repositories/monitoria_repository.dart';

Future<List<RecentsListItem>> getRecentes() async {
  return [
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
    RecentsListItem(model: await getMockMonitoria()),
  ];
}
