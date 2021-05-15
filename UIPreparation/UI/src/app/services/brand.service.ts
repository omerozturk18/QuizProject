
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ListResponseModel } from '../models/ListResponseModel';
import { Brand } from '../models/Brand';


@Injectable({
  providedIn: 'root'
})
export class BrandService {
  apiUrl="https://localhost:44383/api/";
  constructor(private httpClient:HttpClient) { }

  getBrands():Observable<ListResponseModel<Brand>>{
    return this.httpClient.get<ListResponseModel<Brand>>(this.apiUrl+"brands/getAll");
  }
}
