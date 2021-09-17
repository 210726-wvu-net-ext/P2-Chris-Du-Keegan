import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsersComponent } from './users/users.component';
import { ProfileComponent } from './profile/profile.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'users', component: UsersComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'userdetail/:id', component: UserDetailComponent }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
