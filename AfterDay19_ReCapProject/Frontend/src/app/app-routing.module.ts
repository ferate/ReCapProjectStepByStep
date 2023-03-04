import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarDetailComponent } from './components/car-detail/car-detail.component';
import { CarComponent } from './components/car/car.component';
import { PaymentComponent } from './components/payment/payment.component';

const routes: Routes = [
  // Aşağıdaki satır ana sayfamda nerenin açılacağını gösteriyor.
  {path:"",pathMatch:"full",component:CarComponent},
  // Bu satır http://localhost:4200/products yazıldığında nerenin açılacağını gösteriyor.
  {path:"cars",component:CarComponent},
  {path:"cars/brand/:brandId",component:CarComponent},
  {path:"cars/color/:colorId",component:CarComponent},
  {path:"carDetail/:carId",component:CarDetailComponent},
  {path:"payment",component:PaymentComponent}
   
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
