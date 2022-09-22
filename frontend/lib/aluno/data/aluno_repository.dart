import 'dart:developer' as dev;

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
    return Aluno(
      id: -1,
      nome: 'Mock',
      usuario: usuario!,
      celular: null,
      cursoId: null,
      instituicaoId: null,
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
    final response = await client.post(endpoint: '/Auth/CreateUser', body: {
      "nomeCompleto": aluno.nome,
      "email": aluno.usuario.login,
      "password": aluno.usuario.senha,
      "celular": aluno.contato,
      "instituicaoId": aluno.instituicaoId,
      "cursoId": aluno.cursoId
    });

    if (response.statusCode == 200) {
      final obj = response.body;
      final novo = Aluno(
         celular: ,
         cursoId: ,
         id: obj['id'],
         instituicaoId: ,
         nome: obj['nomeCompleto'],
         usuario: U,

      );
    }
  }
}
