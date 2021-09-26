import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../user.service';
import { of, Observable } from 'rxjs';
import { User } from '../interfaces/user';

import { ProfileComponent } from './profile.component';
import { AuthService } from '../auth.service';

describe('ProfileComponent', () => {
  let component: ProfileComponent;
  let fixture: ComponentFixture<ProfileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProfileComponent ],
      providers: [
        {provide: UserService, useClass: fakeUserService},
        {provide: AuthService, useClass: fakeAuth},
        {provide: ActivatedRoute, useClass: fakeRoute}
      ],
      imports: [HttpClientModule]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
class fakeUserService{
  getUser(id: number): Observable<User>{
    return of();
  }
}
class fakeAuth{}
class fakeRoute{}