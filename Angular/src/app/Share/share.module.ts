import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './Navbar/Navbar.component';
import { MaterialModule } from '../material/material.module';
import { FooterComponent } from './Footer/Footer.component';
import { AppRoutingModule } from '../app-routing.module';
import { ScorllToTopComponent } from './scorll-to-top/scorll-to-top.component';
import { TranslateModule } from '@ngx-translate/core';


const sharedComponent = [NavbarComponent, FooterComponent ,ScorllToTopComponent]

@NgModule({
  declarations: [
    sharedComponent,
    ScorllToTopComponent,
    
  ],
  imports: [
    CommonModule,
    TranslateModule,
    MaterialModule, 
    AppRoutingModule
    
  ],
  exports: [
    sharedComponent,TranslateModule
  ]
})
export class ShareModule { }
