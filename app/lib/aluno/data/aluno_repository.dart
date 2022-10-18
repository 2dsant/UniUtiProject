import 'package:uniuti_core/uniuti_core.dart';
import '../../shared/application/uniuti_client.dart';
import '../../shared/application/uniuti_client_mixin.dart';

class RemoteAlunoRepository extends UniUtiHttpRemoteRepository
    implements AlunoRepository {
  RemoteAlunoRepository(UniUtiHttpClient client) : super(client);

  @override
  Future<Aluno?> byId(int id) {
    // TODO: implement byId
    throw UnimplementedError();
  }

  @override
  Future<List<Aluno>> getAll() {
    // TODO: implement getAll
    throw UnimplementedError();
  }

  @override
  Future<List<Aluno>> getMany(RepoFilter filter) {
    // TODO: implement getMany
    throw UnimplementedError();
  }

  @override
  Future<Aluno> performRegister(Aluno aluno) async {
    late Aluno novo;
    final response = await client.post(endpoint: '/Auth/CreateUser', body: {
      "nomeCompleto": aluno.nome,
      "email": aluno.usuario!.login,
      "password": aluno.usuario!.senha,
      "celular": aluno.celular,
      "instituicaoId": aluno.instituicao,
      "cursoId": aluno.curso
    });

    if (response.statusCode == 200) {
      final obj = response.body;
      novo = Aluno(
        celular: aluno.celular,
        curso: aluno.curso,
        id: obj['id'],
        instituicao: aluno.instituicao,
        nome: obj['nomeCompleto'],
      );
    } else {}
    return novo;
  }
}
