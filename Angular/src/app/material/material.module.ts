import { NgModule } from '@angular/core';
import {MatIconModule} from '@angular/material/icon';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatMenuModule} from '@angular/material/menu';

const MaterialComponents = [
  MatIconModule,
  MatSidenavModule,
  MatMenuModule
]


@NgModule({
  declarations: [],
  imports: [MaterialComponents], 
  exports: [
    MaterialComponents
  ]
})
export class MaterialModule { }
