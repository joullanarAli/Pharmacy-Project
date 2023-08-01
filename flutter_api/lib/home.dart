//import 'dart:js';

//import 'dart:html';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'dart:typed_data';
import 'package:flutter/services.dart';
import 'package:flutter_api/brands.dart';

import 'main.dart';

//import 'package:overflow_view/overflow_view.dart';
//import 'package:image/image.dart';
void main() {
  runApp(MaterialApp(
    home: homePage(),
  ));
}

Image img = Image.asset('images/pharmacyLogo.jpg');
Image img1 = Image.asset('images/snake.jpg');

class homePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        toolbarHeight: 70,
        //backgroundColor: Color(0xFFBBBFD4),
        backgroundColor: const Color(0xFFA0CED5),

        centerTitle: true,
        leading: BackButton(
          color: Colors.black,
          onPressed: () {
            Navigator.pushNamed(context, '/');
          },
        ),
        title: const Text("Pharmacy Training Application"),
        titleTextStyle: const TextStyle(
            fontWeight: FontWeight.bold,
            fontSize: 22.0,
            color: Color(0xFF242424),
            fontFamily: 'Roboto Condensed'),
      ),
      body: Container(
        decoration:  BoxDecoration(
          gradient: LinearGradient(
              begin: Alignment.topCenter,
              end: Alignment.bottomCenter,
           //   stops: [0.9, 0.1],
            colors: [
              Color(0xFFA0CED5),
              Color(0xFFA1CADC),
              Color(0xFFA8C4DC),
              Color(0xFFC8D5DD),
              Color(0xFFD5CAD7),
              Color(0xFFD0CCD7),
              Color(0xFFDCC9CF),
              /*Color(0xFFD3E1E0),
              Color(0xFFD3E5E8),
              Color(0xFFD4E4EA),
              Color(0xFFD5E1EA),
              Color(0xFFDADBE4),
              Color(0xFFE1DDE9),
              Color(0xFFE3D7E4),
              Color(0xFFEBD8DE),*/
            //  Color(0xFFB2CBB3),
             /* Color(0xFFA0CED5),
              Color(0xFFA1CADC),
              Color(0xFFA8C4DC),
              Color(0xFFC8D5DD),
              Color(0xFFD5CAD7),
              Color(0xFFD0CCD7),
              Color(0xFFDCC9CF),*/
              /*Color(0xFF84C2BB),
              Color(0xFF8BB9CE),
              //Color(0xFF8AAFCC),
              Color(0xFFA2C4D4),
              Color(0xFFC4C7D8),
              Color(0xFFD7D3DD),
              Color(0xFFD1CCDA),*/
             /* Color(0xFFBACCCF),
              Color(0xFFB1CDE4),
              Color(0xFFBAC5CD),
              Color(0xFFB9BCD4),
              Color(0xFFD2CDD8),
              Color(0xFFD6CCD8),
              Color(0xFFD9CFDB),
              //  Color(0xFFB4B9D3),
            //  Color(0xFFE3CDD5),
              Color(0xFFE4D4D9),*/
              /*Color(0xFFABB0CC),
              Color(0xFFDCD7E4),
             // Color(0xFFCDB4D1),
              Color(0xFFE6DADF),
              Color(0xFFD5CED1)*/


            ]
          )
        ),
        padding: const EdgeInsets.symmetric(horizontal: 10, vertical: 5),
        child: Column(children: [
          Row(children: [
            Container(
              padding: const EdgeInsets.all(50),
              margin: const EdgeInsets.only(
                  top: 20, left: 145, right: 145, bottom: 20),
              decoration: BoxDecoration(
                image: DecorationImage(image: img1.image),
              ),
            ),
          ]),
          Container(
            margin: const EdgeInsets.only(left: 0),
            child: Column(
              children: [
                Text(
                  "View by:",
                  style: TextStyle(
                      color: Colors.green[700],
                      fontWeight: FontWeight.bold,
                      fontSize: 30),
                ),
                Row(
                  children: [
                    Container(
                        margin: const EdgeInsets.only(top: 19, left: 0),
                        child: TextButton(
                          style: TextButton.styleFrom(),
                          onPressed:(){ Navigator.pushNamed(context, '/categories');},
                          child: Column(children: [
                            Container(
                                height: 60,
                                width: 60,
                                decoration: BoxDecoration(
                                  color: Colors.green[100],
                                  shape: BoxShape.circle,
                                ),
                                child: Icon(
                                  Icons.apps,
                                  size: 40,
                                  color: Colors.yellow[900],
                                )),
                            Text(
                              "Categories",
                              style: TextStyle(
                                color: Colors.green[800],
                                fontWeight: FontWeight.bold,
                                fontSize: 20
                              ),
                            ),
                          ]),
                        )
                    ),
                    Container(
                        margin: const EdgeInsets.only(top: 19, left: 0),
                        child: TextButton(
                          style: TextButton.styleFrom(),
                          onPressed: (){
                           /* runApp(MaterialApp(
                              home: brandsPage(),
                            ));*/
                            Navigator.pushNamed(context, '/brands');
                          },
                          child: Column(children: [
                            Container(
                                height: 60,
                                width: 60,
                                decoration: BoxDecoration(
                                  color: Colors.green[100],
                                  shape: BoxShape.circle,
                                ),
                                child: Icon(
                                  Icons.store,
                                  size: 40,
                                  color: Colors.purple[700],
                                )),
                            Text(
                              "Brands",
                              maxLines: 2,
                              overflow: TextOverflow.ellipsis,
                              //textAlign: TextAlign.center,
                              style: TextStyle(
                                color: Colors.green[800],
                                fontWeight: FontWeight.bold,
                                fontSize: 20
                              ),
                            ),
                          ]),
                        )
                    ),
                    Container(
                        margin: const EdgeInsets.only(top: 19, left: 2),
                        child: TextButton(
                          style: TextButton.styleFrom(),
                          onPressed: null,
                          child: Column(children: [
                            Container(
                                height: 60,
                                width: 60,
                                decoration: BoxDecoration(
                                  color: Colors.green[100],
                                  shape: BoxShape.circle,
                                ),
                                child: Icon(
                                  Icons.medication,
                                  size: 40,
                                  color: Colors.red[700],
                                )),
                            Text(
                              "Drugs",
                              style: TextStyle(
                                color: Colors.green[800],
                                fontWeight: FontWeight.bold,
                                fontSize: 20
                              ),
                            ),
                          ]),
                        )
                    ),
                    Container(
                        margin: const EdgeInsets.only(top: 19, left: 0),
                        child: TextButton(
                          style: TextButton.styleFrom(),
                          onPressed: (){
                            Navigator.pushNamed(context, '/activeIngredients');
                          },
                          child: Column(children: [
                            Container(
                                height: 60,
                                width: 60,
                                decoration: BoxDecoration(
                                  color: Colors.green[100],
                                  shape: BoxShape.circle,
                                ),
                                child: Icon(
                                  Icons.local_pharmacy,
                                  size: 40,
                                  color: Colors.blue[700],
                                )),
                             /* Text(
                              "Actve",
                              style: TextStyle(
                                color: Colors.green[800],
                                fontWeight: FontWeight.bold,
                              ),
                            ),*/
                            Text(
                              "Ingredients",
                              style: TextStyle(
                                color: Colors.green[800],
                                fontWeight: FontWeight.bold,
                                fontSize: 20
                              ),
                            )
                            ])
                            ),
                        )
                    ]),
              ],
            ),
          ),
      ]),
      )
    );
  }
}
