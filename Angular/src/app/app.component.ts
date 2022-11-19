import { Component } from '@angular/core';
import {TranslateService}from '@ngx-translate/core'
import { AuthService } from './Auth/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  
})
export class AppComponent {
  constructor(private TranslateService:TranslateService,private authService: AuthService){
    this.TranslateService.setDefaultLang('en');
    const lang=localStorage.getItem("lang")||'en';
    this.TranslateService.use(lang);
    document.documentElement.lang=lang;
  }
  title = 'Project';
  // constructor(private authService: AuthService){}
}
