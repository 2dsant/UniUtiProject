import 'package:flutter/material.dart';
import 'package:uniuti_core/uniuti_core.dart';
import '../../monitoria/presentation/recents_list_item.dart';
import 'package:uniuti_styles/uniuti_styles.dart';
import 'dashboard_store.dart';

class DashboardScreen extends StatelessWidget {
  const DashboardScreen(
      {Key? key, required this.controller, required this.aluno})
      : super(key: key);
  final Aluno aluno;

  final DashboardStore controller;

  static const String route = '/dashboard';

  @override
  Widget build(BuildContext context) {
    final th = Theme.of(context).textTheme;
    var menuItems = [
      const SizedBox(width: 30),
      FixedMenuItem(
        text: 'Monitorias',
        icon: Icons.menu_book_sharp,
        onTap: () => Navigator.of(context).pushNamed('/monitorias'),
      ),
      const SizedBox(width: 30),
    ];
    return Scaffold(
      drawer: Drawer(
        child: SingleChildScrollView(
          child: Container(
            constraints: BoxConstraints(
              maxHeight: MediaQuery.of(context).size.height,
            ),
            decoration: BoxDecoration(
              gradient: UniUtiBgGradient3(),
            ),
            child: Column(
              children: [
                const DrawerHeader(
                  child: UniUtiLogo(),
                ),
                const Expanded(child: Text('LOL')),
                Column(
                  children: const [
                    Text('Sair'),
                  ],
                )
              ],
            ),
          ),
        ),
      ),
      body: CustomScrollView(
        primary: true,
        slivers: [
          SliverAppBar(
            backgroundColor: UniUtiColors.purple.shade900,
            expandedHeight: 235,
            floating: true,
            snap: true,
            pinned: true,
            iconTheme: Theme.of(context)
                .appBarTheme
                .iconTheme!
                .copyWith(color: Colors.white),
            flexibleSpace: FlexibleSpaceBar(
              collapseMode: CollapseMode.pin,
              title: RichText(
                text: TextSpan(
                  style: th.bodyLarge!.copyWith(color: Colors.white),
                  children: [
                    const TextSpan(text: 'Bem-vindo, '),
                    TextSpan(
                        text: aluno.nome,
                        style: th.bodyLarge!.copyWith(
                            color: Colors.white, fontWeight: FontWeight.bold)),
                  ],
                ),
              ),
              background: Container(
                padding: const EdgeInsets.only(top: 50),
                decoration: BoxDecoration(gradient: UniUtiBgGradient2()),
                child: Column(
                  mainAxisSize: MainAxisSize.min,
                  children: [
                    Container(
                      decoration: BoxDecoration(
                        borderRadius: BorderRadius.circular(43),
                        color: Colors.white,
                      ),
                      height: 85,
                      width: 85,
                      child: const Center(child: Text('FOTO')),
                    ),
                    const SizedBox(height: 8),
                    Text(aluno.nome,
                        style: Theme.of(context)
                            .textTheme
                            .titleLarge!
                            .copyWith(color: Colors.white)),
                    Text(aluno.instituicao!.nome,
                        style: Theme.of(context)
                            .textTheme
                            .titleMedium!
                            .copyWith(color: Colors.white)),
                  ],
                ),
              ),
            ),
          ),
          SliverToBoxAdapter(
            child: Container(
              padding: const EdgeInsets.only(top: 30, bottom: 25),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Container(
                    padding: const EdgeInsets.only(left: 40, bottom: 10),
                    child: Text(
                      'Para onde deseja ir?',
                      style: th.headlineSmall,
                    ),
                  ),
                  SingleChildScrollView(
                    scrollDirection: Axis.horizontal,
                    child: Row(children: menuItems),
                  ),
                ],
              ),
            ),
          ),
          SliverToBoxAdapter(
            child: Container(
              padding: const EdgeInsets.only(top: 30, bottom: 25),
              child: Container(
                padding: const EdgeInsets.only(left: 40, bottom: 10),
                child: Text(
                  'Ultimos itens vistos',
                  style: th.headlineSmall,
                ),
              ),
            ),
          ),
          FutureBuilder<List<RecentsListItem>>(
            future: controller.getRecentes(),
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
