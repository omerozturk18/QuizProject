import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Rental } from 'src/app/models/Rental';
import { RentalService } from 'src/app/services/rental.service';

@Component({
  selector: 'app-RentalList',
  templateUrl: './RentalList.component.html',
  styleUrls: ['./RentalList.component.css']
})
export class RentalListComponent implements OnInit {

  rentals: Rental[] = [];
  constructor(
    private activatedRoutr: ActivatedRoute,
    private rentalService: RentalService
  ) { }

  ngOnInit() {
    this.activatedRoutr.params.subscribe(params => {
      this.getRentals();
    });
  }
  getRentals() {
    this.rentalService.getRentals().subscribe(response=>{
      this.rentals=response.data;
    });
  }
}
