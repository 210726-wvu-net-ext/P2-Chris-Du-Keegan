import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormGroup, ReactiveFormsModule, FormsModule, FormBuilder } from '@angular/forms';
import { PostService } from '../post.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { AddCommentComponent } from './add-comment.component';
import { RouterTestingModule } from '@angular/router/testing';

describe('AddCommentComponent', () => {
  let component: AddCommentComponent;
  let fixture: ComponentFixture<AddCommentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule, RouterTestingModule, FormsModule, ReactiveFormsModule],      
      declarations: [ AddCommentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCommentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });



  it('should create AddComment Component', () => {
    const fixture = TestBed.createComponent(AddCommentComponent);
    const addcomment = fixture.componentInstance;
    expect(addcomment).toBeTruthy();
  });

  // it("should create a new comment", () => {
  //   // component.userId = 1;
  //   // component.username = "test";
  //   component.formGroup = new FormGroup({
  //     userId: new FormControl(1, [Validators.required]),
  //     username: new FormControl("test", [Validators.required]),
  //     commentBody: new FormControl('comment', [Validators.required]),
  //   })
  //   fixture.detectChanges();
  //   const compiled = fixture.debugElement.nativeElement;
  //   expect(compiled.innerHTML).toContain("Comment added!");
  //   // expect(compiled.innerHTML).toContain("comment");
  // });

});
