import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './Navbar/Navbar.component';
import { MaterialModule } from '../material/material.module';
import { FooterComponent } from './Footer/Footer.component';
import { AppRoutingModule } from '../app-routing.module';
import { ScorllToTopComponent } from './scorll-to-top/scorll-to-top.component';


const sharedComponent = [NavbarComponent, FooterComponent ,ScorllToTopComponent]

@NgModule({
  declarations: [
    sharedComponent,
    ScorllToTopComponent,
    
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
