//import 'dart:js';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'dart:typed_data';
import 'package:flutter/services.dart';
import 'package:flutter_api/activeIngredients.dart';
import 'package:flutter_api/brands.dart';
import 'package:flutter_api/categories.dart';
import 'package:flutter_api/home.dart';
import 'package:http/http.dart' as http;
//import 'package:overflow_view/overflow_view.dart';
//import 'package:image/image.dart';
void main() {
  runApp(MaterialApp(
    //home: PharmacyApp(),
    //initialRoute: '/',
    routes: {
      '/':(context)=>PharmacyApp(),
      '/home':(context)=>homePage(),
      '/brands':(context)=>brandsPage(),
      '/categories': (context)=>categoriesPage(),
      '/activeIngredients':(context)=>activeIngredientsPage(),
    },
  ));
}

Image img = Image.asset('images/pharmacyLogo.jpg');
Image img1 = Image.asset('images/snake.jpg');

class PharmacyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          toolbarHeight: 70,
          //backgroundColor: Color(0xFFABB0C7),
         // backgroundColor: Color(0xFFBBBFD4),//truuuue
           backgroundColor: Color(0xFFA0CED5),
          centerTitle: true,
          leading: Container(
            margin: const EdgeInsets.only(left: 10.0, top: 3.0, bottom: 3.0),
            decoration: BoxDecoration(
                color: Colors.white,
                image: DecorationImage(image: img.image),
                border: Border.all(color: Colors.white, width: 1.0),
                shape: BoxShape.circle),
          ),
          title: const Text("Pharmacy Training Application"),
          titleTextStyle: const TextStyle(
              fontWeight: FontWeight.bold,
              fontSize: 22.0,
              color: Color(0xFF242424),
              fontFamily: 'Roboto Condensed'),
        ),
        body: Container(
          decoration: BoxDecoration(
            gradient: LinearGradient(
                begin: Alignment.topCenter,
                end: Alignment.bottomCenter,
              colors:[
                //truuue
               /* Color(0xFFABB0CC),
                Color(0xFFDCD7E4),
                Color(0xFFE6DADF),
                Color(0xFFD5CED1),*/
               // Color(0xFFA0CED5),
               // Color(0xFFA1CADC),
                Color(0xFFA8C4DC),
                Color(0xFFC8D5DD),
                //Color(0xFFD5CAD7),
                Color(0xFFD0CCD7),
                Color(0xFFDCC9CF),
              ]
            )
          ),
          padding: const EdgeInsets.symmetric(horizontal: 10, vertical: 20),
            child: Column(children: [
              Row(
                 children:[
                Container(
                   padding: const EdgeInsets.all(80),
                  margin: const EdgeInsets.only(top: 50,left: 115,right: 115,bottom: 50),
                   /*decoration: BoxDecoration(
                     image: DecorationImage(
                         image: img1.image),
               ),*/

              )
                 ,]
              ),
              const Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                Text(
                  "Online Pharmacy Training App",
                  style: TextStyle(
                    color: Colors.black87,
                    fontSize: 25,
                    fontWeight: FontWeight.bold,
                    fontFamily: 'Roboto Condensed',
                    wordSpacing: 5,
                  ),
                  textAlign: TextAlign.center,
                ),
              ]),
              const Row(
                mainAxisAlignment: MainAxisAlignment.center,
                textDirection: TextDirection.ltr,
                verticalDirection: VerticalDirection.down,
                children: [
                  Flexible(
                      child: Text(
                    "Pharmacy Training App helps you training on all"
                    " medicines online, and pass exams that give you"
                    "certificates that assure you take the training plan  ",
                    style: TextStyle(
                      color: Colors.black54,
                      fontSize: 20,
                      fontWeight: FontWeight.bold,
                      fontFamily: 'Roboto Condensed',
                      wordSpacing: 5,
                    ),
                    textAlign: TextAlign.center,
                  ))
                ],
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Container(
                    margin: const EdgeInsets.only(top:40),
                  child: TextButton(
                    style: TextButton.styleFrom(
                      backgroundColor: Colors.teal[700],
                      alignment: Alignment.center,
                      padding: const EdgeInsets.only(left: 100, right: 100,top:10,bottom: 10),
                    ),
                    onPressed: () {
                      loginPage(context);
                    },
                    child: const Text(
                      "Login",
                      style: TextStyle(
                          fontWeight: FontWeight.bold,
                          fontSize: 20,
                          color: Colors.white70),
                    ),
                  ),
                  ),
                ]
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Container(
                    margin: const EdgeInsets.only(top:0),
                    child: TextButton(
                      style: TextButton.styleFrom(
                        backgroundColor: Colors.teal[700],
                        alignment: Alignment.center,
                        padding: const EdgeInsets.only(left: 70, right: 70,top:10,bottom: 10),
                      ),
                      onPressed: () {
                        /*runApp(MaterialApp(
                          home: homePage(),
                        ));*/
                        Navigator.pushNamed(context, '/home');
                      },
                      child: const Text(
                        "Go To home",
                        style: TextStyle(
                          fontWeight: FontWeight.bold,
                          fontSize: 20,
                          color: Colors.white70
                        ),
                      ),
                    ),
                  )
                ],
              ),
            ]),
        )
    );
  }
}

