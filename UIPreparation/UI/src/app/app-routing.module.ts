import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrandEditComponent } from './component/Brand/BrandEdit/BrandEdit.component';
import { BrandListComponent } from './component/Brand/BrandList/BrandList.component';
import { CarDetailComponent } from './component/Car/CarDetail/CarDetail.component';
import { CarEditComponent } from './component/Car/CarEdit/CarEdit.component';
import { CarListComponent } from './component/Car/CarList/CarList.component';
import { CarColorEditComponent } from './component/CarColor/CarColorEdit/CarColorEdit.component';
import { CarColorListComponent } from './component/CarColor/CarColorList/CarColorList.component';
import { CustomerEditComponent } from './component/Customer/CustomerEdit/CustomerEdit.component';
import { CustomerListComponent } from './component/Customer/CustomerList/CustomerList.component';
import { RentalEditComponent } from './component/Rental/RentalEdit/RentalEdit.component';
import { RentalListComponent } from './component/Rental/RentalList/RentalList.component';
import { BrandDetailComponent } from "./component/Brand/BrandDetail/BrandDetail.component";

const routes: Routes = [
  { path: '', redirectTo:'CarList', pathMatch:'full', },

  { path: 'BrandList', component: BrandListComponent },
  { path: 'BrandDetail/:brandId', component: BrandDetailComponent },
  { path: 'BrandEdit/:brandId', component: BrandEditComponent },

  { path: 'CarColorList', component: CarColorListComponent },
  { path: 'CarColorEdit/:colorId', component: CarColorEditComponent },

  { path: 'CarList/:brandId', component: CarListComponent },
  { path: 'CarList/:colorId', component: CarListComponent },
  { path: 'CarList', component: CarListComponent },
  { path: 'CarDetail/:carId', component: CarDetailComponent },
  { path: 'CarEdit', component: CarEditComponent },

  { path: 'CustomerList', component: CustomerListComponent },
  { path: 'CustomerEdit/:customerId', component: CustomerEditComponent },

  { path: 'RentalList', component: RentalListComponent },
  { path: 'RentalEdit/:rentalId', component: RentalEditComponent },


  { path: '*', component: CarListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
