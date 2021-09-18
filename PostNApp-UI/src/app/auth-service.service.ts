import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from 'src/environments/environment';
import { JwtHelperService } from "@auth0/angular-jwt";
import { map } from 'rxjs/operators';
import { IUser } from './interfaces/app-user';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {


  currentUser: IUser = {
    id: -1,
    username: "",
    email: "",
    role: "",
  }

  helper = new JwtHelperService();
  constructor(private http: HttpClient) { }


  login(data: any): Observable<IUser> {
    return this.http.post(`${baseUrl}auth/login`, data)
      .pipe(
        map((response: any) => {
          const decodeToken = this.helper.decodeToken(response.token);
          this.currentUser.id = response.userId;
          this.currentUser.username = decodeToken.nameid;
          this.currentUser.email = decodeToken.email;
          this.currentUser.role = response.role;
          localStorage.setItem('jwt', response.token)

          return this.currentUser;
        })
      );
  }

  loggedIn(): boolean {
    const token = localStorage.getItem('jwt') || '{}';
    return !this.helper.isTokenExpired(token);
  }

}
