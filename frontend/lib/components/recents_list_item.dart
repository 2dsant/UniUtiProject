import 'dart:developer' as dev;

import 'package:flutter/material.dart';

import '../models/models.dart';
import '../styles.dart';

class RecentsListItem extends StatelessWidget {
  const RecentsListItem({Key? key, required this.model}) : super(key: key);
  final Monitoria model;
  @override
  Widget build(BuildContext context) {
    return Material(
      child: InkWell(
        onTap: () => dev.log('lol'),
        child: Container(
          margin: const EdgeInsets.fromLTRB(33, 10, 16, 10),
          child: Row(
            children: [
              Container(
                width: 106,
                decoration: BoxDecoration(
                  color: Colors.grey.shade400,
                  borderRadius: BorderRadius.circular(8),
                ),
              ),
              const SizedBox(width: 12),
              Expanded(
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  mainAxisSize: MainAxisSize.max,
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    Text(
                      model.titulo,
                      maxLines: 1,
                      overflow: TextOverflow.fade,
                      style: Theme.of(context).textTheme.titleMedium!.copyWith(
                          fontWeight: FontWeight.bold, color: Colors.black87),
                    ),
                    Text(
                      // TODO: Guardar data de anuncio
                      'Anunciado em: 00/00/0000',
                      style: Theme.of(context).textTheme.titleSmall!.copyWith(
                            fontWeight: FontWeight.bold,
                            color: Colors.black54,
                          ),
                      maxLines: 1,
                      overflow: TextOverflow.fade,
                    ),
                    Text(
                      model.descricao,
                      overflow: TextOverflow.ellipsis,
                      maxLines: 2,
                    ),
                    Divider(
                      thickness: 2,
                      color: UniUtiColors.green,
                      height: 5,
                      endIndent: 12,
                      indent: 12,
                    ),
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
