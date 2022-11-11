import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { OnboardingModuleModule } from './onboarding/onboarding.module';
import { ShareModule } from './Share/share.module';


@NgModule({
  declarations: [
    AppComponent,
    // ShareComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    OnboardingModuleModule,
    ShareModule
 ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
