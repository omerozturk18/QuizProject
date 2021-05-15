import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CarDetail } from 'src/app/models/CarDetail';
import { CarImage } from 'src/app/models/CarImage';
import { CarService } from 'src/app/services/car.service';
import { CarImageService } from 'src/app/services/carImage.service';

@Component({
  selector: 'app-CarList',
  templateUrl: './CarList.component.html',
  styleUrls: ['./CarList.component.css']
})
export class CarListComponent implements OnInit {

  cars: CarDetail[] = [];
  dataLoaded = false;



  constructor(
    private carService: CarService,
    private carImageService: CarImageService,
    private activatedRoute:ActivatedRoute) {}

  ngOnInit(): void {
    this.activatedRoute.queryParams.subscribe(params=>{
      this.getCarsDetails();
    });
  }

  getCarsDetails() {
    this.carService.getCarsDetails().subscribe(response => {
      this.cars = response.data;
      this.dataLoaded = true;
    });
  }
}
