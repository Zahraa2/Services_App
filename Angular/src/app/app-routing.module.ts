import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OnboardingComponent } from './onboarding/UI/onboarding.component';
import { HomeComponent } from './Home/UI/Home/Home.component';
import { ServicesByCategoryComponent } from './Categories/feature/ServicesByCategory/ServicesByCategory.component';
import { AllServicesComponent } from './Categories/feature/AllServices/AllServices.component';


const routes: Routes = [
  {path: '' , component:OnboardingComponent}, 
  {path:'خدماتنا' , component:HomeComponent ,children:[
    {path:'' , component:AllServicesComponent},
    {path:':id' , component:ServicesByCategoryComponent},
    {path:'عمال:id' , component:ServicesByCategoryComponent}
  ]},
  // {path:'**' , component:ErrorComponent}
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
