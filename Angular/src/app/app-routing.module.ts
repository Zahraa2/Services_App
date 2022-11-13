import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OnboardingComponent } from './onboarding/UI/onboarding.component';


const routes: Routes = [
  { path: '', component: OnboardingComponent},

  {path: 'خدماتنا', loadChildren: () => import('./Categories/categories.module').then(m => m.CategoriesModule)},

];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
