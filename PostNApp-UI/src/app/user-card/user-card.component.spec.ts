
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Router } from '@angular/router';
import { of } from 'rxjs';
import { Observable } from 'rxjs';
import { User } from '../interfaces/user';
import { UserService } from '../user.service';
import { ActivatedRoute } from '@angular/router';


import { UserCardComponent } from './user-card.component';
import { AuthService } from '../auth.service';

describe('UserCardComponent', () => {
  let component: UserCardComponent;
  let fixture: ComponentFixture<UserCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserCardComponent ],
      providers: [
        {provide: UserService, useClass: fakeUserService}, 
        {provide: AuthService, useClass: fakeAuth}
      ],
      imports: [HttpClientModule]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
class fakeUserService{

}
class fakeAuth{

}