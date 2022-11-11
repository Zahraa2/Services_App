import { NgModule} from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { ShareModule } from '../Share/share.module';
import { HomeComponent } from './UI/Home/Home.component';
import { CategoriesModuleModule } from '../Categories/categories.module';



@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    BrowserModule,
    CommonModule, 
    ShareModule,
    CategoriesModuleModule
  ],
  exports: [
    HomeComponent
  ]
  
})
export class HomeModuleModule { }
