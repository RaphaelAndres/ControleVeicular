import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BrandsComponent } from './components/brands/brands.component';
import { VehiclesComponent } from './components/vehicles/vehicles.component';
import { AdvertisementsComponent } from './components/advertisements/advertisements.component';


const routes: Routes = [
  { path: 'brands', component: BrandsComponent },
  { path: 'vehicles', component: VehiclesComponent},
  { path: 'advertisements', component: AdvertisementsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
