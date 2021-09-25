import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PostService } from '../post.service';

import { AddCommentComponent } from './add-comment.component';

describe('AddCommentComponent', () => {
  let component: AddCommentComponent;
  let fixture: ComponentFixture<AddCommentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddCommentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCommentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  // it('should create AddComment Component', () => {
  //   expect(component).toBeTruthy();
  // });

  it("should create a new comment", () => {
    // component.userId = 1;
    // component.username = "test";
    component.formGroup = new FormGroup({
      userId: new FormControl(1, [Validators.required]),
      username: new FormControl("test", [Validators.required]),
      commentBody: new FormControl('comment', [Validators.required]),
    })
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.innerHTML).toContain("Comment added!");
    // expect(compiled.innerHTML).toContain("comment");
  });

});
