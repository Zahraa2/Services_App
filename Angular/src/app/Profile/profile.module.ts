import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from '../Auth/token.interceptor';
import { TestComponent } from './test/test.component';

@NgModule({
  declarations: [
    TestComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    }
  ],
  exports: [
    TestComponent
  ]
})
export class ProfileModule { }
