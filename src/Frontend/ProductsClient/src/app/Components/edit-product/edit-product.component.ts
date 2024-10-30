import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from './../../Services/product.service'
import { IProduct } from './../../ViewModels/Interfaces/iproduct';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {
  id:number = 0;
  product!:IProduct;
  Loading:boolean = false;
  ModelState: string[] = [];
  UpdateForm!: FormGroup;
  constructor(private _activatedRoute:ActivatedRoute,
              private _productService:ProductService,
              private _router:Router,
              private _FormBuilder:FormBuilder) { 
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
    /*validation */
    this.UpdateForm=this._FormBuilder.group({
     PName:['',[Validators.required,Validators.minLength(4),Validators.pattern("[a-zA-Z 0-9 ._%+-]*")]],
     PDetails:['',[Validators.required]],
     PImage:['',Validators.nullValidator],
     PPrice:['',Validators.required],
     PCategory:['',Validators.required]
    });
    this.Loading=true;
   this.Loading=true;
    this.id=this._activatedRoute.snapshot.params["id"];
    this.product = this._productService.products.find(p => p.id == this.id)!;
    // this._productService.getProductById(this.id).subscribe(
    //  (data)=>{
    //   this.Loading=false;
    //  this.Product=data;
    //  },
    //  (err)=>{
    //    this.Loading=false;
    //   console.log(err);
    //  }
    // )
  }
  EditProduct(){
    debugger;
    this.Loading=true;
    console.log(this.product);
    console.log(this.product);
   this._productService.EditProduct(this.product).subscribe(
   (data)=>{
    debugger;
    this.Loading=false;
     alert("Edited");
     this._router.navigate(["/Home"]);
   },
   (err)=>{
    this.Loading=false;
    console.log(err);
   }
   );
  }

}
