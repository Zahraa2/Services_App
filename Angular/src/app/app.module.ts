import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ShareModule } from './Share/share.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { OnboardingModule} from './onboarding/onboarding.module';
import { AuthModule } from './Auth/auth.module';
import { CommonModule } from '@angular/common';
import { ProfileModule } from './Profile/profile.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    RouterModule,   
    ShareModule,
    OnboardingModule,
    AuthModule,
    CommonModule,
    ProfileModule
 ],
  bootstrap: [AppComponent]
})
export class AppModule { }
