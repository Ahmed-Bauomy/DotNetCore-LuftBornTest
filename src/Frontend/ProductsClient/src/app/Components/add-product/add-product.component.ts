import { Router } from '@angular/router';
import { ProductService } from './../../Services/product.service';
import { IProduct } from './../../ViewModels/Interfaces/iproduct';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  Loading: boolean = false;
  Product:IProduct;
  ModelState: string[] = [];
  constructor(private _productService:ProductService,private _router:Router) {
    this.Product={
      name:'',
      price:0,
      id:0,
      category:'',
      description:'',
      imageFile:'',
      summary:''
    }
   }

  ngOnInit(): void {
    //this.Loading=true;
  }
  CreateNewProduct(){
    this.Loading=true;
    console.log(this.Product);
     this._productService.AddProduct(this.Product).subscribe(
       (data)=>{
         this.Loading=false;
         console.log(data);
          this._router.navigate(['/Home']);
       },
       (err)=>{
         this.Loading=false;
        if(err.error.ModelState!=null){
          this.ModelState=err.error.ModelState[""];
        }else{
          this.ModelState=["Unkown error" , "Try again later"];
        }
       }
     )
  }
}
