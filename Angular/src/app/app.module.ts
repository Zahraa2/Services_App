import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ShareModule } from './Share/share.module';
import { HttpClientModule , HttpClient } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { OnboardingModule} from './onboarding/onboarding.module';

import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { SettingModule } from './setting/setting.module';
import { ServicesProvidersModule } from './services-providers/services-providers.module';
import { AuthModule } from './Auth/auth.module';
// AoT requires an exported function for factories
export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}

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
    SettingModule,
    HttpClientModule,
    AuthModule,
    ServicesProvidersModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient],
      },
    }),

 ],exports:[TranslateModule],
  providers: [HttpClient],
 
  bootstrap: [AppComponent]
})
export class AppModule { }
