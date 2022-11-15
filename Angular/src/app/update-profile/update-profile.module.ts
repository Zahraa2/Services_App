import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UpdateProfileComponent } from './ui/update-profile/update-profile.component';
import { ShareModule } from '../Share/share.module';

@NgModule({
  declarations: [
    UpdateProfileComponent
  ],
  imports: [
    CommonModule,
    ShareModule
  ],exports:[
 UpdateProfileComponent
  ]
})
export class UpdateProfileModule { }
