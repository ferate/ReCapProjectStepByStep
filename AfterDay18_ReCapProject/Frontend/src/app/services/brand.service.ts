import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { BrandResponseModel } from '../models/brandResponseModel';
import { from, Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BrandService {

  apiURL = "https://localhost:7250/api/Brands/getall";
            
  constructor(private httpClient:HttpClient) { }

  getBrands():Observable<BrandResponseModel>{
    return this.httpClient.get<BrandResponseModel>(this.apiURL);   
  
   }

}