void loginPage(BuildContext context) {
  showDialog(
      context: context,
      builder: (BuildContext buildContext) {
        return AlertDialog(
          /*icon:const Icon(Icons.close_outlined,
            size: 40,
            weight: 40,
          ),
          iconPadding: const EdgeInsets.only(left: 250),
          iconColor: Colors.green[400],*/
          scrollable: true,
          backgroundColor: Colors.white,
          shadowColor: Colors.teal,
          title: const Text(
            "Login",
            textAlign: TextAlign.center,
          ),
          titleTextStyle: TextStyle(
            color: Colors.teal[700],
            fontWeight: FontWeight.bold,
            fontSize: 30,
          ),
          content: Padding(
            padding: const EdgeInsets.all(10.0),
            child: Form(
              child: Column(
                children: <Widget>[
                  TextFormField(
                    decoration: InputDecoration(
                      labelText: 'Email',
                      iconColor: Colors.teal[700],
                      labelStyle: TextStyle(
                          color: Colors.teal[700],
                          fontWeight: FontWeight.bold),
                      icon: const Icon(Icons.email),
                    ),
                  ),
                  TextFormField(
                    decoration: InputDecoration(
                      labelText: 'Password',
                      iconColor: Colors.teal[700],
                      labelStyle: TextStyle(
                          color: Colors.teal[700],
                          fontWeight: FontWeight.bold),
                      icon: const Icon(Icons.lock),
                    ),
                  ),
                  Container(
                    padding: const EdgeInsets.only(top: 20),
                    child: const Text("Don't have an account?",
                        style: TextStyle(
                            color: Colors.black87,
                            fontWeight: FontWeight.bold,
                            fontSize: 15)),
                  ),
                  TextButton(
                    style: TextButton.styleFrom(
                        textStyle: TextStyle(
                            color: Colors.teal[700],
                            fontSize: 15,
                            decoration: TextDecoration.underline)),
                    onPressed: () {
                      Navigator.pop(context);
                      registerPage(context);
                    },
                    child: Text(
                      "Register",
                      style: TextStyle(
                        color: Colors.teal[700],
                        fontWeight: FontWeight.bold,
                        fontSize: 15,
                      ),
                    ),
                  ),
                  TextButton(
                    style: TextButton.styleFrom(
                      backgroundColor: Colors.grey[300],
                    ),
                    onPressed: () {
                      Navigator.pop(context);
                    },
                    child: const Text(
                      "Close",
                      style: TextStyle(
                          fontSize: 15,
                          color: Colors.black87,
                          fontWeight: FontWeight.bold),
                    ),
                  )
                ],
              ),
            ),
          ),
        );
      });
}

