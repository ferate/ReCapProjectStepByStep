import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { ListResponseModel } from '../models/listResponseModel';
import { EntityResponseModel } from '../models/entityResponseModel';
import { from, Observable} from 'rxjs';
import { Car } from '../models/car';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  apiURL = "https://localhost:7250/api/";


  constructor(private httpClient:HttpClient) { }

  getCars():Observable<ListResponseModel<Car>>{
    let newPath = this.apiURL + "Cars/getcardetails"
    return this.httpClient.get<ListResponseModel<Car>>(newPath);    
   }
     
   getCarsByBrandId(brandId:number):Observable<ListResponseModel<Car>>{
    let newPath = this.apiURL + "Cars/getcardetailsbybrandid?brandId="+brandId 
    return this.httpClient.get<ListResponseModel<Car>>(newPath);     
   }
  
   
   getCarsByColorId(colorId:number):Observable<ListResponseModel<Car>>{
    let newPath = this.apiURL + "Cars/getcardetailsbycolorid?colorId="+colorId 
    return this.httpClient.get<ListResponseModel<Car>>(newPath);    
   }

   getCarsByBrandAndColorId(brandId:number,colorId:number):Observable<ListResponseModel<Car>>{
    let newPath = this.apiURL + "Cars/getcardetailsbybrandandcolorid?brandId="+brandId+"&colorId="+colorId 
    return this.httpClient.get<ListResponseModel<Car>>(newPath);     
   }
   
   getCarsByCarId(carId:number):Observable<ListResponseModel<Car>>{
    let newPath = this.apiURL + "Cars/getcardetailsbycarid?carId="+carId 
    return this.httpClient.get<ListResponseModel<Car>>(newPath);    
   }

   
  
   


}
