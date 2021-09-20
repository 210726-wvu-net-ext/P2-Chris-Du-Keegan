import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsersComponent } from './users/users.component';
import { ProfileComponent } from './profile/profile.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './guards/auth-gaurd.service';
import { ExploreComponent } from './explore/explore.component';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { SearchComponent } from './search/search.component';
import { EditPostComponent } from './edit-post/edit-post.component';


const routes: Routes = [
  { path: '', redirectTo: '/', pathMatch: 'full' },
  { path: '', component: HomeComponent},
  { path: 'edit/post/:id', component: EditPostComponent},
  { path: 'profile', component: ProfileComponent,  canActivate: [AuthGuard]},
  { path: 'profile/update/:id', component: UserDetailComponent, canActivate: [AuthGuard] },
  { path: 'users', component: UsersComponent, canActivate: [AuthGuard] },
  { path: 'explore', component: ExploreComponent},
  { path: 'login', component: LoginComponent},
  { path: 'register', component: RegisterComponent},
  { path: 'search', component: SearchComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes), ] ,
  exports: [RouterModule]
})
export class AppRoutingModule { }
