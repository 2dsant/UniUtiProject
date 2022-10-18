import 'package:flutter/material.dart';

class UniUtiSlideTransition implements PageTransitionsBuilder {
  @override
  Widget buildTransitions<T>(
      PageRoute<T> route,
      BuildContext context,
      Animation<double> animation,
      Animation<double> secondaryAnimation,
      Widget child) {
    return CustomTransition.slide(
      context,
      animation,
      secondaryAnimation,
      child,
    );
  }
}

class CustomTransition extends PageRouteBuilder {
  CustomTransition({
    required Widget target,
    int miliseconds = 400,
    RouteTransitionsBuilder transitionsBuilder = CustomTransition.slide,
    bool barrierColor = true,
  }) : super(
          pageBuilder: (ctx, anim, secdAnim) => target,
          transitionDuration: Duration(milliseconds: miliseconds),
          transitionsBuilder: transitionsBuilder,
          barrierColor: barrierColor ? Colors.black.withAlpha(100) : null,
        );

  static Widget fade(BuildContext context, Animation<double> animation,
      Animation<double> secondaryAnimation, Widget child) {
    animation = CurvedAnimation(curve: Curves.easeInCirc, parent: animation);
    return FadeTransition(child: child, opacity: animation);
  }

  static Widget rotate(BuildContext context, Animation<double> animation,
      Animation<double> secondaryAnimation, Widget child) {
    animation = CurvedAnimation(curve: Curves.linear, parent: animation);
    return RotationTransition(
      turns: animation,
      alignment: Alignment.bottomCenter,
      child: child,
    );
  }

  static Widget scale(BuildContext context, Animation<double> animation,
      Animation<double> secondaryAnimation, Widget child) {
    animation = CurvedAnimation(curve: Curves.easeInCubic, parent: animation);
    return ScaleTransition(child: child, scale: animation);
  }

  static Widget slide(BuildContext context, Animation<double> animation,
      Animation<double> secondaryAnimation, Widget child) {
    animation = CurvedAnimation(
        curve: Curves.easeInCubic,
        reverseCurve: Curves.easeOut,
        parent: animation);
    return SlideTransition(
        child: child,
        position: Tween(
          begin: const Offset(1.0, 0.0),
          end: const Offset(0.0, 0.0),
        ).animate(animation));
  }
}
