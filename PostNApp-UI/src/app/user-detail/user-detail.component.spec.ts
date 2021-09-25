import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../user.service';
import { of, Observable } from 'rxjs';
import { User } from '../interfaces/user';

import { UserDetailComponent } from './user-detail.component';

describe('UserDetailComponent', () => {
  let component: UserDetailComponent;
  let fixture: ComponentFixture<UserDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserDetailComponent ],
      providers: [
        {provide: UserService, useClass: fakeUserService},
        {provide: ActivatedRoute, useClass: fakeRoute},
        {provide: Location, useClass: fakeLocation}
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
class fakeUserService{
  getUsers(): Observable<User[]>{
    return of([]);
  }
}
class fakeRoute{}
class fakeLocation{}
