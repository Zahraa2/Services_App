import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
<<<<<<< HEAD
import { NavbarComponent } from './Navbar/Navbar.component';
import { MaterialModule } from '../material/material.module';
=======
import { FooterComponent } from './Footer/Footer.component';
>>>>>>> 6580953ab32711b8388c92f972a2ae59e0eb45e3



@NgModule({
<<<<<<< HEAD
  declarations: [
    NavbarComponent
  ],
  imports: [
    CommonModule, 
    MaterialModule
  ] , 
  exports: [
    NavbarComponent
  ]
=======
  declarations:[FooterComponent],
  imports: [
    CommonModule
  ],
  exports:[FooterComponent]
>>>>>>> 6580953ab32711b8388c92f972a2ae59e0eb45e3
})
export class ShareModule { }
