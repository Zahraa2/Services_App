import { NgModule} from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { SwiperModule } from 'swiper/angular';
import { HttpClientModule } from '@angular/common/http'; 
import { MostPopularComponent } from './MostPopular/MostPopular.component';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    MostPopularComponent
  ],
  imports: [
    SwiperModule,
    HttpClientModule,
    BrowserModule,
    CommonModule, 
    CarouselModule,
    BrowserAnimationsModule
  ],
  exports: [
    MostPopularComponent
  ]
  
})
export class HomeModuleModule { }
