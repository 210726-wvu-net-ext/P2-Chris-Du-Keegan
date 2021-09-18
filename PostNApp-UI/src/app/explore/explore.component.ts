import { Component, OnInit } from '@angular/core';
import { Post } from '../interfaces/post';

@Component({
  selector: 'app-explore',
  templateUrl: './explore.component.html',
  styleUrls: ['./explore.component.css']
})
export class ExploreComponent implements OnInit {
  
  posts: Post[] = [];

  constructor() { }

  ngOnInit(): void {
    this.getPosts();
  }
  getPosts(): void {
    //this.postService.getUsers()
      //.subscribe(posts => this.posts = posts);
  }

}
