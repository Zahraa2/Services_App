import { NgModule } from '@angular/core';
import {MatIconModule} from '@angular/material/icon';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatMenuModule} from '@angular/material/menu';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {MatDividerModule} from '@angular/material/divider';


const MaterialComponents = [
  MatIconModule,
  MatSidenavModule,
  MatMenuModule,
  MatAutocompleteModule,
  MatFormFieldModule,
  MatSlideToggleModule,
  MatDividerModule
]


@NgModule({
  declarations: [],
  imports: [MaterialComponents], 
  exports: [
    MaterialComponents
  ]
})
export class MaterialModule { }