void registerPage(BuildContext context) {
  showDialog(
      context: context,
      builder: (BuildContext buildContext) {
        return AlertDialog(
          scrollable: true,
          backgroundColor: Colors.white,
          shadowColor: Colors.teal,
          title: const Text(
            "Register",
            textAlign: TextAlign.center,
          ),
          titleTextStyle: TextStyle(
            color: Colors.teal[700],
            fontWeight: FontWeight.bold,
            fontSize: 30,
          ),
          content: Padding(
            padding: const EdgeInsets.all(5.0),
            child: Form(
              child: Column(
                children: <Widget>[
                  TextFormField(
                    decoration: InputDecoration(
                      labelText: 'First Name',
                      iconColor: Colors.teal[700],
                      labelStyle: TextStyle(
                        color: Colors.teal[700],
                        fontWeight: FontWeight.bold,
                      ),
                      icon: const Icon(Icons.account_box),
                    ),
                  ),
                  TextFormField(
                    decoration: InputDecoration(
                      labelText: 'Last Name',
                      iconColor: Colors.teal[700],
                      labelStyle: TextStyle(
                          color: Colors.teal[700],
                          fontWeight: FontWeight.bold),
                      icon: const Icon(Icons.account_box),
                    ),
                  ),
                  TextFormField(
                    decoration: InputDecoration(
                      labelText: 'Email',
                      iconColor: Colors.teal[700],
                      labelStyle: TextStyle(
                          color: Colors.teal[700],
                          fontWeight: FontWeight.bold),
                      icon: const Icon(Icons.email),
                    ),
                  ),
                  TextFormField(
                    decoration: InputDecoration(
                      labelText: 'Password',
                      iconColor: Colors.teal[700],
                      labelStyle: TextStyle(
                          color: Colors.teal[700],
                          fontWeight: FontWeight.bold),
                      icon: const Icon(Icons.lock),
                    ),
                  ),
                  TextFormField(
                    decoration: InputDecoration(
                      labelText: 'Confirm Password',
                      iconColor: Colors.teal[700],
                      labelStyle: TextStyle(
                          color: Colors.teal[700],
                          fontWeight: FontWeight.bold),
                      icon: const Icon(Icons.lock),
                    ),
                  ),
                  TextFormField(
                    decoration: InputDecoration(
                      labelText: 'Birth Date',
                      iconColor: Colors.teal[700],
                      labelStyle: TextStyle(
                          color: Colors.teal[700],
                          fontWeight: FontWeight.bold),
                      icon: const Icon(Icons.calendar_month),
                    ),
                  ),
                  TextFormField(
                    decoration: InputDecoration(
                      labelText: 'City',
                      iconColor: Colors.teal[700],
                      labelStyle: TextStyle(
                          color: Colors.teal[700],
                          fontWeight: FontWeight.bold),
                      icon: const Icon(Icons.location_city),
                    ),
                  ),
                  Container(
                    padding: const EdgeInsets.only(top: 20),
                    child: const Text("Already have an account?",
                        style: TextStyle(
                            color: Colors.black87,
                            fontWeight: FontWeight.bold,
                            fontSize: 15)),
                  ),
                  TextButton(
                    style: TextButton.styleFrom(
                        textStyle: TextStyle(
                            color: Colors.teal[700],
                            fontSize: 15,
                            decoration: TextDecoration.underline)),
                    onPressed: () {
                      Navigator.pop(context);
                      loginPage(context);
                    },
                    child: Text(
                      "Login",
                      style: TextStyle(
                        color: Colors.teal[700],
                        fontWeight: FontWeight.bold,
                        fontSize: 18,
                      ),
                    ),
                  ),
                  TextButton(
                    style: TextButton.styleFrom(
                      backgroundColor: Colors.grey[300],
                    ),
                    onPressed: () {
                      Navigator.pop(context);
                    },
                    child: const Text(
                      "Close",
                      style: TextStyle(
                          fontSize: 15,
                          color: Colors.black87,
                          fontWeight: FontWeight.bold),
                    ),
                  )
                ],
              ),
            ),
          ),
        );
      });
}

