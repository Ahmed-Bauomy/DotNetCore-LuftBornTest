import { Router } from '@angular/router';
import { ProductService } from './../../Services/product.service';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(public _productService: ProductService,
              private _router:Router) { 
                
  }

  ngOnInit(): void {
  }

}
