import { Component, OnInit } from '@angular/core';
import { Post } from '../interfaces/post';
import { PostService } from '../post.service';

@Component({
  selector: 'app-explore',
  templateUrl: './explore.component.html',
  styleUrls: ['./explore.component.css']
})
export class ExploreComponent implements OnInit {
  
  posts: Post[] = [];

  constructor(private postService: PostService, private location: Location) { }

  ngOnInit(): void {
    this.getPosts();
  }
  getPosts(): void {
    this.postService.getPosts()
      .subscribe(posts => this.posts = posts);
  }
  goBack(): void {
    this.location;
  }

}
