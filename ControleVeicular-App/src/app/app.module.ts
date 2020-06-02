import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrandsComponent } from './components/brands/brands.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HeaderComponent } from './header/header.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { VehiclesComponent } from './components/vehicles/vehicles.component';
import { AdvertisementsComponent } from './components/advertisements/advertisements.component';
import { UserComponent } from './components/user/user.component';
import { RegistrationComponent } from './components/user/registration/registration.component';
import { LoginComponent } from './components/user/login/login.component';
import { AuthInterceptor } from './auth/auth.interceptor';
import { AdvertisementService } from './services/advertisement.service';
import { BrandService } from './services/brand.service';
import { VehicleService } from './services/vehicle.service';

@NgModule({
   declarations: [
      AppComponent,
      HeaderComponent,
      BrandsComponent,
      VehiclesComponent,
      AdvertisementsComponent,
      UserComponent,
      RegistrationComponent,
      LoginComponent
   ],
   imports: [
      BrowserModule,
      BsDropdownModule.forRoot(),
      TooltipModule.forRoot(),
      ModalModule.forRoot(),
      ReactiveFormsModule,
      BrowserAnimationsModule,
      ToastrModule.forRoot(),
      AppRoutingModule,
      HttpClientModule,
      FontAwesomeModule,
      FormsModule
   ],
   providers: [
      AdvertisementService,
      BrandService,
      VehicleService,
      {
         provide: HTTP_INTERCEPTORS,
         useClass: AuthInterceptor,
         multi: true
      }
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
