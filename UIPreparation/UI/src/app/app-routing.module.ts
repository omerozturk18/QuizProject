import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrandDetailComponent } from './Component/Brand/BrandDetail/BrandDetail.component';
import { BrandEditComponent } from './Component/Brand/BrandEdit/BrandEdit.component';
import { BrandListComponent } from './Component/Brand/BrandList/BrandList.component';
import { CarDetailComponent } from './Component/Car/CarDetail/CarDetail.component';
import { CarEditComponent } from './Component/Car/CarEdit/CarEdit.component';
import { CarListComponent } from './Component/Car/CarList/CarList.component';
import { CarColorEditComponent } from './Component/CarColor/CarColorEdit/CarColorEdit.component';
import { CarColorListComponent } from './Component/CarColor/CarColorList/CarColorList.component';
import { CustomerEditComponent } from './Component/Customer/CustomerEdit/CustomerEdit.component';
import { CustomerListComponent } from './Component/Customer/CustomerList/CustomerList.component';
import { RentalEditComponent } from './Component/Rental/RentalEdit/RentalEdit.component';
import { RentalListComponent } from './Component/Rental/RentalList/RentalList.component';

const routes: Routes = [
  { path: '', redirectTo:'CarList', pathMatch:'full', },

  { path: 'BrandList', component: BrandListComponent },
  { path: 'BrandDetail/:brandId', component: BrandDetailComponent },
  { path: 'BrandEdit/:brandId', component: BrandEditComponent },

  { path: 'CarColorList', component: CarColorListComponent },
  { path: 'CarColorEdit/:colorId', component: CarColorEditComponent },


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
