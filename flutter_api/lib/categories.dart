//import 'dart:js';

//import 'dart:html';

import 'dart:collection';
import 'dart:convert';
import 'dart:io';

//import 'dart:html';
//import 'dart:js_util';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'dart:typed_data';
import 'package:flutter/services.dart';
import 'package:http/http.dart';

import 'package:http/http.dart' as http;
import 'package:http_parser/http_parser.dart';
import 'main.dart';
import 'services/Category.dart';

//import 'package:overflow_view/overflow_view.dart';
//import 'package:image/image.dart';

Image img = Image.asset('images/pharmacyLogo.jpg');
Image img1 = Image.asset('images/snake.jpg');
List<Image> images = [];
class categoriesPage extends StatefulWidget {
  _categoriesState createState() => _categoriesState();
}

class _categoriesState extends State<categoriesPage> {
  List<Category> categories = [];
  List<Category> displayedList = [];


  void getData() async {
    var url = Uri.parse('http://10.0.2.2:5191/Categories');
    Response response = await get(url);
    print(response.body);
    final List<dynamic> jsonList = json.decode(response.body);
    categories = jsonList.map((json) => toCategory(json)).toList();
    for (int i = 0; i < categories.length; i++) {
      displayedList.add(categories[i]);
    }
    for (int j = 0; j < categories.length; j++) {
      setState(() {});
    }
  }

    Category toCategory(Map<String, dynamic> map) {
      Category category = Category(map['name'] );
      return category;
    }

    @override
    void initState() {
      getData();
      super.initState();
    }
    void updateList(String value) {
      setState(() {
        displayedList = categories.where((element) =>
            element.name.toLowerCase().contains(value.toLowerCase())).toList();
      });
    }
    @override
    Widget build(BuildContext context) {
      return Scaffold(
        resizeToAvoidBottomInset: false,
          appBar: AppBar(
            toolbarHeight: 70,
            backgroundColor: const Color(0xFFA0CED5),
            centerTitle: true,
            leading: BackButton(
              color: Colors.black,
              onPressed: () {
                Navigator.pushNamed(context, '/home');
              },
            ),
            title: const Text("All Categories"),
            titleTextStyle: const TextStyle(
                fontWeight: FontWeight.bold,
                fontSize: 22.0,
                color: Color(0xFF242424),
                fontFamily: 'Roboto Condensed'),
          ),
          body:SingleChildScrollView(
            scrollDirection: Axis.vertical,
              //shrinkWrap: true,
             // slivers:[
              child:  Container(
                height: 600,
                padding: const EdgeInsets.only(bottom: 30, top: 20),
                decoration: const BoxDecoration(
                    gradient: LinearGradient(
                        begin: Alignment.topCenter,
                        end: Alignment.bottomCenter,
                        colors: [
                          Color(0xFFA0CED5),
                          Color(0xFFA1CADC),
                          Color(0xFFA8C4DC),
                          Color(0xFFC8D5DD),
                          Color(0xFFD5CAD7),
                          Color(0xFFD0CCD7),
                          Color(0xFFDCC9CF),
                        ])),
                child: Center(
                  child: Column(
                    children: [
                      Row(
                          children: [Container(
                            width: 387,
                            margin: EdgeInsets.only(left: 10,right: 10,top:10,bottom:20),
                            child: TextField(
                              onChanged: (value) => updateList(value),
                              decoration: InputDecoration(
                                  prefixIcon: Icon(Icons.search, size: 25,),
                                  prefixIconColor: Colors.teal[700],
                                  hintText: 'Search by category\'s name',
                                  hintStyle: TextStyle(
                                      color: Colors.teal[700],
                                      fontSize: 20,
                                      fontWeight: FontWeight.bold
                                  ),
                                  //icon: Icon(Icons.search),
                                  filled: true,
                                  fillColor: Colors.white54,
                                  border: OutlineInputBorder(
                                      borderRadius: BorderRadius.circular(8.0),
                                      borderSide: BorderSide.none

                                  )
                              ),
                              style: const TextStyle(
                                color: Colors.black38,
                              ),
                            ),
                          ),
                          ]),
                        GridView.count(
                              crossAxisCount: 2,
                              mainAxisSpacing: 10,
                             // crossAxisSpacing: 5,
                          //    childAspectRatio: 1.0,
                        shrinkWrap: true,
                        children:[
                          for (int i = 0; i < displayedList.length; i++)

                         Column(children: [
                          Container(
                            height: 200,
                            width: 200,
                            margin: const EdgeInsets.symmetric(
                                vertical: 0, horizontal: 10),
                            padding: const EdgeInsets.symmetric(
                                vertical: 20, horizontal: 5),
                            decoration: BoxDecoration(
                              color: Colors.white60,
                              borderRadius: BorderRadius.circular(35),
                            ),
                            child: Row(children: [
                              Column(children: [
                                Container(
                                  margin: EdgeInsets.only(left: 0, top: 0,right: 55),
                                  child:TextButton(
                                  onPressed: () {
                                    Navigator.pushNamed(context, '/drug');
                                  },
                                  child: Text(
                                    displayedList[i].name,
                                    style: const TextStyle(
                                        fontWeight: FontWeight.bold,
                                        fontSize: 30.0,
                                        color: Color(0xFF242424),
                                        fontFamily: 'Roboto Condensed'),
                                    textAlign: TextAlign.center,
                                  ),
                                ),),
                                Container(
                                  width: 110,
                                  height: 80,
                                  margin: EdgeInsets.only(left: 55, top: 25),
                                  //padding: const EdgeInsets.all(0),
                                    /* child:
                                  Container(
                                    //  child: Image.file(fileImages[i]),
                                      margin: const EdgeInsets.only(
                                          left: 10.0, right: 10.0),*/
                                      decoration: BoxDecoration(
                                          color: Colors.white,
                                        /*  image: DecorationImage(
                                              image: FileImage(File(
                                                  displayedList[i].image)))*/

                                           //  image: DecorationImage(image: img.image),
                                          //  image: DecorationImage(image: images[i].image),
                                          //  image: Image.network(displayedList[i].image),
                                          border: Border.all(
                                              color: Colors.black87,
                                              width: 2.0),
                                          shape: BoxShape.circle)),

                              ],
                              ),

                            ]),
                          )
                        ]),
                          ],
                  ),

                ]),
              ))

          ));
    }

    @override
    State<StatefulWidget> createState() {
// TODO: implement createState
      throw UnimplementedError();
    }
  }

  @override
  Widget build(BuildContext context) {
    // TODO: implement build
    throw UnimplementedError();
  }