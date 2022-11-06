import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './Header/Header.component';

const sharedComponent=[HeaderComponent]


@NgModule({
  declarations: [sharedComponent],
  imports: [
    CommonModule 
  ],
  exports:[
    sharedComponent
  ]
})
export class ShareModule { }
