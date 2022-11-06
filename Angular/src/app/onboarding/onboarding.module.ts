import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
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
})
export class OnboardingModuleModule { }
