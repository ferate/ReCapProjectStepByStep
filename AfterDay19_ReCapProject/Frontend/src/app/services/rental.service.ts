import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { RentalResponseModel } from '../models/rentalResponseModel';
import { ListResponseModel } from '../models/listResponseModel';
import { from, Observable} from 'rxjs';
import { Rental } from '../models/rental';

@Injectable({
  providedIn: 'root'
})
export class RentalService {

  apiURL = "https://localhost:7250/api/Rentals";
 

  constructor(private httpClient:HttpClient) { }

  getRentals():Observable<RentalResponseModel>{
    let newPath = this.apiURL + "/getrentaldetails"
    return this.httpClient.get<RentalResponseModel>(this.apiURL);     
   }


  getRentalCarbyRentReturnDate(carId:number,rentDate:Date, returnDate:Date):Observable<ListResponseModel<Rental>>
  {
    let newPath = this.apiURL + "/getrentalcarbyrentreturndate?carId="+carId+"&rentDate="+rentDate+"&returnDate="+returnDate 
    return this.httpClient.get<ListResponseModel<Rental>>(newPath);  
  }

  


}
