part of '../http_client.dart';

abstract class RemoteClient {
  Future<Response> get(
    String endpoint, {
    Map<String, dynamic>? params,
  });
  Future<Response> post(
    String endpoint, {
    Map<String, dynamic>? params,
    Object? body,
  });
}
