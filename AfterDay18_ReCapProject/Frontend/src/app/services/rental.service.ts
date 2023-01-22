import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { RentalResponseModel } from '../models/rentalResponseModel';
import { from, Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RentalService {

  apiURL = "https://localhost:7250/api/Rentals/getrentaldetails";
 

  constructor(private httpClient:HttpClient) { }

  getRentals():Observable<RentalResponseModel>{
    return this.httpClient.get<RentalResponseModel>(this.apiURL);     
   }

}
