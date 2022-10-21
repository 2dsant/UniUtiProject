part of '../http_client.dart';

class RemoteClientException extends UniUtiException {
  RemoteClientException(String message) : super(message);
}

class RemoteClientConnectionException extends RemoteClientException {
  RemoteClientConnectionException(String message) : super(message);
}
