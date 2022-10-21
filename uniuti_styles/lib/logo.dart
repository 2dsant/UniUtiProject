part of 'uniuti_styles.dart';

class UniUtiLogo extends StatelessWidget {
  const UniUtiLogo({super.key});

  @override
  Widget build(BuildContext context) {
    // TODO: Verificar exportacao de assets
    return SvgPicture.asset('assets/logo.svg');
  }
}
