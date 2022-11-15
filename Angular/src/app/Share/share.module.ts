import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './Navbar/Navbar.component';
import { MaterialModule } from '../material/material.module';
import { FooterComponent } from './Footer/Footer.component';
import { AppRoutingModule } from '../app-routing.module';
import { ScorllToTopComponent } from './scorll-to-top/scorll-to-top.component';
import { SharedHeaderComponent } from './shared-header/shared-header.component';
import { LoadingSpinnerComponent } from './loading-spinner/loading-spinner.component';


const sharedComponent = [NavbarComponent, FooterComponent ,ScorllToTopComponent,SharedHeaderComponent,LoadingSpinnerComponent]

<<<<<<< HEAD
=======

const sharedComponent = [NavbarComponent, FooterComponent ,ScorllToTopComponent,SharedHeaderComponent]

>>>>>>> e00f792892fec825d1b4d6f275d6abc42a5b204f
@NgModule({
  declarations: [
    sharedComponent,
    ScorllToTopComponent,
    SharedHeaderComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule, 
    AppRoutingModule
    
  ],
  exports: [
    sharedComponent,
  ]
})
export class ShareModule { }
