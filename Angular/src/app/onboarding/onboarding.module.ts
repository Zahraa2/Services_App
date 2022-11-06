import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TestimonialComponent } from './Testimonial/Testimonial.component';



@NgModule({
  declarations: [TestimonialComponent],
  imports: [
    CommonModule 
  ] , 
  exports:[
    TestimonialComponent
  ]
})
export class OnboardingModuleModule { }
