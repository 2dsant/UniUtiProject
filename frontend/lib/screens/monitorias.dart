import 'dart:developer' as dev;

import 'package:flutter/material.dart';

import '../components/components.dart';
import '../components/recents_list_item.dart';
import '../stores/monitorias_store.dart';

class MonitoriasScreen extends StatefulWidget {
  const MonitoriasScreen({Key? key}) : super(key: key);

  @override
  _MonitoriasScreenState createState() => _MonitoriasScreenState();
}

class _MonitoriasScreenState extends State<MonitoriasScreen> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: CustomScrollView(
        slivers: [
          const SliverAppBar(
            backgroundColor: Colors.transparent,
            collapsedHeight: 80,
            floating: true,
            primary: true,
            snap: true,
          ),
          SliverToBoxAdapter(
            child: Container(
              padding: const EdgeInsets.only(left: 40, bottom: 10, top: 10),
              child: Text(
                'Monitorias',
                style: Theme.of(context).textTheme.displaySmall!.copyWith(
                    fontWeight: FontWeight.bold, color: Colors.black87),
              ),
            ),
          ),
          SliverToBoxAdapter(
            child: Container(
              padding: const EdgeInsets.only(top: 10, bottom: 25),
              child: SingleChildScrollView(
                scrollDirection: Axis.horizontal,
                child: Row(
                  children: [
                    const SizedBox(width: 30),
                    FixedMenuItem(
                      text: 'Ofertar ajuda',
                      icon: Icons.local_offer_outlined,
                      onTap: () => dev.log('nova_monitoria'),
                    ),
                    FixedMenuItem(
                      text: 'Pedir ajuda',
                      icon: Icons.local_offer_outlined,
                      onTap: () => dev.log('nova_monitoria'),
                    ),
                    FixedMenuItem(
                      text: 'Minhas solicitacoes',
                      icon: Icons.local_offer_outlined,
                      onTap: () => dev.log('minhas_solicits'),
                    ),
                    const SizedBox(width: 30),
                  ],
                ),
              ),
            ),
          ),
          SliverToBoxAdapter(
            child: Container(
              padding: const EdgeInsets.only(top: 30, bottom: 25),
              child: Container(
                padding: const EdgeInsets.only(left: 40, bottom: 10),
                child: Text(
                  'Monitorias em aberto',
                  style: Theme.of(context).textTheme.headlineSmall!.copyWith(
                      fontWeight: FontWeight.bold, color: Colors.black87),
                ),
              ),
            ),
          ),
          // TODO: Utilizar outro metodo de build da lista a fim de mostrar itens sob demanda
          FutureBuilder<List<RecentsListItem>>(
            future: getMonitorias(),
            builder: (context, snap) {
              if (snap.connectionState == ConnectionState.done) {
                if (snap.hasData && snap.data!.isNotEmpty) {
                  return SliverFixedExtentList(
                    itemExtent: 105,
                    delegate: SliverChildListDelegate(snap.data!),
                  );
                }
                return const SliverToBoxAdapter(
                    child: Center(child: Text('Sem Monitorias')));
              }
              return const SliverToBoxAdapter(
                  child: Center(child: CircularProgressIndicator()));
            },
          ),
        ],
      ),
    );
  }
}
