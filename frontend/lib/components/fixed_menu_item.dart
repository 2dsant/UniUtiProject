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
    return GestureDetector(
      onTap: onTap,
      child: Container(
        margin: const EdgeInsets.all(10),
        decoration: BoxDecoration(
          gradient: UniUtiBgGradient4(),
          borderRadius: BorderRadius.circular(11),
          boxShadow: [
            BoxShadow(
              color: UniUtiColors.green.withAlpha(150),
              blurRadius: 5,
            ),
          ],
        ),
        width: 125,
        height: 110,
        child: Container(
          margin: EdgeInsets.all(3),
          decoration: BoxDecoration(
              color: Colors.grey.shade100,
              borderRadius: BorderRadius.circular(9)),
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
