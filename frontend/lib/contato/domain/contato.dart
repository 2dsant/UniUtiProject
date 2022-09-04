import 'dart:convert';

class Contato {
  int id;
  String contato;
  Contato({
    required this.id,
    required this.contato,
  });

  Contato copyWith({
    int? id,
    String? contato,
  }) {
    return Contato(
      id: id ?? this.id,
      contato: contato ?? this.contato,
    );
  }

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'contato': contato,
    };
  }

  factory Contato.fromMap(Map<String, dynamic> map) {
    return Contato(
      id: map['id']?.toInt() ?? 0,
      contato: map['contato'] ?? '',
    );
  }

  String toJson() => json.encode(toMap());

  factory Contato.fromJson(String source) => Contato.fromMap(json.decode(source));

  @override
  String toString() => 'Contato(id: $id, contato: $contato)';

  @override
  bool operator ==(Object other) {
    if (identical(this, other)) return true;
  
    return other is Contato &&
      other.id == id &&
      other.contato == contato;
  }

  @override
  int get hashCode => id.hashCode ^ contato.hashCode;
}
