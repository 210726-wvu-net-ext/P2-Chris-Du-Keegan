import { ComponentFixture, TestBed } from '@angular/core/testing';
import { PostService } from '../post.service';
import { Post } from '../interfaces/post';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ExploreComponent } from './explore.component';
import { RouterTestingModule } from '@angular/router/testing';


describe('ExploreComponent', () => {
  let component: ExploreComponent;
  let fixture: ComponentFixture<ExploreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule, RouterTestingModule],
      declarations: [ ExploreComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExploreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    const fixture = TestBed.createComponent(ExploreComponent);
    const explore = fixture.componentInstance;
    expect(explore).toBeTruthy();
  });

  it('should get posts', () => {
    let testposts: Post[] = [];
    testposts = PostService.getPosts();

    expect(testposts).toEqual(component.posts);
  });
});
