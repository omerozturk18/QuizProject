import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-adminApp',
  templateUrl: './adminApp.component.html',
  styleUrls: ['./adminApp.component.css']
})
export class AdminAppComponent implements OnInit {

  constructor(private authService:AuthService,private router:Router) {}

  ngOnInit() {
  }
  logout(){
    this.authService.logout();
    this.router.navigateByUrl("");
  }
  // get isAuthenticated() {
  //   let authenticated=this.authService.isAuthenticated();
  //   authenticated?"":this.router.navigateByUrl("");
  //   return authenticated
  // }
}
