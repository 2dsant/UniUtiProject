import 'dart:io';
import 'package:http/http.dart' as http;

import 'package:uniuti/shared/data/repository.dart';
import 'package:uniuti/shared/data/uniuti_client.dart';

import '../domain/curso.dart';

abstract class CursoRepository extends Repository<Curso> {}

class MockCursoRepository extends CursoRepository {
  static late final MockCursoRepository _instance =
      MockCursoRepository._internal();
  MockCursoRepository._internal();
  factory MockCursoRepository() => _instance;

  @override
  Future<List<Curso>> getAll() async {
    return [
      Curso(
        id: 01,
        nome: 'ADS',
        duracao: 'SIM',
      ),
      Curso(
        id: 02,
        nome: 'ADM',
        duracao: 'SIM',
      ),
    ];
  }

  @override
  Future<Curso> byId(int id) async {
    return Curso(id: id, nome: 'Curso', duracao: '1');
  }

  @override
  Future<List<Curso>> getMany(RepoFilter filter) {
    // TODO: implement getMany
    throw UnimplementedError();
  }
}

class RemoteCursoRepository extends CursoRepository {
  final Uri uri;
  final UniUtiHttpClient client;
  RemoteCursoRepository(this.uri, {required this.client}) : super();

  @override
  Future<Curso?> byId(int id) async {
    var response =
        await client.get(endpoint: '/curso/findbyid/$id', params: {});
    Curso? curso;
    curso = Curso.fromMap(response.body);
    return curso;
  }

  @override
  Future<List<Curso>> getAll() {
    // TODO: implement getAll
    throw UnimplementedError();
  }

  @override
  Future<List<Curso>> getMany(RepoFilter filter) {
    // TODO: implement getMany
    throw UnimplementedError();
  }
}
