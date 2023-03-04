import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { ColorResponseModel } from '../models/colorResponseModel';
import { from, Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ColorService {

  apiURL = "https://localhost:7250/api/Colors/getall";
  
  constructor(private httpClient:HttpClient) { }

  getColors():Observable<ColorResponseModel>{
    return this.httpClient.get<ColorResponseModel>(this.apiURL);   
  
   }

}

