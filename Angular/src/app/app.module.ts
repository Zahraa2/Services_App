import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ShareModule } from './Share/share.module';
<<<<<<< HEAD
import { MaterialModule } from './material/material.module';
import { OnboardingModuleModule } from './onboarding/onboarding.module';
=======
>>>>>>> 6580953ab32711b8388c92f972a2ae59e0eb45e3

@NgModule({
  declarations: [
    AppComponent, 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
<<<<<<< HEAD
    ShareModule, 
    MaterialModule,
    OnboardingModuleModule
=======
    ShareModule
>>>>>>> 6580953ab32711b8388c92f972a2ae59e0eb45e3
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
