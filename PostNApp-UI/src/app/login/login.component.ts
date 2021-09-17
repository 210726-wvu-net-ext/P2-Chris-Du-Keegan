
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

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
  
  constructor(private authService: AuthServiceService, private fb:FormBuilder, private router: Router) { }
  
  ngOnInit() {
  }
  // login(form: NgForm)
  // {
  //   const credentials = {
  //     'username': form.value.username,
  //     'password': form.value.password
  //   }
  //   this.http.post("https://localhost:5001/api/auth/login", credentials)
  //     .subscribe(response => {
  //       const token = (<any>response).token;
  //       localStorage.setItem("jwt", token);
  //       this.invalidLogin = false;
  //       this.router.navigate(["/"]);
  //     }, err => {
  //       this.invalidLogin = true;
  //     }
  //     )
  // }

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
          this.router.navigate(["/"]);
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
