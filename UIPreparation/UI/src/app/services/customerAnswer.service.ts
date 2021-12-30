import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SingleResponseModel } from '../models/singleResponseModel';
import { CustomerAnswer } from '../models/CustomerAnswer';

@Injectable({
  providedIn: 'root'
})
export class CustomerAnswerService {

  constructor(private httpClient:HttpClient) { }

  addCustomerAnswer(customerAnswer:CustomerAnswer):Observable<SingleResponseModel<CustomerAnswer>>{
    return this.httpClient.post<SingleResponseModel<CustomerAnswer>>(environment.customerAnswerPath+"/add",customerAnswer);
  }
  updateCustomerAnswer(customerAnswer:CustomerAnswer):Observable<SingleResponseModel<CustomerAnswer>>{
    return this.httpClient.post<SingleResponseModel<CustomerAnswer>>(environment.customerAnswerPath+"/update",customerAnswer);
  }
  deleteCustomerAnswer(customerAnswer:CustomerAnswer):Observable<SingleResponseModel<CustomerAnswer>>{
    return this.httpClient.post<SingleResponseModel<CustomerAnswer>>(environment.customerAnswerPath+"/delete",customerAnswer);
  }
  getAllCustomerAnswer(): Observable<SingleResponseModel<CustomerAnswer[]>> {
    return this.httpClient.get<SingleResponseModel<CustomerAnswer[]>>(environment.customerAnswerPath+"/getAll");
  }
  getCustomerAnswer(customerAnswerId: number): Observable<SingleResponseModel<CustomerAnswer>> {
    return this.httpClient.get<SingleResponseModel<CustomerAnswer>>(environment.customerAnswerPath+"/getById?customerAnswerId="+customerAnswerId);
  }
}
