import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Role } from 'src/app/models/role';
import { User } from 'src/app/models/user';
import { RoleService } from 'src/app/services/role.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  form: FormGroup;
  roles: Role[] = new Array();
  user: User = new User();
  constructor(private userService: UserService, private router: Router, private roleService: RoleService) { }

  ngOnInit(): void {
    this.roleService.get().subscribe(r => {
      if (r != null) {
        this.roles = r;
      }
    });

    this.form = new FormGroup({
      firstname: new FormControl(null),
      lastname: new FormControl(null),
      username: new FormControl(null),
      email: new FormControl(null),
      password: new FormControl(null),
      role: new FormControl()
    });
  }

  changeRole(e) {
    this.form.get('role').setValue(e.target.value, {
      onlySelf: true,
    });
  }

  register() {
    this.user.FirstName = this.form.controls['firstname'].value;
    this.user.LastName = this.form.controls['lastname'].value;
    this.user.Username = this.form.controls['username'].value;
    this.user.Email = this.form.controls['email'].value;
    this.user.Password = this.form.controls['password'].value;
    this.user.RoleId = this.form.controls['role'].value;

    this.userService.post(this.user).subscribe(u => {
      if (u != null) {
        this.user = u;
        this.router.navigateByUrl('/login');
      }
    });
  }
}
