import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShareModule } from '../Share/share.module';
import { InfoSectionsComponent } from './UI/info-sections/info-sections.component';
import { TestimonialComponent } from './UI/Testimonial/Testimonial.component';
import { AboutSectionsComponent } from './UI/AboutSections/AboutSections.component';
import { OnboardingComponent } from './UI/onboarding.component';
import { HeaderComponent } from './UI/Header/Header.component';

const onboardingSharedComponent = [
  InfoSectionsComponent,
  TestimonialComponent,
  AboutSectionsComponent,
  OnboardingComponent,
  HeaderComponent
]
@NgModule({
  declarations: [
    onboardingSharedComponent
  ],
  imports: [
    CommonModule,
    ShareModule,

  ],
  exports: [
    onboardingSharedComponent
  ]

})
export class OnboardingModuleModule { }
