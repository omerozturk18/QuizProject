import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SingleResponseModel } from '../models/singleResponseModel';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }

  addUser(user: User): Observable<SingleResponseModel<User>> {
    return this.httpClient.post<SingleResponseModel<User>>(environment.userServicePath + "/add", user);
  }
  updateUser(user: User): Observable<SingleResponseModel<User>> {
    return this.httpClient.post<SingleResponseModel<User>>(environment.userServicePath + "/update", user);
  }
  deleteUser(user: User): Observable<SingleResponseModel<User>> {
    return this.httpClient.post<SingleResponseModel<User>>(environment.userServicePath + "/delete", user);
  }
  getAllUsers(): Observable<SingleResponseModel<User>> {
    return this.httpClient.get<SingleResponseModel<User>>(environment.userServicePath + "/getAll");
  }
  getUser(userId: number): Observable<SingleResponseModel<User>> {
    return this.httpClient.get<SingleResponseModel<User>>(environment.userServicePath + "/getById?userId=" + userId);
  }
  getClaims(userId: number): Observable<SingleResponseModel<User>> {
    return this.httpClient.get<SingleResponseModel<User>>(environment.userServicePath + "/getClaims?userId=" + userId);
  }

}
