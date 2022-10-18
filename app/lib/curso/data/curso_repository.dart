import 'package:uniuti_core/uniuti_core.dart';

import '../../shared/application/uniuti_client.dart';

class RemoteCursoRepository extends CursoRepository {
  final Uri uri;
  final UniUtiHttpClient client;
  RemoteCursoRepository(this.uri, {required this.client}) : super();

  @override
  Future<Curso?> byId(int id) async {
    var response =
        await client.get(endpoint: '/curso/findbyid/$id', params: {});
    Curso? curso;
    curso = CursoParser.fromMap(response.body);
    return curso;
  }

  @override
  Future<List<Curso>> getAll() async {
    var response = await client.get(endpoint: '/curso/FindAll', params: {});
    List<Curso> cursos = [];
    for (Map<String, dynamic> json in response.body['items']) {
      cursos.add(CursoParser.fromMap(json));
    }
    return cursos;
  }

  @override
  Future<List<Curso>> getMany(RepoFilter filter) async {
    final response = await client.get(endpoint: 'Curso/FindAll', params: {});
    final cursos = <Curso>[];
    if (response.statusCode == 204) {
      throw CursoNaoEncontradoException();
    }
    return cursos;
  }
}
