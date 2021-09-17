import { Component, OnInit } from '@angular/core';
import { last } from 'rxjs/operators';
import { User } from '../interfaces/user';
import { UserService } from '../user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  users: User[] = [];
  
  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.getUsers();
  }
  getUsers(): void {
    this.userService.getUsers()
      .subscribe(users => this.users = users);
  }

  add(firstName: string, lastName: string, username: string, email: string, phoneNumber: string, password: string, aboutMe: string, state: string, country: string, ): void {
    firstName = firstName.trim();
    lastName = lastName.trim();
    username = username.trim();
    email = email.trim();
    if (!firstName && !lastName && !username && !email) { return; }
    this.userService.addUser({ firstName, lastName, username, email, phoneNumber, password, aboutMe, state, country } as User)
      .subscribe(user => {
        this.users.push(user);
      });
    }
}
