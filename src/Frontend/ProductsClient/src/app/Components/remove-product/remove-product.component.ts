import { ProductService } from './../../Services/product.service';
import { IProduct } from './../../ViewModels/Interfaces/iproduct';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-remove-product',
  templateUrl: './remove-product.component.html',
  styleUrls: ['./remove-product.component.css']
})
export class RemoveProductComponent implements OnInit {
  id:number = 0;
  product:IProduct;
  Loading: boolean = false;
  constructor(private _activatedRoute:ActivatedRoute,
              private _productService:ProductService
              ,private _router:Router) {
                this.product={
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
    this.Loading=true;
    this.id=this._activatedRoute.snapshot.params["id"];
    this.product =this._productService.products.find(p => p.id == this.id)!;
    // this._productService.getProductById(this.id).subscribe(
    //  (data)=>{
    //   this.Loading=false;
    //   console.log(data);
    //  this.product=data;
    //  },
    //  (err)=>{
    //    this.Loading=false;
    //   console.log(err);
    //  }
    // )
  }
  DeleteProduct(){
    this.Loading=true;
    this._productService.RemoveProductById(this.product.id).subscribe(
      (data)=>{
        this.Loading=false;
        console.log(data);
        this._router.navigate(["/Home"]);
      },
      (err)=>{
        this.Loading=false;
        console.log(err);
      }
    );
  }

}
