part of '../http_client.dart';

class RemoteClientImpl implements RemoteClient {
  final String host;
  late InterceptedClient client;

  RemoteClientImpl({required this.host}) {
    client = InterceptedClient.build(interceptors: []);
  }

  close() {
    client.close();
  }

  @override
  Future<Response> get(String endpoint, {Map<String, dynamic>? params}) async {
    if (!endpoint.startsWith('/')) {
      endpoint = '/$endpoint';
    }
    late http.Response response;
    late Map<String, dynamic> body;
    try {
      response = await client.get(
        Uri.parse('https://$host$endpoint'),
        params: params,
      );
      body = json.decode(response.body);
    } on SocketException catch (e) {
      throw RemoteClientConnectionException(e.toString());
    } catch (e) {
      throw RemoteClientException(e.toString());
    }
    return Response.fromHttpResponse(response: response, body: body);
  }

  @override
  Future<Response> post(String endpoint,
      {Map<String, dynamic>? params, Object? body}) async {
    if (!endpoint.startsWith('/')) {
      endpoint = '/$endpoint';
    }
    late http.Response response;
    late Map<String, dynamic> body;
    try {
      response = await client.post(
        Uri.parse('https://$host$endpoint'),
        params: params,
      );
      body = json.decode(response.body);
    } on SocketException catch (e) {
      throw RemoteClientConnectionException(e.toString());
    } catch (e) {
      throw RemoteClientException(e.toString());
    }
    return Response.fromHttpResponse(response: response, body: body);
  }

  addInteceptor(InterceptorContract interceptor) {
    client.interceptors.add(interceptor);
  }

  setRetryPolicy(RetryPolicy retryPolicy) {
    client.retryPolicy = retryPolicy;
  }
}
