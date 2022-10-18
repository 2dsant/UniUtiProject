import 'dart:developer' as dev;
import 'package:flutter/material.dart';

import 'package:uniuti_core/uniuti_core.dart';
import '../../shared/presentation/inputs.dart';
import '../../shared/presentation/styles.dart';
import 'form_monitoria_store.dart';

class FormMonitoriaScreen extends StatelessWidget {
  FormMonitoriaScreen({Key? key, required this.controller}) : super(key: key);
  final _form = GlobalKey<FormState>();
  final FormMonitoriaController controller;
  static const String route = '/formMonitoria';

  @override
  Widget build(BuildContext context) {
    final _th = Theme.of(context).textTheme;
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.transparent,
        elevation: 0,
      ),
      body: Form(
        key: _form,
        child: Container(
          padding: const EdgeInsets.all(35),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.stretch,
            children: [
              const UniUtiTitleInput(placeholder: 'Titulo'),
              const UniUtiDescricaoInput(
                placeholder: 'Descricao',
              ),
              dropdown(placeholder: 'Disciplina'),
              Container(
                margin: const EdgeInsets.symmetric(vertical: 10),
                child: ElevatedButton(
                  onPressed: () => dialogoContatar(context),
                  child: Container(
                    padding: const EdgeInsets.symmetric(vertical: 15),
                    child: Text(
                      'Publicar',
                      style: _th.titleLarge!.copyWith(color: Colors.white),
                    ),
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }

  dropdown({required String placeholder}) {
    return FutureBuilder<List<Disciplina>>(
      future: controller.getDisciplinas(),
      builder:
          (BuildContext context, AsyncSnapshot<List<Disciplina>> snapshot) {
        var items = 0;
        if (snapshot.hasData) {
          items = snapshot.data!.length;
        }
        return Container(
          margin: const EdgeInsets.only(bottom: 25),
          child: DropdownButtonFormField<Disciplina>(
            decoration: uniUtiInputDecoration(placeholder),
            items: List.generate(
              items,
              (index) {
                return DropdownMenuItem(
                  child: Text(snapshot.data![index].nome),
                  value: snapshot.data![index],
                );
              },
            ),
            onChanged: (sel) => dev.log(sel.toString()),
          ),
        );
      },
    );
  }

  void dialogoContatar(BuildContext context) {
    showModalBottomSheet(
      context: context,
      shape: const RoundedRectangleBorder(
          borderRadius: BorderRadius.only(
            topLeft: Radius.circular(18),
            topRight: Radius.circular(18),
          ),
          side: BorderSide.none),
      builder: (context) {
        return Container(
          margin: const EdgeInsets.fromLTRB(20, 35, 20, 15),
          child: const Text('TESTE'),
        );
      },
    );
  }
}
