import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './Navbar/Navbar.component';
import { MaterialModule } from '../material/material.module';
import { FooterComponent } from './Footer/Footer.component';
import { HeaderComponent } from './Header/Header.component';
import { AppRoutingModule } from '../app-routing.module';

const sharedComponent = [NavbarComponent, FooterComponent , HeaderComponent]
@NgModule({
  declarations: [
    sharedComponent
  ],
  imports: [
    CommonModule,
    MaterialModule, 
    AppRoutingModule
  ],
  exports: [
    sharedComponent
  ]
})
export class ShareModule { }
