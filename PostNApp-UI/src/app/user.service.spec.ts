import { TestBed } from '@angular/core/testing';

import { UserService } from './user.service';

describe('UserService', () => {
  let service: UserService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should create a user i an array', () => {
    const id = 1;
    const firstName = "First";
    const lastName = "Last";
    const email = "test@revature.com";
    const username = "Test";
    const password = "Password#123";
    const aboutMe = "bio";
    const state = "Florida";
    const country = "United States";
    const role = "user";
    const phoneNumber = "1234567890";
    const doB = Date;
  });
});
