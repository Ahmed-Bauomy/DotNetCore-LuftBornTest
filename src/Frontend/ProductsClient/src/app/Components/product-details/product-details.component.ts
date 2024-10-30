import { ProductService } from './../../Services/product.service';
import { IProduct } from './../../ViewModels/Interfaces/iproduct';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
   id:number = 0;
   product!: IProduct;
   Loading:boolean;
   defaultImage:string = "/assets/product-default.png"
  constructor(private _activatedRout:ActivatedRoute,private _productService:ProductService) { 
  this.Loading=false;
  }

  ngOnInit(): void {
    debugger
    //this.Loading=true;
    this.id=this._activatedRout.snapshot.params["id"];
     this.product = this._productService.products.find(p => p.id == this.id)!;
  }
  
}
