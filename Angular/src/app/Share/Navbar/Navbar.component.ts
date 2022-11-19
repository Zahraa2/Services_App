import { Component, OnInit, Input, OnChanges, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from '../../Auth/services/auth.service';

// NavBar Toggeler

@Component({
  selector: 'app-Navbar',
  templateUrl: './Navbar.component.html',
  styleUrls: ['./Navbar.component.css'],
})
export class NavbarComponent implements OnInit {
  usersub!: Subscription;
  isAuthenticated = false;
  language: string = 'العربية';
  seconedLanguage: string = 'الإنجليزية';
  toggleArabic: boolean = true;
  toggle: boolean = false;

  constructor(private authService: AuthService, private router: Router) {
  
    //🤝 handle isAuthenticated when refreshing the page 🤝 
    this.isAuthenticated = this.authService.isLoggedIn();
  }

  ngOnInit() {
    this.usersub = this.authService.userSub.subscribe((user) => {
      this.isAuthenticated = !!user;
    });
  }


  handleToggle() {
    this.toggle = !this.toggle;
  }

  handleToggleLang() {
    this.toggleArabic = !this.toggleArabic;
    if (this.toggleArabic) {
      this.language = 'العربية';
      this.seconedLanguage = 'الإنجليزية';
    } else {
      this.seconedLanguage = 'العربية';
      this.language = 'الإنجليزية';
    }
  }

  // loggging out
  logout() {
    this.authService.logout().subscribe({
      next: () => {
        // remove tokens (jwt, refresh)
        this.authService.doLogoutUser();
        this.isAuthenticated = false;
        this.router.navigate(['Categories'])
      }
    });
  }
  // Notifcations Part
  openNotifications(){
    this.router.navigateByUrl("Request/all-Request");
  }

}
