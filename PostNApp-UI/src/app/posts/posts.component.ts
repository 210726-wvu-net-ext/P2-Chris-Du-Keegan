import { Component, Input, OnInit } from '@angular/core';
import { Post } from '../interfaces/post';



@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {
  panelOpenState = false;
  
  @Input() post?: Post;

  constructor() { }

  ngOnInit(): void {
  }
 
}