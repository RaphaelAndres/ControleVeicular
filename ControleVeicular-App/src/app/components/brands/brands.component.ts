import { Component, OnInit, TemplateRef } from '@angular/core';
import { BrandService } from '../../services/brand.service';
import { Brand } from '../../models/Brand';
import { BsModalService } from 'ngx-bootstrap/modal';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-brands',
  templateUrl: './brands.component.html',
  styleUrls: ['./brands.component.css']
})
export class BrandsComponent implements OnInit {

  brands: Brand[];
  registerForm: FormGroup;
  brand: Brand;
  newRecord: boolean;

  constructor(
    private brandService: BrandService,
    private fb: FormBuilder,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
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

  openModalEdit(template: any, brand: Brand){
    this.newRecord = false;
    this.registerForm.reset();
    template.show();
    this.brand = brand;
    this.registerForm.patchValue(brand);
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
      nome: ['', [Validators.required, Validators.minLength(2)]],
      pais: ['', [Validators.required, Validators.minLength(2)]]
    });
  }

  salvarAlteracao(template: any) {
    if (this.registerForm.valid) {
      if (this.newRecord){
        this.brand = Object.assign({}, this.registerForm.value);
        this.brandService.postBrand(this.brand).subscribe(
          (newBrand: Brand) => {
            template.hide();
            this.getBrands();
            this.toastr.success('Registro gerado com sucesso!');
          }, error => {
            console.log(error);
            this.toastr.error('Erro ao inserir o registro!');
          }
        );
      }
      else{
        this.brand = Object.assign({id: this.brand.id}, this.registerForm.value);
        this.brandService.putBrand(this.brand).subscribe(
          (newBrand: Brand) => {
            template.hide();
            this.getBrands();
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
    this.brandService.deleteBrand(id).subscribe(
      result => {
        this.getBrands();
        this.toastr.success('Registro excluído com sucesso!');
      }, error => {
        console.log(error);
        this.toastr.error('Erro ao excluir o registro!');
      }
    );
  }

}
