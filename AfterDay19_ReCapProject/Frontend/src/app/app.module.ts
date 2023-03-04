import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NaviComponent } from './components/navi/navi.component';
import { BrandComponent } from './components/brand/brand.component';
import { ColorComponent } from './components/color/color/color.component';
import { CustomerComponent } from './components/customer/customer.component';
import { CarComponent } from './components/car/car.component';
import { RentalComponent } from './components/rental/rental.component';
import { CarImageComponent } from './components/car-image/car-image.component';
import { CarDetailComponent } from './components/car-detail/car-detail.component';


import { CarouselModule } from 'ngx-bootstrap/carousel';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {TooltipModule} from 'ngx-bootstrap/tooltip'
import {BsDropdownModule,BsDropdownConfig} from 'ngx-bootstrap/dropdown';
import { FilterPipePipe } from './pipes/filter-pipe.pipe';
import { FilterCarByCarNamePipe } from './pipes/filter-car-by-car-name.pipe';
import { FilterCarByBrandNamePipe } from './pipes/filter-car-by-brand-name.pipe';
import { FilterCarByColorNamePipe } from './pipes/filter-car-by-color-name.pipe';

import { ToastrModule } from 'ngx-toastr';
import { PaymentComponent } from './components/payment/payment.component';



@NgModule({
  declarations: [
    AppComponent,    
    NaviComponent,
    BrandComponent,
    ColorComponent,
    CustomerComponent,
    CarComponent,
    RentalComponent,
    CarImageComponent,
    CarDetailComponent,    
    FilterPipePipe,
    FilterCarByBrandNamePipe,
    FilterCarByColorNamePipe,
    FilterCarByCarNamePipe,
    PaymentComponent        
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    CarouselModule.forRoot(),
    BrowserAnimationsModule,
    TooltipModule.forRoot(),
    BsDropdownModule.forRoot(),    
    ToastrModule.forRoot({positionClass:"toast-bottom-right"})    
    
  ],
  providers: [BsDropdownConfig],
  bootstrap: [AppComponent]
})
export class AppModule { }
