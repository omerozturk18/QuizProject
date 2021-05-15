import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrandDetailComponent } from './Component/Brand/BrandDetail/BrandDetail.component';
import { BrandListComponent } from './Component/Brand/BrandList/BrandList.component';
import { CarDetailComponent } from './Component/Car/CarDetail/CarDetail.component';
import { CarEditComponent } from './Component/Car/CarEdit/CarEdit.component';
import { CarListComponent } from './Component/Car/CarList/CarList.component';
import { NavBarComponent } from './Component/NavBar/NavBar.component';
import { RentalListComponent } from './Component/Rental/RentalList/RentalList.component';
import { BrandEditComponent } from './Component/Brand/BrandEdit/BrandEdit.component';
import { RentalEditComponent } from './Component/Rental/RentalEdit/RentalEdit.component';
import { CarColorListComponent } from './Component/CarColor/CarColorList/CarColorList.component';
import { CarColorEditComponent } from './Component/CarColor/CarColorEdit/CarColorEdit.component';
import { CustomerListComponent } from './Component/Customer/CustomerList/CustomerList.component';
import { CustomerEditComponent } from './Component/Customer/CustomerEdit/CustomerEdit.component';

@NgModule({
  declarations: [
    AppComponent,
    BrandListComponent,
    BrandDetailComponent,
    BrandEditComponent,
    CarColorListComponent,
    CarColorEditComponent,
    CarListComponent,
    CarDetailComponent,
    CarEditComponent,
    CustomerListComponent,
    CustomerEditComponent,
    RentalListComponent,
    RentalEditComponent,
    NavBarComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
