import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Brand } from 'src/app/models/Brand';
import { Color } from 'src/app/models/Color';
import { BrandService } from 'src/app/services/brand.service';
import { ColorService } from 'src/app/services/color.service';

@Component({
  selector: 'app-Sidebar',
  templateUrl: './Sidebar.component.html',
  styleUrls: ['./Sidebar.component.css']
})
export class SidebarComponent implements OnInit {


  brands:Brand[]=[];
  colors:Color[]=[];

  constructor(
    private activatedRoute:ActivatedRoute,
    private brandService:BrandService,
    private colorService:ColorService
    ) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe(params=>{
      this.getBrands();
      this.getColors();
    });

  }
  getBrands(){
    this.brandService.getBrands().subscribe(response=>{
      this.brands=response.data;
    });
  }
  getColors(){
    this.colorService.getColors().subscribe(response=>{
      this.colors=response.data;
    });
  }
}
