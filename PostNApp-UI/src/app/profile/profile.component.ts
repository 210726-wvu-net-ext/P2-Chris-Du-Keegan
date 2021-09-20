import { Component, OnInit, Input} from '@angular/core';
import { UserService } from '../user.service';
import { User } from '../interfaces/user';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/auth.service';
import { PostService } from '../post.service';
import { Post } from '../interfaces/post';


@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  
  img: boolean = false;
  
  
  posts: Post[] = [];
  @Input() user?: User;
  constructor(
    private userService: UserService,
    private route: ActivatedRoute,
    private authServiceService: AuthService,
    private postService: PostService,
    ) { }

   
  ngOnInit(): void {
    this.getUser(),
    this.getUserPosts()
  }

  getUser(): void {
    
    const id = this.authServiceService.currentUser.id;
    this.userService.getUser(id)
      .subscribe(
        user => {
        this.user = user; 
        },
        posts => {
          posts = this.user?.posts
        }
        //p => {if((this.user?.posts[0].image) == null) this.img = true;},
        //num => {num = this.user?.posts.length;}  
      );
  }
  getUserPosts(): void {
    
    this.postService.getPosts()
      .subscribe(posts => this.posts = posts);
  }
  


}
