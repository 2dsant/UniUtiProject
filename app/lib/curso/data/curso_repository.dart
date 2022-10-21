import 'package:http_client/http_client.dart';
import 'package:uniuti_core/uniuti_core.dart';

class RemoteCursoRepository implements CursoRepository {
  final RemoteClient client;
  RemoteCursoRepository(this.client) : super();

  @override
  Future<Curso?> byId(int id) async {
    var response = await client.get('/v1/Curso/findbyid/$id', params: {});
    Curso? curso;
    curso = CursoParser.fromMap(response.body);
    return curso;
  }

  @override
  Future<List<Curso>> getAll() async {
    var response = await client.get('/v1/Curso/FindAll', params: {});
    List<Curso> cursos = [];
    for (Map<String, dynamic> json in response.body['data']) {
      cursos.add(CursoParser.fromMap(json));
    }
    return cursos;
  }

  @override
  Future<List<Curso>> getMany(RepoFilter filter) async {
    final response = await client.get('/v1/Curso/FindAll', params: {});
    final cursos = <Curso>[];
    if (response.statusCode == 204) {
      throw CursoNaoEncontradoException();
    }
    return cursos;
  }
}
