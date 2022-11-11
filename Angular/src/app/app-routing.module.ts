import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ErrorComponent } from './Error/Error.component';
import { MostPopularComponent } from './Home/MostPopular/MostPopular.component';
import { OnboardingComponent } from './onboarding/UI/onboarding.component';

const routes: Routes = [
  {path: '' , component:OnboardingComponent}, 
  {path:'خدماتنا' , component:MostPopularComponent},
  {path:'**' , component:ErrorComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
