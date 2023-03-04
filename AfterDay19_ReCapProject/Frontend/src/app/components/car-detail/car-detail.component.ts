import { Component,OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Car } from 'src/app/models/car';
import { CarService } from 'src/app/services/car.service';
import { Rental } from 'src/app/models/rental';
import { RentalService } from 'src/app/services/rental.service';
import { CarImage } from 'src/app/models/carImage';
import { CarImageService } from 'src/app/services/car-image.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.css']  
})
export class CarDetailComponent implements OnInit{

  constructor(private carService: CarService,
    private carImageService: CarImageService,
    private rentalService:RentalService,
    private activatedRoute: ActivatedRoute,private toastrService:ToastrService) { }


    dataLoaded = false;    
    car: Car;
    rental:Rental;
    carRentDate : Date;
    carReturnDate : Date;
    carImages: CarImage[];
    carAvailable:boolean=false;
    carAvailableForRentMessage:string="";
    rentDateStyleStatus:string="display:none;";
    paymentDataDismis = "";    
  
    ngOnInit(): void {
      this.activatedRoute.params.subscribe(params => {
        this.getCarByCarId(params["carId"]);
        this.getCarImagesByCarId(params["carId"]);
      })
    }

    getCarByCarId(carId: number) {
      this.carService.getCarsByCarId(carId).subscribe(response => {
        this.car = response.data[0];
        this.dataLoaded = true;
      })
    }
  
    getCarImagesByCarId(carId: number) {
      this.carImageService.getCarImagesByCarId(carId).subscribe(response => {
        this.carImages = response.data;
        this.dataLoaded = true;
      })
    }

    getImagePath(carImage: CarImage): string {      
        //let url: string = "https://localhost:44329" + carImage.imagePath
        let url: string = "https://localhost:7250/Uploads/Images/"+carImage.imagePath;        
        return url     
    }

    
    rentDateDisplayMode():string{
      let rentDateStyleStatusNow:string="";
      return rentDateStyleStatusNow=this.rentDateStyleStatus;  
    }

    changeRentDateDisplayMode(){

      if(this.rentDateStyleStatus=="display:none;")
      {
        this.rentDateStyleStatus="display:initial;"; 
        this.toastrService.info("Tarih Aralığı Seçiniz");
      }
      else
      {
        if(this.carRentDate==null)
          this.rentDateStyleStatus="display:none;";
      }   
         
    }

   
    checkAvailableOfCar(carId: number,rentDate: Date, returDate:Date){
      
      this.rentalService.getRentalCarbyRentReturnDate(carId,rentDate,returDate).subscribe(
        response=>{
          this.rental = response.data[0]   
         
          if(response.data.length>0)
          {
            this.carAvailable = false;
            this.carAvailableForRentMessage="The car is not available between the selected dates"; 
            this.toastrService.error("Seçili Tarih Aralığında Araç Müsait Değil");
          }          
          else   
          {
            this.carAvailable = true;  
            this.carAvailableForRentMessage="";  
            document.getElementById("payment")?.click();
          }                
        }
      )      
    }

   
    paymentForRentCar(){
      document.getElementById("closeButton")?.click();
      this.toastrService.success("Ödeme Gerçekleşti");
    }

   


}
