import 'dart:developer' as dev;
import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:uniuti/components/components.dart';
import 'package:uniuti/styles.dart';

class DashboardScreen extends StatefulWidget {
  const DashboardScreen({Key? key}) : super(key: key);

  @override
  _DashboardScreenState createState() => _DashboardScreenState();
}

class _DashboardScreenState extends State<DashboardScreen> {
  @override
  Widget build(BuildContext context) {
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
                DrawerHeader(
                  child: SvgPicture.asset('assets/logo.svg'),
                ),
                Expanded(child: Container(child: Text('LOL'))),
                Container(
                  child: Column(
                    children: [
                      Text('Sair'),
                    ],
                  ),
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
            flexibleSpace: FlexibleSpaceBar(
              collapseMode: CollapseMode.pin,
              title: RichText(
                text: TextSpan(
                  style: Theme.of(context)
                      .textTheme
                      .bodyLarge!
                      .copyWith(color: Colors.white),
                  children: [
                    const TextSpan(text: 'Bem-vindo, '),
                    TextSpan(
                        text: 'NOME',
                        style: Theme.of(context).textTheme.bodyLarge!.copyWith(
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
                    Text('NOME',
                        style: Theme.of(context)
                            .textTheme
                            .titleLarge!
                            .copyWith(color: Colors.white)),
                    Text('INSTITUICAO',
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
                      style: Theme.of(context).textTheme.headlineSmall,
                    ),
                  ),
                  SingleChildScrollView(
                    scrollDirection: Axis.horizontal,
                    child: Row(children: [
                      const SizedBox(width: 30),
                      FixedMenuItem(
                        text: 'Mono',
                        icon: Container(
                            height: 40, width: 40, color: Colors.black54),
                        onTap: () => dev.log('LOL'),
                      ),
                      const SizedBox(width: 30),
                    ]),
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
                  style: Theme.of(context).textTheme.headlineSmall,
                ),
              ),
            ),
          ),
          SliverFixedExtentList(
            itemExtent: 100,
            delegate: SliverChildListDelegate([
              const Text('Sim1'),
              const Text('Sim2'),
              const Text('Sim3'),
              const Text('Sim4'),
            ]),
          ),
        ],
      ),
    );
  }
}
