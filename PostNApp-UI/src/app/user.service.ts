import { Injectable } from '@angular/core';
import { User } from './interfaces/user';
import { USERS } from './mock-users';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor() { }
  getUsers(): Observable<User[]>
  {
    const users = of(USERS);
    return users;
  }
  getUser(id: number): Observable<User>
  {
    const user = USERS.find(u => u.Id === id)!;
    return of(user);
  }
}
