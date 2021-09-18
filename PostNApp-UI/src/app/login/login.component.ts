
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
    username: new FormControl('',[Validators.required]),
    password: new FormControl('',[Validators.required])
  });

  invalidLogin = new Boolean;
  
  constructor(private authService: AuthServiceService, private fb:FormBuilder, private router: Router, private location: Location) { }
  
  ngOnInit() {
  }

  loginProcess(){
    if(this.formGroup.valid)
    {
      this.authService.login(this.formGroup.value)
            .subscribe(response => {
        if(response.success){
          alert(response.message);
          const token = (response).token;
          localStorage.setItem("jwt", token);
          this.invalidLogin = false;
          //this.router.navigate(["/"]);
          this.location.back();
        } else {
          alert(response.message);
        }
      }, err => {
        alert("Login Credentials Invalid");
        this.invalidLogin = true;
      }
      )
  }}

}
