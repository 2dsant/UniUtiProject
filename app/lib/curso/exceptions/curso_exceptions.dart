import '../../shared/exceptions/uniuti_exceptions.dart';

class CursoNaoEncontradoException extends CursoException {
  CursoNaoEncontradoException()
      : super('Nao foi possivel encontrar o(s) curso(s)');
}

class CursoException extends UniUtiException {
  CursoException(String message) : super(message);
}
