import { Component, OnInit } from '@angular/core';
import { User } from '../interfaces/user';
import { UserService } from '../user.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  constructor(private location: Location) { }

  ngOnInit(): void {
  }
  
  goBack(): void {
    this.location.back();
  }
}
