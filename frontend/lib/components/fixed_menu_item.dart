import 'package:flutter/material.dart';

import '../styles.dart';

class FixedMenuItem extends StatelessWidget {
  const FixedMenuItem(
      {Key? key, required this.text, required this.icon, required this.onTap})
      : super(key: key);

  final String text;
  final Widget icon;
  final GestureTapCallback onTap;

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: const EdgeInsets.all(10),
      decoration: BoxDecoration(
        gradient: UniUtiBgGradient4(),
        borderRadius: BorderRadius.circular(11),
        boxShadow: [
          BoxShadow(
            color: UniUtiColors.green.withAlpha(150),
            blurRadius: 5,
            offset: const Offset(1, 1),
          ),
        ],
      ),
      padding: const EdgeInsets.all(3),
      width: 125,
      height: 110,
      child: Material(
        borderRadius: BorderRadius.circular(9),
        child: InkWell(
          onTap: onTap,
          child: Column(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            mainAxisSize: MainAxisSize.max,
            children: [
              icon,
              Text(text),
            ],
          ),
        ),
      ),
    );
  }
}
