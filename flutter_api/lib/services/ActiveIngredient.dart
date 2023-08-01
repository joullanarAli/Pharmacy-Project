import 'dart:convert';
import 'dart:io';
//import 'dart:html';

import 'package:http/http.dart';

class ActiveIngredient{
  //int id;
  String name;
  ActiveIngredient(this.name);
  Future<void> getBrand()async{
    try{
      var url = Uri.parse('http://10.0.2.2:5191/ActiveIngredients');
      Response response = await get(url);
      Map data=jsonDecode(response.body);
      String name= data['name'];
    }catch(err){
      null;
    }
  }

}