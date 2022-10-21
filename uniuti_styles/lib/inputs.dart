part of 'uniuti_styles.dart';

class UniUtiInput extends StatelessWidget {
  final ValueChanged<String>? onChanged;

  const UniUtiInput({
    Key? key,
    required this.placeholder,
    this.password = false,
    this.type,
    this.save,
    this.valid,
    this.last = false,
    this.editingComplete,
    this.onChanged,
  }) : super(key: key);

  final String placeholder;
  final bool password;
  final bool last;
  final TextInputType? type;
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
        onChanged: onChanged,
        obscureText: password,
        keyboardType: type,
        onSaved: save,
        validator: valid,
        onEditingComplete: editingComplete,
      ),
    );
  }
}

class UniUtiTitleInput extends StatelessWidget {
  const UniUtiTitleInput({
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
        style: Theme.of(context).textTheme.headlineLarge,
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

class UniUtiDescricaoInput extends StatelessWidget {
  const UniUtiDescricaoInput({
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
    final _decor = uniUtiInputDecoration(placeholder);
    final _border = _decor.focusedBorder!;
    return Container(
      // padding: EdgeInsets,
      constraints: const BoxConstraints(maxHeight: 400),
      margin: const EdgeInsets.only(bottom: 25),
      child: TextFormField(
        textInputAction: last ? TextInputAction.go : TextInputAction.next,
        decoration: _decor.copyWith(
            fillColor: UniUtiColors.purple.withOpacity(0.22),
            contentPadding: const EdgeInsets.fromLTRB(20, 10, 20, 40),
            focusedBorder: _border.copyWith(
              borderSide: _border.borderSide.copyWith(
                color: UniUtiColors.purple,
              ),
            )),
        cursorColor: UniUtiColors.purple,
        maxLines: 10,
        minLines: 1,
        controller: controller,
        obscureText: password,
        keyboardType: type,
        onSaved: save,
        validator: valid,
        onEditingComplete: editingComplete,
        textAlign: TextAlign.center,
      ),
    );
  }
}
