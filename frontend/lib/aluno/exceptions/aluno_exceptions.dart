import '../../shared/exceptions/uniuti_exceptions.dart';

class AlunoFromMapException extends AlunoException {
  AlunoFromMapException(String message) : super(message);
}

class AlunoException extends UniUtiException {
  AlunoException(String message) : super(message);
}
