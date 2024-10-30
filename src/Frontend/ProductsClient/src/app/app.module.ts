import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './Components/header/header.component';
import { FooterComponent } from './Components/footer/footer.component';
import { ProductsComponent } from './Components/products/products.component';
import { HomeComponent } from './Components/home/home.component';
import { AddProductComponent } from './Components/add-product/add-product.component';
import { ProductDetailsComponent } from './Components/product-details/product-details.component';
import { EditProductComponent } from './Components/edit-product/edit-product.component';
import { RemoveProductComponent } from './Components/remove-product/remove-product.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    ProductsComponent,
    HomeComponent,
    AddProductComponent,
    ProductDetailsComponent,
    EditProductComponent,
    RemoveProductComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
