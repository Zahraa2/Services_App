import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
<<<<<<< HEAD
import { OnboardingComponent } from './UI/onboarding.component';
import { ShareModule } from '../Share/share.module';



@NgModule({
  declarations: [
    OnboardingComponent
  ],
  imports: [
    CommonModule , ShareModule
  ],
  exports:[OnboardingComponent]
=======
import { InfoSectionsComponent } from './info-sections/info-sections.component';
import { TestimonialComponent } from './Testimonial/Testimonial.component';
import { ShareModule } from '../Share/share.module';
const onboardingSharedComponent=[
  InfoSectionsComponent,TestimonialComponent
]
@NgModule({
  declarations: [
    onboardingSharedComponent
  ],
  imports: [
    CommonModule,
    ShareModule
  ],
  exports:[
    onboardingSharedComponent
  ]
>>>>>>> 964d6a2ec9f342ce88496c8aa304ad867f524fa0
})
export class OnboardingModuleModule { }
