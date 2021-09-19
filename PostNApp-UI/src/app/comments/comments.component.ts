import { Component, Input, OnInit } from '@angular/core';
import { Comment } from '../interfaces/comment';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.css']
})
export class CommentsComponent implements OnInit {

  @Input() comment?: Comment;
  constructor() { }

  ngOnInit(): void {
  }

}
