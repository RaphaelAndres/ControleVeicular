import { Component, OnInit, TemplateRef } from '@angular/core';
import { VehicleService } from '../../services/vehicle.service';
import { Vehicle } from '../../models/Vehicle';
import { BsModalService } from 'ngx-bootstrap/modal';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Brand } from 'src/app/models/Brand';
import { BrandService } from 'src/app/services/brand.service';

@Component({
  selector: 'app-vehicles',
  templateUrl: './vehicles.component.html',
  styleUrls: ['./vehicles.component.css']
})
export class VehiclesComponent implements OnInit {

  vehicles: Vehicle[];
  brands: Brand[];
  registerForm: FormGroup;
  vehicle: Vehicle;
  newRecord: boolean;
  selectedBrand: Brand;

  constructor(
    private vehicleService: VehicleService,
    private brandService: BrandService,
    private fb: FormBuilder,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
    this.getVehicles();
    this.getBrands();
    this.validation();
  }

  getBrands() {
    this.brandService.getAllBrands().subscribe(
    (brands: Brand[]) => {
      this.brands = brands;
    }, error => {
      console.log(error);
    });
  }

  getVehicles() {
    this.vehicleService.getAllVehicles().subscribe(
    (vehicles: Vehicle[]) => {
      this.vehicles = vehicles;
    }, error => {
      console.log(error);
    });
  }

  openModalEdit(template: any, vehicle: Vehicle){
    this.newRecord = false;
    this.registerForm.reset();
    template.show();
    this.vehicle = vehicle;
    this.registerForm.patchValue(vehicle);
  }

  closeModal(template: any){
    template.hide();
  }

  openModal(template: any){
    this.newRecord = true;
    this.registerForm.reset();
    template.show();
  }

  validation() {
    this.registerForm = this.fb.group({
      modelName: ['', [Validators.required, Validators.minLength(2)]],
      modelSpecification: ['', [Validators.required, Validators.minLength(1)]],
      bodytype: ['', []],
      engineDisplacement: ['', []],
      engineSpecification: ['', []],
      brandId: ['', [Validators.required]]
    });
  }

  salvarAlteracao(template: any) {
    if (this.registerForm.valid) {
      if (this.newRecord){
        this.vehicle = Object.assign({}, this.registerForm.value);
        console.log(this.vehicle);
        this.vehicleService.postVehicle(this.vehicle).subscribe(
          (newVehicle: Vehicle) => {
            template.hide();
            this.getVehicles();
            this.toastr.success('Registro gerado com sucesso!');
          }, error => {
            console.log(error);
            this.toastr.error('Erro ao inserir o registro!');
          }
        );
      }
      else{
        this.vehicle = Object.assign({id: this.vehicle.id}, this.registerForm.value);
        this.vehicleService.putVehicle(this.vehicle).subscribe(
          (newVehicle: Vehicle) => {
            template.hide();
            this.getVehicles();
            this.toastr.success('Registro alterado com sucesso!');
          }, error => {
            console.log(error);
            this.toastr.error('Erro ao alterar o registro!');
          }
        );
      }
    }
  }

  excluirRegistro(id: string) {
    this.vehicleService.deleteVehicle(id).subscribe(
      result => {
        this.getVehicles();
        this.toastr.success('Registro excluído com sucesso!');
      }, error => {
        console.log(error);
        this.toastr.error('Erro ao excluir o registro!');
      }
    );
  }

  findBrandInList(id: string) {
    if (this.brands){
      return this.brands.find(locate => locate.id === id).nome;
    }
    else{
      return '';
    }
  }

}
