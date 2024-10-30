import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { ProductDetailsComponent } from './Components/product-details/product-details.component';
import { EditProductComponent } from './Components/edit-product/edit-product.component';
import { RemoveProductComponent } from './Components/remove-product/remove-product.component';
import { AddProductComponent } from './Components/add-product/add-product.component';
import { ErrorComponent } from './Components/error/error.component';

const routes: Routes = [
  {path:"Home",component:HomeComponent},
  {path:"ProductDetails/:id",component:ProductDetailsComponent},
  {path:"EditProduct/:id",component:EditProductComponent},
  {path:"RemoveProduct/:id",component:RemoveProductComponent},
  {path:"AddProduct",component:AddProductComponent},
  {path:"Error",component:ErrorComponent},
  {path:"",component:HomeComponent,pathMatch:"full"},
  {path:"**",component:ErrorComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
