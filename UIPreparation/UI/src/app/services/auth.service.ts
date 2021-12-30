import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginModel } from '../models/loginModel';
import { SingleResponseModel } from '../models/singleResponseModel';
import { TokenModel } from '../models/tokenModel';
import { Observable } from 'rxjs';
import { RegisterModel } from '../models/RegisterModel';
import { ResponseModel } from '../models/responseModel';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  jwtHelper: JwtHelperService = new JwtHelperService();
  decodedToken: any;
  constructor(
    private httpClient: HttpClient,
    private toastrService:ToastrService,
    private router:Router
  ) { }

  login(loginModel: LoginModel) {
    this.httpClient.post<SingleResponseModel<TokenModel>>(environment.authPath + "/login", loginModel).subscribe(response => {
      this.saveToken(response.data.token);
      this.decodedToken = this.jwtHelper.decodeToken(response.data.token.toString());
    this.toastrService.success(response.message);
    this.router.navigateByUrl("");
  },responseError=>{
    this.toastrService.error(responseError.error)
  });
  }
  register(registerModel: RegisterModel): Observable<SingleResponseModel<TokenModel>> {
    return this.httpClient.post<SingleResponseModel<TokenModel>>(environment.authPath + "/register", registerModel);
  }
  isAuthenticated2(userMail?: string | null, requiredRoles?: string[]): Observable<ResponseModel> {
    return this.httpClient.get<ResponseModel>(environment.authPath + "/isauthenticated",
      {
        params:
          userMail && requiredRoles
            ? {
              userMail: userMail,
              requiredRoles: requiredRoles.join(','),
            }
            : {},
      }
    );
  }
  isAuthenticated() {
    let token=localStorage.getItem("token");
    if (token) {
      return true;
    }
    else {
      return false;
    }
  }

  logout() {
    localStorage.removeItem("token");
  }
  saveToken(token: string) {
    localStorage.setItem("token", token);
  }
  loggedIn() {
    return this.jwtHelper.isTokenExpired(this.token);
  }
  get token() {
    return localStorage.getItem("token");
  }
  getCurrentUserName() {
    return this.jwtHelper.decodeToken(this.token).email;
  }
  getCurrentUser() {
    console.log(this.jwtHelper.decodeToken(this.token));

    return this.jwtHelper.decodeToken(this.token);
  }
  getCurrentUserRoles() {
    let role=this.jwtHelper.decodeToken(this.token).Role;
    if(role=="user") return true
    return false
  }
  getCurrentAdminRoles() {
    let role=this.jwtHelper.decodeToken(this.token).Role;
    if(role=="admin") return true
    return false
  }

}
