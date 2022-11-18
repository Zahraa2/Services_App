import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';
import { ForgetPasswordComponent } from './password/forget-password/forget-password.component';
import { ResetPasswordComponent } from './password/reset-password/reset-password.component';
import { RegisterComponent } from './Regiter/Register/Register.component';
import { ProviderRegComponent } from './serviceProvider/provider-reg/provider-reg.component';
import { UserRegComponent } from './user/UserReg/UserReg.component';
import { UserLoginComponent } from './UserLogin/UserLogin.component';

const routes: Routes = [
  { path: 'login', component: UserLoginComponent, canActivate: [AuthGuard] },
  { path: 'register', component: RegisterComponent, canActivate: [AuthGuard] },
  { path: 'userRegister', component: UserRegComponent, canActivate: [AuthGuard] },
  { path: 'sellerRegister', component: ProviderRegComponent, canActivate: [AuthGuard] },
  { path: 'forgetPassword', component: ForgetPasswordComponent ,canActivate: [AuthGuard]},
  { path: 'resetpassword', component: ResetPasswordComponent ,canActivate: [AuthGuard]},
];

export const AuthRoutesModule = RouterModule.forChild(routes);
