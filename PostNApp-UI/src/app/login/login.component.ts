
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { AuthServiceService } from '../auth-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formGroup = new FormGroup({
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required])
  });

  invalidLogin = new Boolean;

  constructor(private authService: AuthServiceService, private fb: FormBuilder, private router: Router, private location: Location) { }

  ngOnInit() {
  }

  loginProcess() {
    if (this.formGroup.valid) {
      const loginObserver = {
        next: (x: any) => {
          alert('Welcome back ' + x.username);
        },
        error: (err: any) => {
          console.log(err);
          alert('Unable to Login. Please check your credentials.');
        },
      };
      this.authService.login(this.formGroup.value)
        .subscribe(loginObserver)
    } else {
      alert("Please enter in your information!");
    }
  }

}
