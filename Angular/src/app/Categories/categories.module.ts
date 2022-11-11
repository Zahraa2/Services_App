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
import { ErrorComponent } from '../Error/Error.component';
import { CategoriesRoutesModule } from './categories.routing'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

const importedComponent = [
  AllCategoriesComponent,
  CategoriesComponent,
  ServicesByCategoryComponent,
  AllServicesComponent,
  ErrorComponent
]


@NgModule({
  declarations: [
    importedComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    NgxPaginationModule,
    BrowserAnimationsModule,
    Ng2SearchPipeModule,
    FormsModule,
    CategoriesRoutesModule
  ],
  exports: [
    CategoriesComponent
  ]
})
export class CategoriesModuleModule { }
