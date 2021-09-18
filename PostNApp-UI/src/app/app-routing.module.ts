import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsersComponent } from './users/users.component';
import { ProfileComponent } from './profile/profile.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './guards/auth-gaurd.service';
import { ExploreComponent } from './explore/explore.component';


const routes: Routes = [
  { path: '', redirectTo: '/', pathMatch: 'full' },
  { path: 'profile', component: ProfileComponent },
  { path: 'profile/update/:id', component: UserDetailComponent, canActivate: [AuthGuard] },
  { path: 'users', component: UsersComponent },
  { path: 'explore', component: ExploreComponent},
  { path: 'login', component: LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes), ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
