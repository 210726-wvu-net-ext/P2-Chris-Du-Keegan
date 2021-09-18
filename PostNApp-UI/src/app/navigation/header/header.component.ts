import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthServiceService } from 'src/app/auth-service.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  @Output() public sidenavToggle = new EventEmitter();
  constructor(private authService: AuthServiceService) { }

  ngOnInit(): void {
  }

  public onToggleSidenav =() => {
    this.sidenavToggle.emit();
  }

  public logOut = () => {
    localStorage.removeItem("jwt");
    alert("You have logged out. Come back soon!");
  }

  isAdmin(): boolean {
    return this.authService.currentUser.role == "Administrator" ? true : false;
  }
  isUser(): boolean {
    return this.authService.currentUser.role == "User" ? true : false;
  }
}
