import 'dart:convert';
import 'dart:io';

import 'package:http/http.dart' as http;
import 'package:http_interceptor/http_interceptor.dart';

import '../../auth/domain/usuario.dart';
import '../../auth/data/usuario_repository.dart';
import '../exceptions/uniuti_exceptions.dart';

class UniUtiHttpClient {
  // TODO: Implement client close
  late final InterceptedClient client;
  final host = '192.168.0.6:7223';
  final Usuario usuario;

  final String version;

  UniUtiHttpClient({required this.version, required this.usuario}) {
    client = InterceptedClient.build(
      interceptors: [
        UniUtiAuthInterceptor(getToken: () async => usuario.token),
      ],
      retryPolicy: UniUtiRetryPolicy(
          userRepo: RemoteUsuarioRepository(this), usuario: usuario),
    );
  }

  Future<Response> get({
    required String endpoint,
    required Map<String, dynamic> params,
  }) async {
    if (!endpoint.startsWith('/')) {
      endpoint = '/$endpoint';
    }
    late http.Response response;
    try {
      response = await client.get(
        Uri.parse('https://$host/$endpoint'),
        params: params,
      );
    } catch (e) {
      throw RemoteClientException(Response(
        statusCode: 500,
        body: {'reason': e.toString()},
      ));
    }

    var body = json.decode(response.body);
    if (body.runtimeType == List) {
      body = {
        'items': body,
      };
    }
    return Response.fromHttpResponse(response: response, body: body);
  }

  Future<Response> post({
    required String endpoint,
    required Map<String, dynamic> body,
    Map<String, dynamic> params = const {},
  }) async {
    late http.Response response;
    try {
      response = await client.get(
        Uri.parse('https://$host/$endpoint'),
        params: params,
      );
    } catch (e) {
      throw RemoteClientException(Response(
        statusCode: 500,
        body: {'reason': e.toString()},
      ));
    }

    var body = json.decode(response.body);
    if (body.runtimeType == List) {
      body = {
        'items': body,
      };
    }
    return Response.fromHttpResponse(response: response, body: body);
  }

  // Future<Response> put() async {}
  // Future<Response> patch() async {}
}

typedef ApiToken = Future<String> Function();

class UniUtiAuthInterceptor implements InterceptorContract {
  final ApiToken getToken;
  UniUtiAuthInterceptor({
    required this.getToken,
  });

  @override
  Future<RequestData> interceptRequest({required RequestData data}) async {
    data.headers.addAll({
      HttpHeaders.authorizationHeader: 'Bearer ' + await getToken(),
    });
    return data;
  }

  @override
  Future<ResponseData> interceptResponse({required ResponseData data}) async {
    return data;
  }
}

class UniUtiRetryPolicy extends RetryPolicy {
  final UsuarioRepository userRepo;
  final Usuario usuario;

  UniUtiRetryPolicy({required this.usuario, required this.userRepo});
  @override
  Future<bool> shouldAttemptRetryOnResponse(ResponseData response) async {
    var should = false;
    if (response.statusCode == 401) {
      await userRepo.performRefreshToken(usuario);
      should = !should;
    }
    return should;
  }
}

class Response {
  int statusCode;
  Map<String, dynamic> body;
  String? reasonPhrase;

  Response({
    required this.statusCode,
    required this.body,
    this.reasonPhrase,
  });

  static Response fromHttpResponse({required http.Response response, body}) {
    return Response(
      body: body,
      statusCode: response.statusCode,
      reasonPhrase: response.reasonPhrase,
    );
  }
}

class RemoteClientException extends UniUtiException {
  final Response response;
  RemoteClientException(this.response)
      : super(response.reasonPhrase ?? 'Erro inesperado');
}
