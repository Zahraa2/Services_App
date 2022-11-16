import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ErrorComponent } from '../Error/Error.component';
import { AllServicesComponent } from './feature/AllServices/AllServices.component';
import { ServicesByCategoryComponent } from './feature/ServicesByCategory/ServicesByCategory.component';
import { CategoriesComponent } from './UI/Categories.component';

const routes: Routes = [
  {
    path: '',
    component: CategoriesComponent ,
    children:[
      {
        path:'' , component : AllServicesComponent
      },
      {
        path:'all' , component : AllServicesComponent
      },
      {
        path:':id' , component: ServicesByCategoryComponent
      },
      {path:"**" , component: ErrorComponent}
    ]
  }
 
  ];



@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoriesRoutesModule { }
