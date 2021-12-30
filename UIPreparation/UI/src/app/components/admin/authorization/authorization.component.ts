import { OperationClaim } from './../../../models/OperationClaim';
import { UserService } from './../../../services/user.service';
import { User } from './../../../models/User';
import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-authorization',
  templateUrl: './authorization.component.html',
  styleUrls: ['./authorization.component.css']
})
export class AuthorizationComponent implements OnInit {
users:User[]=[];
claims:OperationClaim[]=[];
claimType:any;
  constructor(private userService:UserService,private modalService: NgbModal) { }

  ngOnInit() {
    this.userService.getAllUsers().subscribe(data=>{
      this.users=data.data;
      console.log(data);

    })
  }
  getClaim(item:User,content:any){
    this.userService.getClaims(item.id).subscribe(x=>{
      this.claims=x.data;
      this.modalService.open(content, {
        size: <any>"sm",
      });
    })
  }
  changeClaimType(){

  }

}
