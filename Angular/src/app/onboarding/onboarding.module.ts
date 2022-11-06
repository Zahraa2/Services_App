import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InfoSectionsComponent } from './info-sections/info-sections.component';



@NgModule({
  declarations: [
    InfoSectionsComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[InfoSectionsComponent]
})
export class OnboardingModuleModule { }
