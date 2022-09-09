import 'dart:convert';
import 'dart:io';

import 'package:http/http.dart' as http;
import 'package:http_interceptor/http_interceptor.dart';

import '../../auth/domain/usuario.dart';

class UniUtiHttpClient {
  final client = http.Client();
  final host = 'localhost';
  final Usuario usuario;

  UniUtiHttpClient(this.usuario);

  Future<Response> get({
    required String endpoint,
    required Map<String, dynamic> params,
  }) async {
    if (!endpoint.startsWith('/')) {
      endpoint = '/$endpoint';
    }
    var response = await InterceptedHttp.build(
      interceptors: [
        UniUtiAuthInterceptor(getToken: () async => usuario.token),
      ],
      retryPolicy: UniUtiRetryPolicy(client: this, usuario: usuario),
    ).get(Uri(host: host, path: '/api' + endpoint), params: params);

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
    var response = await InterceptedHttp.build(
      interceptors: [
        UniUtiAuthInterceptor(getToken: () async => usuario.token),
      ],
      retryPolicy: UniUtiRetryPolicy(client: this, usuario: usuario),
    ).get(Uri(), params: params);

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

  Future<String> performTokenRefresh() async {
    var response = await post(endpoint: '/refresh-login', body: {});
    if (response.statusCode >= 500) {
      throw HttpException(response.reasonPhrase ?? 'Erro inesperado');
    }
    return response.body['token'];
  }
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
  final UniUtiHttpClient client;
  final Usuario usuario;

  UniUtiRetryPolicy({required this.usuario, required this.client});
  @override
  Future<bool> shouldAttemptRetryOnResponse(ResponseData response) async {
    var should = false;
    if (response.statusCode == 401) {
      usuario.token = await client.performTokenRefresh();
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
