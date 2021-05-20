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
  brandId:number=0;
  colorId:number=0;
  dataLoaded = false;



  constructor(
    private carService: CarService,
    private carImageService: CarImageService,
    private activatedRoute:ActivatedRoute) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      this.brandId=params["brandId"];
      this.colorId=params["colorId"];
      this.getCarsDetails();
    });
  }

  getCarsDetails() {
    this.carService.getCarsDetails().subscribe(response => {
      this.brandId != null? this.cars = response.data.filter(x=>x.brand.brandId==this.brandId):this.cars=response.data;
      this.colorId != null? this.cars = response.data.filter(x=>x.color.colorId==this.colorId):this.cars;
      this.dataLoaded = true;
    });
  }
}
