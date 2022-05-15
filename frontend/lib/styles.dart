import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

MaterialColor createMaterialColor(Color color) {
  List strengths = <double>[.05];
  Map<int, Color> swatch = {};
  final int r = color.red, g = color.green, b = color.blue;

  for (int i = 1; i < 10; i++) {
    strengths.add(0.1 * i);
  }
  for (var strength in strengths) {
    final double ds = 0.5 - strength;
    swatch[(strength * 1000).round()] = Color.fromRGBO(
      r + ((ds < 0 ? r : (255 - r)) * ds).round(),
      g + ((ds < 0 ? g : (255 - g)) * ds).round(),
      b + ((ds < 0 ? b : (255 - b)) * ds).round(),
      1,
    );
  }
  return MaterialColor(color.value, swatch);
}

abstract class UniUtiColors {
  static MaterialColor green = createMaterialColor(const Color(0xFF03D161));
  static MaterialColor blue = createMaterialColor(const Color(0xFF4796E5));
  static MaterialColor purple = createMaterialColor(const Color(0xFF8458EF));
}

class UniUtiBgGradient extends LinearGradient {
  UniUtiBgGradient()
      : super(
          colors: [
            UniUtiColors.green,
            UniUtiColors.blue,
            UniUtiColors.purple,
          ],
          begin: Alignment.topCenter,
          end: Alignment.bottomCenter,
        );
}

final uniUtiThemeData = ThemeData(
  textTheme: GoogleFonts.rajdhaniTextTheme(),
  primarySwatch: UniUtiColors.green,
);

final uniUtiPrimaryBtn = ElevatedButton.styleFrom(
  elevation: 5,
  primary: Colors.black,
  onPrimary: Colors.white,
  shape: RoundedRectangleBorder(
    borderRadius: BorderRadius.circular(10),
  ),
);

final uniUtiPrimaryBtnLbl = TextStyle(
  fontWeight: FontWeight.bold,
  fontSize: 18,
  color: Colors.white,
);

final uniUtiSecondaryBtn = ElevatedButton.styleFrom(
  elevation: 5,
  primary: Colors.white,
  onPrimary: Colors.black,
  shape: RoundedRectangleBorder(
    borderRadius: BorderRadius.circular(10),
  ),
);

final uniUtiSecondaryBtnLbl = TextStyle(
  fontWeight: FontWeight.bold,
  fontSize: 18,
  color: Colors.black,
);

InputDecoration uniUtiInputDecoration(String placeholder) => InputDecoration(
      filled: true,
      fillColor: Colors.white,
      floatingLabelBehavior: FloatingLabelBehavior.never,
      labelText: placeholder,
      contentPadding: const EdgeInsets.fromLTRB(25, 20, 25, 20),
      border: OutlineInputBorder(
        borderRadius: BorderRadius.circular(10),
        borderSide: BorderSide.none,
        gapPadding: 8,
      ),
    );
