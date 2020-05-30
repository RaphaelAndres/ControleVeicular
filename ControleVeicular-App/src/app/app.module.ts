import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrandsComponent } from './brands/brands.component';
import { HttpClientModule } from '@angular/common/http';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { AdvertisementComponent } from './advertisement/advertisement.component';
import { AdvertisementFullComponent } from './advertisement-full/advertisement-full.component';

@NgModule({
   declarations: [
      AppComponent,
      BrandsComponent,
      FooterComponent,
      HeaderComponent,
      AdvertisementComponent,
      AdvertisementFullComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
