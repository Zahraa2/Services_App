import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
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
})
export class OnboardingModuleModule { }
