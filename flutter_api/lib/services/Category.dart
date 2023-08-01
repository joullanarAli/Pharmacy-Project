import 'dart:convert';
import 'dart:io';
//import 'dart:html';

import 'package:http/http.dart';

class Category{
  String name;
 // String image;
//  File formFile;
  Category(this.name);
  Future<void> getBrand()async{
    try{
      var url = Uri.parse('http://10.0.2.2:5191/Categories');
      Response response = await get(url);
      Map data=jsonDecode(response.body);
      String name= data['name'];
      String image=data['image'];
    }catch(err){
      null;
    }
  }

}