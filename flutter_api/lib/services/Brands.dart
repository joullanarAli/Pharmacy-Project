import 'dart:convert';
import 'dart:io';
//import 'dart:html';

import 'package:http/http.dart';

class Brands{
  //int id;
  String name;
  String image;
  //File formFile;
  Brands(this.name,this.image);
  Future<void> getBrand()async{
    try{
      var url = Uri.parse('http://10.0.2.2:5191/Brands');
      Response response = await get(url);
      Map data=jsonDecode(response.body);
      String name= data['name'];
    }catch(err){
      null;
    }
  }

}