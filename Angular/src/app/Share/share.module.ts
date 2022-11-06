import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './Navbar/Navbar.component';
import { MaterialModule } from '../material/material.module';
import { FooterComponent } from './Footer/Footer.component';
import { HeaderComponent } from './Header/Header.component';

const sharedComponent = [NavbarComponent, FooterComponent , HeaderComponent]
@NgModule({
  declarations: [
    sharedComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [
    sharedComponent
  ]
})
export class ShareModule { }
