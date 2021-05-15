import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Car } from 'src/app/models/Car';
import { CarDetail } from 'src/app/models/CarDetail';
import { CarService } from 'src/app/services/car.service';
import { CarImageService } from 'src/app/services/carImage.service';

@Component({
  selector: 'app-BrandDetail',
  templateUrl: './BrandDetail.component.html',
  styleUrls: ['./BrandDetail.component.css']
})
export class BrandDetailComponent implements OnInit {

  brandId:number=0;
  cars: Car[] = [];
  dataLoaded = false;

  constructor(
    private carService: CarService,
    private activatedRoute:ActivatedRoute
  ) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe(params=>{
      this.brandId=params["brandId"];
      this.getCarsDetails();
    });
  }
  getCarsDetails() {
    this.carService.getCarsByBrand(this.brandId).subscribe(response => {
      this.cars = response.data;
      this.dataLoaded = true;
    });
  }
}
