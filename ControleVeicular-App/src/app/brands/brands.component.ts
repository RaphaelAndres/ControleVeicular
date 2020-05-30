import { Component, OnInit } from '@angular/core';
import { triggerAsyncId } from 'async_hooks';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-brands',
  templateUrl: './brands.component.html',
  styleUrls: ['./brands.component.css']
})
export class BrandsComponent implements OnInit {

  brands: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getBrands();
  }

  getBrands() {
    this.brands = this.http.get('http://localhost:5000/api/Brands').subscribe(response => {
      this.brands = response;
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

}
