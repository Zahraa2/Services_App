import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { OnboardingModuleModule } from './onboarding/onboarding.module';
import { ShareModule } from './Share/share.module';
import { HttpClientModule } from '@angular/common/http';
import { HomeModuleModule } from './Home/home.module';



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
    ShareModule,
    HttpClientModule,
    CommonModule, 
    HomeModuleModule,
    
 ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
