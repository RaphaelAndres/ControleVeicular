import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  titulo = 'Login';
  model: any = {};

  constructor(private authService: AuthService,
              public router: Router,
              private toastr: ToastrService) { }

  ngOnInit() {
    if (localStorage.getItem('token') != null) {
      console.log(this.router.url);
      this.router.navigateByUrl('/brands');
    }
  }

  login() {
    this.authService.login(this.model)
      .subscribe(
        () => {
          this.router.navigateByUrl('/brands');
          this.toastr.success('Logado com Sucesso');
        },
        error => {
          this.toastr.error('Falha ao tentar Logar');
        }
      );
  }

}
