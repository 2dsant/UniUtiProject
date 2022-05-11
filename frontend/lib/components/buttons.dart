import 'package:flutter/material.dart';

import '../styles.dart';

class UniUtiPrimaryButton extends StatelessWidget {
  const UniUtiPrimaryButton(
      {Key? key, required this.title, required this.onTap})
      : super(key: key);
  final String title;
  final Function onTap;
  @override
  Widget build(BuildContext context) {
    return ElevatedButton(
      style: uniUtiPrimaryBtn,
      onPressed: () => onTap.call(),
      child: Padding(
        padding: const EdgeInsets.symmetric(vertical: 20),
        child: Text(
          title,
          style: uniUtiPrimaryBtnLbl,
        ),
      ),
    );
  }
}

class UniUtiSecondaryButton extends StatelessWidget {
  const UniUtiSecondaryButton(
      {Key? key, required this.title, required this.onTap})
      : super(key: key);
  final String title;
  final Function onTap;
  @override
  Widget build(BuildContext context) {
    return ElevatedButton(
      style: uniUtiSecondaryBtn,
      onPressed: () => onTap.call(),
      child: Padding(
        padding: const EdgeInsets.symmetric(vertical: 20),
        child: Text(
          title,
          style: uniUtiSecondaryBtnLbl,
        ),
      ),
    );
  }
}
