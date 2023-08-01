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
import 'services/Brands.dart';

//import 'package:overflow_view/overflow_view.dart';
//import 'package:image/image.dart';

Image img = Image.asset('images/pharmacyLogo.jpg');
Image img1 = Image.asset('images/snake.jpg');
List<Image> images = [];

class brandsPage extends StatefulWidget {
  _brandsState createState() => _brandsState();
}

class _brandsState extends State<brandsPage> {
  List<Brands> brands = [];
  List<Brands> displayedList = [];

  //late List<File> fileImages;
  List<File> fileImages = [];

  void getData() async {
    var url = Uri.parse('http://10.0.2.2:5191/Brands');
    Response response = await get(url);
    print(response.body);
    final List<dynamic> jsonList = json.decode(response.body);
/* final jsonList = json.decode(response.body);
final List<Brands> loadedBrands=[];
for(int i=0;i<jsonList.length;i++) {
loadedBrands.add(Brands(jsonList[i]['name']));
};
List<Brands> _items=loadedBrands;
for(int i=0;i<jsonList.length;i++){
print(json.decode(response.body));
}
return _items;*/
    brands = jsonList.map((json) => toBrand(json)).toList();
    print("brands");
    print(brands.length);
    for (int i = 0; i < brands.length; i++) {
      displayedList.add(brands[i]);
    }
    for (int j = 0; j < brands.length; j++) {
      // File file = File(brands[j].image);
      // fileImages.add(file);
      // uploadImage(brands[j].formFile);
      // images[j]=Image.asset(brands[j].image);
    }
    /*for(int j=0;j<brands.length;j++){
      String file=brands[j].image;
      var multipartFile = http.MultipartFile.fromBytes(
      'file',
      (await rootBundle.load(file)).buffer.asUint8List(),
      filename: brands[j].image, // use the real name if available, or omit
      contentType: MediaType('image', 'jpg'),
    );}*/
    print(fileImages.length);
    setState(() {});
  }

  Brands toBrand(Map<String, dynamic> map) {
    //Map<String,File> mapfile=map['formFile'];
    //   File file=mapfile as File;
    Brands brand = Brands(map['name'], map['image']);
    return brand;
  }

  /*void getImage() async {
    var url = Uri.parse('http://10.0.2.2:5191/Brands/GetBrandImage?id=16');
    Response response = await get(url);
    print(response.body);
    final List<dynamic> jsonList = json.decode(response.body);
  }*/

  @override
  void initState() {
    getData();
   // getImage();
    super.initState();
  }

  /*void uploadImage(File image) async {
    var multipartFile = http.MultipartFile.fromBytes(
      'file',
      (await rootBundle.load(image.path)).buffer.asUint8List(),
      filename: image.path, // use the real name if available, or omit
      contentType: MediaType('image', 'jpg'),
    );
  }*/

