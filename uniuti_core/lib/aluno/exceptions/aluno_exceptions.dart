part of '../../uniuti_core.dart';

class AlunoFromMapException extends AlunoException {
  AlunoFromMapException(String message) : super(message);
}

class AlunoSemUsuarioException extends AlunoException {
  AlunoSemUsuarioException(Aluno aluno)
      : super(
          'O aluno ${aluno.nome}(${aluno.id}) nao possui um usuario vinculado',
        );
}

class AlunoException extends UniUtiException {
  AlunoException(String message) : super(message);
}
