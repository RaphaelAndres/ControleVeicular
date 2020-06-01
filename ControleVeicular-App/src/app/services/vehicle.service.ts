import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Vehicle } from '../models/Vehicle';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  baseUrl: string = environment.baseUrl + 'Vehicles/';
  constructor(private http: HttpClient) { }

  getAllVehicles(): Observable<Vehicle[]> {
    return this.http.get<Vehicle[]>(this.baseUrl);
  }

  getVehicleById(id: string): Observable<Vehicle> {
    return this.http.get<Vehicle>(this.baseUrl + id);
  }

  postVehicle(vehicle: Vehicle){
    return this.http.post(this.baseUrl, vehicle);
  }

  putVehicle(vehicle: Vehicle){
    console.log(vehicle);
    console.log(vehicle.id);
    return this.http.put(this.baseUrl + vehicle.id, vehicle);
  }

  deleteVehicle(id: string){
    return this.http.delete(this.baseUrl + id);
  }
}
