part of '../http_client.dart';

@immutable
class Response {
  final int statusCode;
  final Map<String, dynamic> body;
  final String? reasonPhrase;

  const Response({
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
