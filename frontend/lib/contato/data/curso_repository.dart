import '../domain/contato.dart';
import '../../shared/data/repository.dart';

abstract class ContatoRepository implements Repository<Contato> {}

class MockContatoRepository implements ContatoRepository {
  @override
  Future<Contato?> byId(int id) async {
    return Contato(id: -1, contato: '00123456789');
  }

  @override
  Future<List<Contato>> getAll() {
    // TODO: implement getAll
    throw UnimplementedError();
  }

  @override
  Future<List<Contato>> getMany(RepoFilter filter) {
    // TODO: implement getMany
    throw UnimplementedError();
  }
}
