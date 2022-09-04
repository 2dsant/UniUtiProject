import 'dart:convert';

abstract class Repository<T> {
  LastStatus lastStatus = LastStatus.none;
  Future<T?> byId(int id);
  Future<List<T>> getAll();
  Future<List<T>> getMany(RepoFilter filter);
}

enum LastStatus {
  none,
  found,
  notFound,
}

class RepoFilter {
  String property;
  FilterOperation operation;
  String value;
  RepoFilter({
    required this.property,
    required this.operation,
    required this.value,
  });

  Map<String, dynamic> toMap() {
    return {
      'property': property,
      'operation': operation,
      'value': value,
    };
  }

  factory RepoFilter.fromMap(Map<String, dynamic> map) {
    return RepoFilter(
      property: map['property'] ?? '',
      operation: map['operation'] ?? '',
      value: map['value'] ?? '',
    );
  }

  String toJson() => json.encode(toMap());

  factory RepoFilter.fromJson(String source) =>
      RepoFilter.fromMap(json.decode(source));
}

enum FilterOperation {
  equals,
}
