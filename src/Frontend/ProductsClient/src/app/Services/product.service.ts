import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IProduct } from './../ViewModels/Interfaces/iproduct';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  products: IProduct[] = [];
  baseUrl:string;
  constructor(private _http:HttpClient) {
    this.baseUrl="http://localhost:5019";
   /* this.products = [
      {Id: 1, Name: 'product 1' , Price: 1500, Details: '' , Quantity: 2, OriginalQuantity: 2, categoryId: 1, Image: 'https://via.placeholder.com/150'},
      {Id: 2, Name: 'product 2' , Price: 1500, Details: '' , Quantity: 5, OriginalQuantity: 5, categoryId: 2, Image: 'https://via.placeholder.com/400'},
      {Id: 3, Name: 'product 3' , Price: 1500, Details: '' , Quantity: 4, OriginalQuantity: 4, categoryId: 3, Image: 'https://via.placeholder.com/150'},
      {Id: 4, Name: 'product 4' , Price: 1500, Details: '' , Quantity: 6, OriginalQuantity: 6, categoryId: 1, Image: 'https://via.placeholder.com/150'},
      {Id: 5, Name: 'product 5' , Price: 1500, Details: '' , Quantity: 7, OriginalQuantity: 7, categoryId: 3, Image: 'https://via.placeholder.com/150'},
      {Id: 6, Name: 'product 6' , Price: 1500, Details: '' , Quantity: 2, OriginalQuantity: 7, categoryId: 3, Image: 'https://via.placeholder.com/150'},
    ];*/
  }
  getAllProducts():Observable<IProduct[]>{
    return this._http.get<IProduct[]>(this.baseUrl+"/api/Product");
  }
  getProductsByCategory(category: string):Observable<IProduct[]>{
    return this._http.get<IProduct[]>(this.baseUrl+`/api/Product/${category}`);
  }
  AddProduct(product: IProduct):Observable<IProduct>{
   return this._http.post<IProduct>(this.baseUrl+"/api/Product",product);
  }
  EditProduct(product: IProduct){
   return this._http.put(this.baseUrl+`/api/Product`,product);
  }
  // getProductById(id: number){
  //   debugger;
  //   return new Promise((resolve,reject)=>{
  //     this.getAllProducts().subscribe((data)=>{
  //       debugger;
  //       var result = data.filter(p => p.id = id);
  //       resolve(result);
  //     },reject)
  //   })
  //   // this.getAllProducts().subscribe(
  //   //   (data)=>{
  //   //     return data.find(t => t.id = id);
  //   //   },
  //   //   (error)=>{

  //   //   }
  //   // );
  // }
  RemoveProductById(id: number){
     return this._http.delete(this.baseUrl+`/api/Product/${id}`);
  }
 
}
