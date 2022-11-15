import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OnboardingComponent } from './onboarding/UI/onboarding.component';


const routes: Routes = [
  { path: '', component: OnboardingComponent},

  {path: 'خدماتنا', loadChildren: () => import('./Categories/categories.module').then(m => m.CategoriesModule)},
  {path: 'Profile', loadChildren: () => import('./Profile/profile.module').then(m => m.ProfileModule)},

];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
