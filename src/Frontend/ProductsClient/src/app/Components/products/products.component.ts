import { Router } from '@angular/router';
import { ProductService } from './../../Services/product.service';
import { IProduct } from './../../ViewModels/Interfaces/iproduct';
import { Component, Input, OnChanges, OnInit } from '@angular/core';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit, OnChanges {
   products: IProduct[] = [];
   Loading:boolean = false;
   defaultImage:string = "/assets/product-default.png"
  constructor(private _productService: ProductService,private _router:Router) {

   }

  ngOnInit(): void {
    debugger;
    this.Loading=true;
    this._productService.getAllProducts().subscribe(
    (data)=>{
      this.Loading=false;
      this.products=data;
      this._productService.products = this.products;
      console.log(this.products);
    },
    (err)=>{
     this.Loading=false;
    this._router.navigate(["/Error"]);
    }
  );
  }
  ngOnChanges(): void{
  }
  getFilteredProducts(): IProduct[]{
   return this.products;
  }
}
