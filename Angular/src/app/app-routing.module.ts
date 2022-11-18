import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './Auth/guards/auth.guard';
import { UserLoginComponent } from './Auth/UserLogin/UserLogin.component';
import { OnboardingComponent } from './onboarding/UI/onboarding.component';
import { ForgetPasswordComponent } from './Auth/password/forget-password/forget-password.component';
import { ResetPasswordComponent } from './Auth/password/reset-password/reset-password.component';
import { RegisterComponent } from './Auth/Regiter/Register/Register.component';
import { UserRegComponent } from './Auth/user/UserReg/UserReg.component';
import { ProviderRegComponent } from './Auth/serviceProvider/provider-reg/provider-reg.component';
import { ChangePassComponent } from './setting/change-pass/change-pass.component';


const routes: Routes = [
  { path: '', component: OnboardingComponent },

  {
    path: 'خدماتنا',
    loadChildren: () =>
      import('./Categories/categories.module').then((m) => m.CategoriesModule),
  },

  { path: 'login', component: UserLoginComponent, canActivate: [AuthGuard] },
  { path: 'register', component: RegisterComponent, canActivate: [AuthGuard] },
  { path: 'userRegister', component: UserRegComponent, canActivate: [AuthGuard] },
  { path: 'sellerRegister', component: ProviderRegComponent, canActivate: [AuthGuard] },
  { path: 'forgetPassword', component: ForgetPasswordComponent ,canActivate: [AuthGuard]},
  { path: 'resetpassword', component: ResetPasswordComponent ,canActivate: [AuthGuard]},
  { path: 'profile', component: ChangePassComponent },
  { path: '', component: OnboardingComponent},

  {path: 'خدماتنا', loadChildren: () => import('./Categories/categories.module').then(m => m.CategoriesModule)},

];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
