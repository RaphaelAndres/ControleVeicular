import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Advertisement } from '../models/Advertisement';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AdvertisementService {
  baseUrl: string = environment.baseUrl + 'Advertisements/';
  constructor(private http: HttpClient) { }

  getAllAdvertisements(): Observable<Advertisement[]> {
    return this.http.get<Advertisement[]>(this.baseUrl);
  }

  getAdvertisementById(id: string): Observable<Advertisement> {
    return this.http.get<Advertisement>(this.baseUrl + id);
  }

  postAdvertisement(advertisement: Advertisement){
    console.log(this.baseUrl);
    return this.http.post(this.baseUrl, advertisement);
  }

  putAdvertisement(advertisement: Advertisement){
    console.log(advertisement);
    console.log(advertisement.id);
    return this.http.put(this.baseUrl + advertisement.id, advertisement);
  }

  deleteAdvertisement(id: string){
    return this.http.delete(this.baseUrl + id);
  }
}
