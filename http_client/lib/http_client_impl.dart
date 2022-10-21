part of '../http_client.dart';

typedef GetApiToken = Future<String> Function();
typedef RefreshApiToken = Future<bool> Function();

class AuthInterceptor implements InterceptorContract {
  final GetApiToken getToken;
  AuthInterceptor({
    required this.getToken,
  });

  @override
  Future<RequestData> interceptRequest({required RequestData data}) async {
    data.headers.addAll({
      HttpHeaders.authorizationHeader: 'Bearer ${await getToken()}',
    });
    return data;
  }

  @override
  Future<ResponseData> interceptResponse({required ResponseData data}) async {
    return data;
  }
}

class RetryPolicyImpl extends RetryPolicy {
  final RefreshApiToken performRefreshToken;

  RetryPolicyImpl(this.performRefreshToken);
  @override
  Future<bool> shouldAttemptRetryOnResponse(ResponseData response) async {
    var should = false;
    if (response.statusCode == 401) {
      await performRefreshToken();
      should = !should;
    }
    return should;
  }
}
