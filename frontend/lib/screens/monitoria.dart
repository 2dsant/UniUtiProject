import 'package:flutter/material.dart';
import 'package:get_it/get_it.dart';
import 'package:uniuti/styles.dart';

import '../models/models.dart';

class MonitoriaScreen extends StatefulWidget {
  const MonitoriaScreen({Key? key}) : super(key: key);

  @override
  State<MonitoriaScreen> createState() => _MonitoriaScreenState();
}

// TODO: logica para mostrar botao de ajudar
class _MonitoriaScreenState extends State<MonitoriaScreen> {
  @override
  Widget build(BuildContext context) {
    final monitoria = ModalRoute.of(context)!.settings.arguments as Monitoria;
    final _th = Theme.of(context).textTheme;
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.transparent,
        elevation: 0,
      ),
      body: Container(
        padding: const EdgeInsets.all(35),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            Container(
              margin: const EdgeInsets.symmetric(vertical: 10),
              child: Text(
                monitoria.titulo,
                style: _th.headlineLarge,
              ),
            ),
            Container(
              margin: const EdgeInsets.symmetric(vertical: 10),
              child: Text(
                'Anunciado em: 01/01/2022',
                style: _th.titleSmall,
              ),
            ),
            Container(
              padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 10),
              margin: const EdgeInsets.symmetric(vertical: 10),
              decoration: BoxDecoration(
                color: UniUtiColors.purple.withOpacity(0.22),
                borderRadius: BorderRadius.circular(8),
              ),
              child: Text(
                monitoria.descricao,
                textAlign: TextAlign.center,
              ),
            ),
            Container(
              margin: const EdgeInsets.symmetric(vertical: 10),
              child: Row(
                crossAxisAlignment: CrossAxisAlignment.center,
                children: [
                  Container(
                    width: 30,
                    height: 30,
                    margin: const EdgeInsets.only(right: 15),
                    decoration: BoxDecoration(
                      color: Colors.grey,
                      borderRadius: BorderRadius.circular(15),
                    ),
                  ),
                  Text((monitoria.solicitante ?? GetIt.I.get<Aluno>()).nome),
                ],
              ),
            ),
            Container(
              margin: const EdgeInsets.symmetric(vertical: 10),
              child: ElevatedButton(
                onPressed: dialogoContatar,
                child: Container(
                  padding: const EdgeInsets.symmetric(vertical: 15),
                  child: Text(
                    'Contatar',
                    style: _th.titleLarge!.copyWith(color: Colors.white),
                  ),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }

  void dialogoContatar() {
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
