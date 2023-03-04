import { Component,OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Car } from 'src/app/models/car';
import { CarService } from 'src/app/services/car.service';
import { Brand } from 'src/app/models/brand';
import { BrandService } from 'src/app/services/brand.service';
import { Color } from 'src/app/models/color';
import { ColorService } from 'src/app/services/color.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit{

  currentCar: Car;
  cars : Car[]=[];
  brands:Brand[];
  currentBrand:Brand;
  emptyBrand:Brand;
  colors:Color[];
  currentColor:Color;
  dataLoaded = false;
  filterTextCarName="";
  filterTextBrandName="";
  filterTextColorName="";
  filterColor:number=0;
  filterBrand:number=0;

 

  constructor(private carService:CarService,private activatedRoute:ActivatedRoute,
    private brandService:BrandService,private colorService:ColorService,private toastrService:ToastrService) {}

  ngOnInit():void{
    this.getBrands();
    this.getColors();
    this.activatedRoute.params.subscribe(params=>{
      if(params["brandId"]){
        this.getCarsByBrandId(params["brandId"])
      }
      else if(params["colorId"]){
        this.getCarsByColorId(params["colorId"])
      }
      else
      {
        this.getCars()
      }   

     
    })
  }

  getCars(){
    this.carService.getCars().subscribe(response=>{
     this.cars=response.data    
     this.dataLoaded = true;
    })
  }


  getCarsByBrandId(brandId:number){
    this.carService.getCarsByBrandId(brandId).subscribe(response=>{
    this.cars=response.data
    this.dataLoaded = true;
  })  
  }

  getCarsByColorId(colorId:number){
    this.carService.getCarsByColorId(colorId).subscribe(response=>{
    this.cars=response.data
    this.dataLoaded = true;
  })  
  }

  getCarByCarId(carId:number){
    this.carService.getCarsByCarId(carId).subscribe(response=>{
    this.cars=response.data
    this.dataLoaded = true;
  })  
  }

  setCurrentCar(car: Car) {
    this.currentCar = car;
  }

  getBrands(){
    this.brandService.getBrands().subscribe(response=>{
      this.brands=response.data;
    }

    )
  }

  getColors(){
    this.colorService.getColors().subscribe(response=>{
      this.colors=response.data;
    }

    )
  }

  getCarsByBrandAndColorId(brandId:number,colorId:number){
    this.carService.getCarsByBrandAndColorId(brandId,colorId).subscribe(response=>{
    this.cars=response.data
    this.dataLoaded = true;    
    this.toastrService.success("Arabalar Listelendi");
    })  
  }
  
  
  


}
