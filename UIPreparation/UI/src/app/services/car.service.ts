import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Car } from '../models/Car';
import { CarDetail } from '../models/CarDetail';
import { ListResponseModel } from '../models/ListResponseModel';


@Injectable({
  providedIn: 'root'
})
export class CarService {
  private apiUrl='https://localhost:44383/api/';

  constructor(private httpClient:HttpClient) { }

  getCars():Observable<ListResponseModel<Car>>{
    return this.httpClient.get<ListResponseModel<Car>>(this.apiUrl +"cars/getall");
  }

  getCarsByBrand(brandId:number):Observable<ListResponseModel<Car>>{
    return this.httpClient.get<ListResponseModel<Car>>(this.apiUrl +"cars/getByBrandId?brandId="+brandId);
  }

  getCarsByColor(colorId:number):Observable<ListResponseModel<Car>>{
    return this.httpClient.get<ListResponseModel<Car>>(this.apiUrl +"cars/getbycolor?colorId="+colorId);
  }

  getCarDetailById(carId:number):Observable<ListResponseModel<Car>>{
    return this.httpClient.get<ListResponseModel<Car>>(this.apiUrl +"cars/getById?carId="+carId);
  }
  getCarsDetails():Observable<ListResponseModel<CarDetail>> {
    debugger;
    return this.httpClient.get<ListResponseModel<CarDetail>>("https://localhost:44383/api/cars/getCarsDetails");
  }

}
