import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ListResponseModel } from '../models/listResponseModel';
import { from, Observable} from 'rxjs';
import { CarImage } from '../models/carImage';


@Injectable({
  providedIn: 'root'
})
export class CarImageService {

  apiURL = "https://localhost:7250/api/";

 constructor(private httpClient:HttpClient) { }

 getCarImages():Observable<ListResponseModel<CarImage>>{
  let newPath = this.apiURL + "CarImages/getall"
  return this.httpClient.get<ListResponseModel<CarImage>>(newPath);    
 }
 
 
 getCarImagesByCarId(carId:number):Observable<ListResponseModel<CarImage>>{
  let newPath = this.apiURL + "CarImages/getbycarid?carId="+carId 
  return this.httpClient.get<ListResponseModel<CarImage>>(newPath);     
 }


}
