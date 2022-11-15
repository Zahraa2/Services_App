import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserRegComponent } from './user/UserReg/UserReg.component';
import { ShareModule } from '../Share/share.module';
import { UserLoginComponent } from './UserLogin/UserLogin.component';
import { RouterModule } from '@angular/router';
import { ForgetPasswordComponent } from './password/forget-password/forget-password.component';
import { ResetPasswordComponent } from './password/reset-password/reset-password.component';
import { RegisterComponent } from './Regiter/Register/Register.component';
import { ProviderRegComponent } from './serviceProvider/provider-reg/provider-reg.component';

@NgModule({
  declarations: [UserRegComponent, UserLoginComponent, ForgetPasswordComponent, ResetPasswordComponent,RegisterComponent, ProviderRegComponent],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    FormsModule,
    ShareModule,
    RouterModule
  ],
  exports: [UserRegComponent],
})
export class AuthModule {}
