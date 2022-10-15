import 'dart:developer' as dev;

import '../../contato/data/curso_repository.dart';
import '../../curso/data/curso_repository.dart';
import '../../instituicao/data/instituicao_repository.dart';
import '../domain/aluno.dart';
import '../../auth/data/usuario_repository.dart';
import '../../shared/data/repository.dart';
import '../../shared/application/uniuti_client.dart';
import '../../shared/application/uniuti_client_mixin.dart';

abstract class AlunoRepository implements Repository<Aluno> {
  Future<Aluno> performRegister(Aluno aluno);
}

class MockAlunoRepository implements AlunoRepository {
  @override
  Future<Aluno?> byId(int id) async {
    final usuario = await MockUsuarioRepository().byId(-1);
    final contato = await MockContatoRepository().byId(-1);
    final curso = await MockCursoRepository().byId(-1);
    final instituicao = await MockInstituicaoRepository().byId(-1);
    return Aluno(
      id: -1,
      nome: 'Mock',
      usuario: usuario!,
      celular: contato!,
      curso: curso!,
      instituicao: instituicao!,
    );
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
    return aluno;
  }
}

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
