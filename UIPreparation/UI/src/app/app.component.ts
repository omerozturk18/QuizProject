import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent  implements OnInit{
  title: string = 'Quiz Project';
  constructor(private authService: AuthService, private router: Router) {
  }
  ngOnInit() {
    // if (this.isAuthenticated) {
    //   this.authService.getCurrentAdminRoles() ?
    //     this.router.navigate(["admin", "dashboard"]) :
    //     this.router.navigate(["user", "dashboard"]);
    // }
  }
   get isAuthenticated() {
    return this.authService.isAuthenticated();
  }
}
