import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './Navbar/Navbar.component';
import { MaterialModule } from '../material/material.module';
import { FooterComponent } from './Footer/Footer.component';
import { ScorllToTopComponent } from './scorll-to-top/scorll-to-top.component';
import { SharedHeaderComponent } from './shared-header/shared-header.component';

const sharedComponent = [NavbarComponent, FooterComponent ,ScorllToTopComponent,SharedHeaderComponent]
@NgModule({
  declarations: [
    sharedComponent,
    ScorllToTopComponent,
    SharedHeaderComponent,
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
