import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { UserLoginRequest } from 'src/app/dtos/userLoginDto';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [AuthService]
})
export class LoginComponent implements OnInit {
  form: FormGroup;
  userLoginRequest: UserLoginRequest = new UserLoginRequest();
  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      username: new FormControl(null),
      password: new FormControl(null)
    });
  }

  login(){
    this.userLoginRequest.Username = this.form.controls['username'].value;
    this.userLoginRequest.Password = this.form.controls['password'].value; 

    this.authService.Login(this.userLoginRequest).then(x=>{
      this.router.navigateByUrl('/home');
    });
  }
}
