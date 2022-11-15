import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ShareModule } from './Share/share.module';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { OnboardingModule} from './onboarding/onboarding.module';


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
 ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
