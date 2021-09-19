import { Component, Input, OnInit } from '@angular/core';
import { Post } from '../interfaces/post';
import { AuthService } from '../auth.service';
import { PostService } from '../post.service';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-edit-post',
  templateUrl: './edit-post.component.html',
  styleUrls: ['./edit-post.component.css']
})
export class EditPostComponent implements OnInit {
  @Input() post?: Post;

  userId = this.authService.currentUser.id;
  username = this.authService.currentUser.username;

  formGroup = new FormGroup({
    userId: new FormControl(this.userId, [Validators.required]),
    title: new FormControl(this.post?.title, [Validators.required]),
    body: new FormControl(this.post?.body, [Validators.required]),
    username: new FormControl(this.username, [Validators.required])
  })

  constructor(
    private route: ActivatedRoute,
    private authService: AuthService,
    private postService: PostService,
    private fb: FormBuilder
  ) { }
  
  ngOnInit(): void {
  }

  updatePost() {
    if (this.formGroup.valid)
    {
      const postObserver ={
        next: (x: any) => 
        {
          alert('Post added!');
        },
        error: (err:any) =>
        {
          console.log(err);
          alert("Unable to post. Please try again.");
        }
      };
      const postId = Number(this.route.snapshot.paramMap.get('id'));
      this.postService.updatePost(postId, this.formGroup.value)
        .subscribe(postObserver)
    } else {
      alert("Missing post information!");
    }
  }
  reloadCurrentPage() {
    window.location.reload();
   }
}
