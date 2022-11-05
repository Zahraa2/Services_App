import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FooterComponent } from './Footer/Footer.component';



@NgModule({
  declarations:[FooterComponent],
  imports: [
    CommonModule
  ],
  exports:[FooterComponent]
})
export class ShareModule { }
