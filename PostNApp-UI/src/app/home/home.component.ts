import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { PostService } from '../post.service';
import { Post } from '../interfaces/post';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  posts: Post[] = [];
  constructor(private jwtHelper: JwtHelperService, private router: Router, private postService: PostService) {}

  returnUserId() {
    const token: string = JSON.parse(localStorage.getItem("jwt")!);
    const userId: string = this.jwtHelper.decodeToken(token).NameIdentifier;
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      alert(userId);
      return userId;
    }
    else {
      return null;
    }
  }

  isUserAuthenticated() {
    const token: string = JSON.parse(localStorage.getItem("jwt")!);
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    else {
      return false;
    }
  }
  ngOnInit(): void {
    this.getPosts();
    this.returnUserId();
  }
  getPosts(): void {
    this.postService.getPosts()
      .subscribe(posts => this.posts = posts);
  }

  
}