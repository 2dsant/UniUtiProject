part of '../../uniuti_core.dart';

class CursoNaoEncontradoException extends CursoException {
  CursoNaoEncontradoException()
      : super('Nao foi possivel encontrar o(s) curso(s)');
}

class CursoException extends UniUtiException {
  CursoException(String message) : super(message);
}
