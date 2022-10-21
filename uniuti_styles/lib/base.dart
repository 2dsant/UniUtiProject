part of 'uniuti_styles.dart';

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
  static MaterialColor orange = createMaterialColor(const Color(0xFFE57447));
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

class UniUtiBgGradient2 extends LinearGradient {
  UniUtiBgGradient2()
      : super(
          colors: [
            UniUtiColors.purple,
            UniUtiColors.purple.shade900,
          ],
          begin: Alignment.topCenter,
          end: Alignment.bottomCenter,
        );
}

class UniUtiBgGradient3 extends LinearGradient {
  UniUtiBgGradient3()
      : super(
          colors: [
            UniUtiColors.purple,
            UniUtiColors.blue,
          ],
          begin: Alignment.topCenter,
          end: Alignment.bottomCenter,
        );
}

class UniUtiBgGradient4 extends LinearGradient {
  UniUtiBgGradient4()
      : super(
          colors: [
            UniUtiColors.blue,
            UniUtiColors.green,
          ],
          begin: Alignment.topCenter,
          end: Alignment.bottomCenter,
        );
}

final uniUtiSloganTextStyle = TextStyle(
  fontSize: 18,
  fontFamily: GoogleFonts.inter().fontFamily,
  color: Colors.white,
);

final uniUtiThemeData = ThemeData(
  textTheme: GoogleFonts.rajdhaniTextTheme().copyWith(
    displaySmall: GoogleFonts.rajdhaniTextTheme().displaySmall!.copyWith(
          fontWeight: FontWeight.bold,
          color: Colors.black87,
        ),
    headlineLarge: GoogleFonts.rajdhaniTextTheme().headlineLarge!.copyWith(
          // fontSize: 24,
          fontWeight: FontWeight.bold,
          color: Colors.black54,
        ),
    headlineSmall: GoogleFonts.rajdhaniTextTheme().headlineSmall!.copyWith(
          // fontSize: 24,
          fontWeight: FontWeight.bold,
          color: Colors.black54,
        ),
    titleLarge: GoogleFonts.rajdhaniTextTheme().titleLarge!.copyWith(
          fontSize: 20,
          fontWeight: FontWeight.bold,
          color: Colors.black54,
        ),
    titleMedium: GoogleFonts.rajdhaniTextTheme().titleMedium!.copyWith(
          fontWeight: FontWeight.bold,
          color: Colors.black87,
        ),
    titleSmall: GoogleFonts.rajdhaniTextTheme().titleSmall!.copyWith(
          fontWeight: FontWeight.bold,
          color: Colors.black54,
        ),
    bodyMedium: GoogleFonts.rajdhaniTextTheme().bodyMedium!.copyWith(
          fontSize: 16,
        ),
  ),
  appBarTheme: AppBarTheme(
    iconTheme: IconThemeData(
      color: UniUtiColors.green,
    ),
  ),
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

const uniUtiPrimaryBtnLbl = TextStyle(
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

const uniUtiSecondaryBtnLbl = TextStyle(
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
      floatingLabelAlignment: FloatingLabelAlignment.center,
      errorStyle: const TextStyle(
        color: Colors.white,
        fontWeight: FontWeight.bold,
        fontSize: 14,
      ),
      focusedErrorBorder: OutlineInputBorder(
        borderRadius: BorderRadius.circular(20),
        borderSide: BorderSide(
          color: UniUtiColors.orange,
          width: 4,
          style: BorderStyle.solid,
        ),
      ),
      errorBorder: OutlineInputBorder(
        borderRadius: BorderRadius.circular(10),
        borderSide: BorderSide(
          color: UniUtiColors.orange,
          width: 2,
          style: BorderStyle.solid,
        ),
      ),
      focusedBorder: OutlineInputBorder(
        borderRadius: BorderRadius.circular(20),
        borderSide: BorderSide(
          color: UniUtiColors.green,
          width: 4,
        ),
        gapPadding: 8,
      ),
      border: OutlineInputBorder(
        borderRadius: BorderRadius.circular(10),
        borderSide: BorderSide.none,
        gapPadding: 8,
      ),
    );
