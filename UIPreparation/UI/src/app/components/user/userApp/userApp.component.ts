import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-userApp',
  templateUrl: './userApp.component.html',
  styleUrls: ['./userApp.component.css']
})
export class UserAppComponent implements OnInit {

  constructor(private authService:AuthService,private router:Router) {}

  ngOnInit() {
  }
  logout(){
    this.authService.logout();
    this.router.navigateByUrl("");
  }
  getQuizList(){
    this.router.navigate(["user","quizList"])
  }
}
