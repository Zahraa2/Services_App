import { Component } from '@angular/core';
import { AuthService } from './Auth/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  
})
export class AppComponent {

  title = 'Project';
  constructor(private authService: AuthService){}
}
