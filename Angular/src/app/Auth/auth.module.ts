import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserRegComponent } from './user/UserReg/UserReg.component';
import { UserLoginComponent } from './UserLogin/UserLogin.component';
import { RouterModule } from '@angular/router';
import { ForgetPasswordComponent } from './password/forget-password/forget-password.component';
import { ResetPasswordComponent } from './password/reset-password/reset-password.component';
import { RegisterComponent } from './Regiter/Register/Register.component';
import { ProviderRegComponent } from './serviceProvider/provider-reg/provider-reg.component';
import { AuthRoutesMoudel } from './auth.routing.module';
import { LoadingSpinnerComponent } from './loading-spinner/loading-spinner.component';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';

@NgModule({
  declarations: [UserRegComponent, UserLoginComponent, ForgetPasswordComponent, ResetPasswordComponent,RegisterComponent, ProviderRegComponent, LoadingSpinnerComponent],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule,
    AuthRoutesMoudel,
    TranslateModule
  ],
  exports: [UserRegComponent,ForgetPasswordComponent],
})
export class AuthModule {}
