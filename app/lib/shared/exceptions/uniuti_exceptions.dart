class UniUtiException implements Exception {
  final String message;

  UniUtiException(this.message);

  @override
  String toString() {
    return message;
  }
}
