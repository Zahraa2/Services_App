import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-UserLogin',
  templateUrl: './UserLogin.component.html',
  styleUrls: ['./UserLogin.component.css'],
})
export class UserLoginComponent implements OnInit {
  //password hidden by default
  hide = true;
  errorMessage: any = null;
  isLoading = false;

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit() {}

  // form validation inputs
  loginform: FormGroup = new FormGroup({
    userName: new FormControl('', [Validators.required]),

    password: new FormControl(
      '',
      Validators.compose([
        Validators.minLength(5),
        Validators.required,
        Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])[a-zA-Z0-9]+$'), //this is for the letters (both uppercase and lowercase) and numbers validation
      ])
    ),
  });

  // login function
  onlogin() {
    // if the form is valid , do so ...
    if (this.loginform.valid) {
      this.isLoading = true;
      this.authService.login(this.loginform.value).subscribe({
        next: (resData) => {
          // store tokens (jwt, refresh)
          // 👉 ** store user model instead .... ** 👈
          this.authService.doLoginUser(this.loginform.value.username, {
            jwt: resData.token,
            refreshToken: resData.refreshToken,
          });
          this.router.navigate(['خدماتنا']);
          // console.log(this.authService.getJwtToken());
          // console.log(resData);
          this.isLoading = false;
          this.authService.islogged = true;
        },
        error: (err) => {
          // console.log(err.error);
          this.errorMessage = err.error;
          this.isLoading = false;
        },
        complete: () => {
          // console.log('completed');
          // this.loginform.reset();
          this.isLoading = false;
        },
      });
    } else {
      console.log('invalid');
    }
  }


  // forgetPassword 
  forgetPass(){
    this.router.navigate(['forgetPassword']);
  }
}
