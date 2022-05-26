import 'package:flutter/material.dart';

import '../styles.dart';

class UniUtiInput extends StatelessWidget {
  const UniUtiInput({
    Key? key,
    required this.placeholder,
    this.password = false,
    this.type,
    this.controller,
    this.save,
    this.valid,
    this.last = false,
    this.editingComplete,
  }) : super(key: key);

  final String placeholder;
  final bool password;
  final bool last;
  final TextInputType? type;
  final TextEditingController? controller;
  final FormFieldSetter<String>? save;
  final FormFieldValidator<String>? valid;
  final VoidCallback? editingComplete;

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: const EdgeInsets.only(bottom: 25),
      child: TextFormField(
        textInputAction: last ? TextInputAction.go : TextInputAction.next,
        decoration: uniUtiInputDecoration(placeholder),
        controller: controller,
        obscureText: password,
        keyboardType: type,
        onSaved: save,
        validator: valid,
        onEditingComplete: editingComplete,
      ),
    );
  }
}
