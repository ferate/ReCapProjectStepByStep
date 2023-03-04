import { Pipe, PipeTransform } from '@angular/core';
import { Car } from '../models/car';

@Pipe({
  name: 'filterCarByBrandName'
})
export class FilterCarByBrandNamePipe implements PipeTransform {

  transform(value: Car[], filterTextBrandName:string): Car[] {
    filterTextBrandName = filterTextBrandName?filterTextBrandName.toLocaleLowerCase():"";
    return filterTextBrandName?value.filter((c:Car)=>c.brandName.toLocaleLowerCase().indexOf(filterTextBrandName)!==-1):value;  
  }

}
