import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
<<<<<<< HEAD
import { HeaderComponent } from './Header/Header.component';

const sharedComponent=[HeaderComponent]


@NgModule({
  declarations: [sharedComponent],
  imports: [
    CommonModule 
  ],
  exports:[
    sharedComponent
=======
import { NavbarComponent } from './Navbar/Navbar.component';
import { MaterialModule } from '../material/material.module';
import { FooterComponent } from './Footer/Footer.component';
const sharedComponent=[NavbarComponent,FooterComponent]
@NgModule({
  declarations: [
    sharedComponent
  ],
  imports: [
    CommonModule, 
    MaterialModule
  ] , 
  exports: [
    sharedComponent,
>>>>>>> 964d6a2ec9f342ce88496c8aa304ad867f524fa0
  ]
})
export class ShareModule { }
