import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChangePassComponent } from './change-pass/change-pass.component';
import { ShareModule } from '../Share/share.module';
import {ReactiveFormsModule} from '@angular/forms'

@NgModule({
  declarations: [
    ChangePassComponent,
  ],
  imports: [
    CommonModule,
    ShareModule,
    ReactiveFormsModule
  ],
  exports:[ChangePassComponent]
})
export class SettingModule { }
