import { Component, OnInit, Input} from '@angular/core';
import { UserService } from '../user.service';
import { User } from '../interfaces/user';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  @Input() user?: User;
  constructor(
    private userService: UserService,
    private route: ActivatedRoute
    ) { }

  ngOnInit(): void {
    this.getUser()
  }

  getUser(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.userService.getUser(1)
      .subscribe(user => this.user = user);
  }
}
