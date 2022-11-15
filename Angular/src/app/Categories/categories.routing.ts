import { Routes, RouterModule } from '@angular/router';
import { ErrorComponent } from '../Error/Error.component';
import { AllServicesComponent } from './feature/AllServices/AllServices.component';
import { ServicesByCategoryComponent } from './feature/ServicesByCategory/ServicesByCategory.component';

const routes: Routes = [
  {
    path: '',
    component: AllServicesComponent,
    data: { animation: 'isRight' }
  },
  {
    path: 'خدماتنا/:id',
    component: ServicesByCategoryComponent
  },
  {
    path: '', redirectTo: 'خدماتنا/', pathMatch: 'full'
  },
  {
    path: '**',
     component: ErrorComponent,
    data: { animation: 'isLeft' }
  },
  
];

export const CategoriesRoutesModule = RouterModule.forChild(routes);