  void updateList(String value) {
    setState(() {
      displayedList = brands
          .where((element) =>
              element.name.toLowerCase().contains(value.toLowerCase()))
          .toList();
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          toolbarHeight: 70,
//backgroundColor: Color(0xFFABB0C7),
//backgroundColor: Color(0xFFBBBFD4),//truuuue
          backgroundColor: const Color(0xFFA0CED5),
          centerTitle: true,
          leading: BackButton(
            color: Colors.black,
            onPressed: () {
              Navigator.pushNamed(context, '/home');
            },
          ),
          title: const Text("All Brands"),
          titleTextStyle: const TextStyle(
              fontWeight: FontWeight.bold,
              fontSize: 22.0,
              color: Color(0xFF242424),
              fontFamily: 'Roboto Condensed'),
        ),
        body: SingleChildScrollView(
            child: Container(
          height: 600,
          padding: const EdgeInsets.only(bottom: 30, top: 20),
          decoration: const BoxDecoration(
              gradient: LinearGradient(
                  begin: Alignment.topCenter,
                  end: Alignment.bottomCenter,
                  colors: [
//truuue
/* Color(0xFFABB0CC),
Color(0xFFDCD7E4),
Color(0xFFE6DADF),
Color(0xFFD5CED1),*/
                Color(0xFFA0CED5),
                Color(0xFFA1CADC),
                Color(0xFFA8C4DC),
                Color(0xFFC8D5DD),
                Color(0xFFD5CAD7),
                Color(0xFFD0CCD7),
                Color(0xFFDCC9CF),
              ])),
          child: Center(
/*child: ListView.builder(
itemCount: brands.length,
padding: EdgeInsets.all(8.0),
itemBuilder: (BuildContext context, int position) {
return  ListTile(
title:  Text("${brands[position].name}"),
);
}),*/
            child: Column(
              children: [
                Row(children: [
                  Container(
                    width: 387,
                    margin: EdgeInsets.symmetric(horizontal: 10),
                    child: TextField(
                      onChanged: (value) => updateList(value),
                      decoration: InputDecoration(
                          prefixIcon: Icon(
                            Icons.search,
                            size: 25,
                          ),
                          prefixIconColor: Colors.teal[700],
                          hintText: 'Search by brand\'s name',
                          hintStyle: TextStyle(
                              color: Colors.teal[700],
                              fontSize: 20,
                              fontWeight: FontWeight.bold),
                          //icon: Icon(Icons.search),
                          filled: true,
                          fillColor: Colors.white54,
                          border: OutlineInputBorder(
                              borderRadius: BorderRadius.circular(8.0),
                              borderSide: BorderSide.none)),
                      style: const TextStyle(
                        color: Colors.black38,
                      ),
                    ),
                  ),
                  /* Expanded(
                        child:SizedBox(
                          height: 100.0,
                        child:ListView.builder(
                            itemCount: displayedList.length,
                            itemBuilder: (context,index)=> ListTile(
                              title: Text("${displayedList[index].name}",
                              style: const TextStyle(
                                fontWeight: FontWeight.bold,
                                fontSize: 30.0,
                                color: Color(0xFF242424),
                              ),
                              ),
                            )
                        ),
                    )
                    )*/
                ]),
                for (int i = 0; i < displayedList.length; i++)
                  Row(children: [
                    Container(
                      height: 80,
                      width: 365,
                      margin: const EdgeInsets.symmetric(
                          vertical: 20, horizontal: 20),
                      padding: const EdgeInsets.symmetric(
                          vertical: 0, horizontal: 10),
                      decoration: BoxDecoration(
                        color: Colors.white60,
                        borderRadius: BorderRadius.circular(35),
                      ),
                      child: Row(children: [
                        Row(
                          children: [
                            Container(
                              width: 100,
                              height: 80,
                              padding: const EdgeInsets.all(10),
                              child: Container(
                                  //child: Image.network('http://10.0.2.2:5191/Brands/GetBrandImage?id=20'),
                              //  child: Image.network('https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.shutterstock.com%2Fsearch%2Fhuman-lungs&psig=AOvVaw3-u__SH5esKYKrgkzp_ZT2&ust=1690984079287000&source=images&cd=vfe&opi=89978449&ved=0CA4QjRxqFwoTCMiFpNDMu4ADFQAAAAAdAAAAABAE',fit: BoxFit.fitWidth,),

                                // child: CachedNetworkImage()

                                  //  child: Image.file(fileImages[i]),
                                  margin: const EdgeInsets.only(
                                      left: 10.0, right: 10.0),
                                  decoration: BoxDecoration(
                                      color: Colors.white,
                                        //image: DecorationImage(
                                      //  image: FileImage(File(displayedList[i].image))),
                                      //   image: DecorationImage(image: img.image),
                                      //  image: DecorationImage(image: images[i].image),
                                      //  image: Image.network(displayedList[i].image),
                                      border: Border.all(
                                          color: Colors.black87, width: 2.0),
                                      shape: BoxShape.circle)),
                            )
                          ],
                        ),
                        TextButton(
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
                        )
                      ]),
                    )
                  ]),
              ],
            ),
          ),
        )));
  }

  @override
  State<StatefulWidget> createState() {
// TODO: implement createState
    throw UnimplementedError();
  }
}
