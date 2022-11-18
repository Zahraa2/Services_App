import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { AuthService } from "../services/auth.service";

	
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router) { }

  // if the user is authenticated => navigate to the profile page 
  canActivate() {
    if (this.authService.isLoggedIn()) {
      this.router.navigate(['profile']);
    }
    // activate the register | login page if the user is not logged in
    return !this.authService.isLoggedIn();
  }
}