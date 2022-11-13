import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AllCategoriesComponent } from './feature/AllCategories/AllCategories.component';
import { CategoriesComponent } from './UI/Categories.component';
import { MaterialModule } from '../material/material.module';
import { NgxPaginationModule } from 'ngx-pagination'
import { ServicesByCategoryComponent } from './feature/ServicesByCategory/ServicesByCategory.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { FormsModule } from '@angular/forms';
import { AllServicesComponent } from './feature/AllServices/AllServices.component';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { MostPopularComponent } from './feature/MostPopular/MostPopular.component';
import { ShareModule } from '../Share/share.module';
import { CategoriesRoutesModule } from './categories.routing.module';



const importedComponent = [
  AllCategoriesComponent,
  CategoriesComponent,
  ServicesByCategoryComponent,
  AllServicesComponent,
  MostPopularComponent,

]


@NgModule({
  declarations: [
    importedComponent
  ],
  imports: [
    MaterialModule,
    NgxPaginationModule,
    Ng2SearchPipeModule,
    FormsModule,
    CarouselModule,
    CommonModule,
    // ShareModule,
    CategoriesRoutesModule
  ],
  exports: [
    CategoriesComponent
  ]
})
export class CategoriesModule { }
