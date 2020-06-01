import { Component, OnInit, TemplateRef } from '@angular/core';
import { AdvertisementService } from '../../services/advertisement.service';
import { Advertisement } from '../../models/Advertisement';
import { BsModalService } from 'ngx-bootstrap/modal';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Vehicle } from 'src/app/models/Vehicle';
import { VehicleService } from 'src/app/services/vehicle.service';

@Component({
  selector: 'app-advertisements',
  templateUrl: './advertisements.component.html',
  styleUrls: ['./advertisements.component.css']
})
export class AdvertisementsComponent implements OnInit {

  advertisements: Advertisement[];
  vehicles: Vehicle[];
  registerForm: FormGroup;
  advertisement: Advertisement;
  newRecord: boolean;
  selectedVehicle: Vehicle;

  constructor(
    private advertisementService: AdvertisementService,
    private vehicleService: VehicleService,
    private fb: FormBuilder,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
    this.getAdvertisements();
    this.getVehicles();
    this.validation();
  }

  getVehicles() {
    this.vehicleService.getAllVehicles().subscribe(
    (vehicles: Vehicle[]) => {
      this.vehicles = vehicles;
      console.log(this.vehicles);
    }, error => {
      console.log(error);
    });
  }

  getAdvertisements() {
    this.advertisementService.getAllAdvertisements().subscribe(
    (advertisements: Advertisement[]) => {
      this.advertisements = advertisements;
    }, error => {
      console.log(error);
    });
  }

  openModalEdit(template: any, advertisement: Advertisement){
    this.newRecord = false;
    this.registerForm.reset();
    template.show();
    this.advertisement = advertisement;
    this.registerForm.patchValue(advertisement);
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
      modelYear: ['', [Validators.required, Validators.minLength(2), Validators.min(0), Validators.max(2099)]],
      fabricationYear: ['', [Validators.required, Validators.minLength(2), Validators.min(0), Validators.max(2099)]],
      color: ['', [Validators.required, Validators.minLength(1)]],
      fuelType: ['', [Validators.required, Validators.minLength(1)]],
      transmissionType: ['', []],
      driveTrain: ['', []],
      sellDate: ['', []],
      buyPrice: ['', [Validators.required]],
      sellPrice: ['', [Validators.required]],
      vehicleId: ['', [Validators.required]]
    });
  }

  salvarAlteracao(template: any) {
    if (this.registerForm.valid) {
      if (this.newRecord){
        this.advertisement = Object.assign({}, this.registerForm.value);
        console.log(this.advertisement);
        this.advertisementService.postAdvertisement(this.advertisement).subscribe(
          (newAdvertisement: Advertisement) => {
            template.hide();
            this.getAdvertisements();
            this.toastr.success('Registro gerado com sucesso!');
          }, error => {
            console.log(error);
            this.toastr.error('Erro ao inserir o registro!');
          }
        );
      }
      else{
        this.advertisement = Object.assign({id: this.advertisement.id}, this.registerForm.value);
        this.advertisementService.putAdvertisement(this.advertisement).subscribe(
          (newAdvertisement: Advertisement) => {
            template.hide();
            this.getAdvertisements();
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
    this.advertisementService.deleteAdvertisement(id).subscribe(
      result => {
        this.getAdvertisements();
        this.toastr.success('Registro excluído com sucesso!');
      }, error => {
        console.log(error);
        this.toastr.error('Erro ao excluir o registro!');
      }
    );
  }

  findVehicle(id: string) {
    if (this.vehicles){
      let vehicle = this.vehicles.find(locate => locate.id === id);
      return vehicle.modelName + ' ' + vehicle.modelSpecification;
    }
    else{
      return '';
    }
  }

}