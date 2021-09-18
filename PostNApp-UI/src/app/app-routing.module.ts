import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsersComponent } from './users/users.component';
import { ProfileComponent } from './profile/profile.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './guards/auth-gaurd.service';
import { RegisterComponent } from './register/register.component';


const routes: Routes = [
  { path: '', redirectTo: '/', pathMatch: 'full' },
  { path: 'profile', component: ProfileComponent },
  { path: 'profile/update/:id', component: UserDetailComponent, canActivate: [AuthGuard] },
  { path: 'users', component: UsersComponent },
  { path: 'login', component: LoginComponent},
  { path: 'register', component: RegisterComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes), ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
