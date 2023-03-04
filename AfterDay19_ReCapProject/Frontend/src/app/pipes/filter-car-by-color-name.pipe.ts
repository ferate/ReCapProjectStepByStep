import { Pipe, PipeTransform } from '@angular/core';
import { Car } from '../models/car';

@Pipe({
  name: 'filterCarByColorName'
})
export class FilterCarByColorNamePipe implements PipeTransform {

  transform(value: Car[], filterTextColorName:string): Car[] {
    filterTextColorName = filterTextColorName?filterTextColorName.toLocaleLowerCase():"";
    return filterTextColorName?value.filter((c:Car)=>c.colorName.toLocaleLowerCase().indexOf(filterTextColorName)!==-1):value;  
  }

}
