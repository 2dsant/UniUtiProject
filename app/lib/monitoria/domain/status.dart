import 'dart:convert';

class Status {
  int id;
  String descricao;
  Status({
    required this.id,
    required this.descricao,
  });

  Status copyWith({
    int? id,
    String? descricao,
  }) {
    return Status(
      id: id ?? this.id,
      descricao: descricao ?? this.descricao,
    );
  }

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'descricao': descricao,
    };
  }

  factory Status.fromMap(Map<String, dynamic> map) {
    return Status(
      id: map['id']?.toInt() ?? 0,
      descricao: map['descricao'] ?? '',
    );
  }

  String toJson() => json.encode(toMap());

  factory Status.fromJson(String source) => Status.fromMap(json.decode(source));

  @override
  String toString() => 'Status(id: $id, descricao: $descricao)';

  @override
  bool operator ==(Object other) {
    if (identical(this, other)) return true;

    return other is Status && other.id == id && other.descricao == descricao;
  }

  @override
  int get hashCode => id.hashCode ^ descricao.hashCode;
}
