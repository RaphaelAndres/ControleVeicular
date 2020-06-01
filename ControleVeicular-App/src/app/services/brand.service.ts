import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Brand } from '../models/Brand';

@Injectable({
  providedIn: 'root'
})
export class BrandService {
  baseUrl: string = environment.baseUrl + 'Brands/';
  constructor(private http: HttpClient) { }

  getAllBrands(): Observable<Brand[]> {
    return this.http.get<Brand[]>(this.baseUrl);
  }

  getBrandById(id: string): Observable<Brand> {
    return this.http.get<Brand>(this.baseUrl + id);
  }

  postBrand(brand: Brand){
    return this.http.post(this.baseUrl, brand);
  }

  putBrand(brand: Brand){
    console.log(brand);
    console.log(brand.id);
    return this.http.put(this.baseUrl + brand.id, brand);
  }

  deleteBrand(id: string){
    return this.http.delete(this.baseUrl + id);
  }
}
