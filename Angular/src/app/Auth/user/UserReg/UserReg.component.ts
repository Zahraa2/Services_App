import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-UserReg',
  templateUrl: './UserReg.component.html',
  styleUrls: ['./UserReg.component.css'],
})
export class UserRegComponent implements OnInit {
  //password hidden by default
  hide = true;
  errorMessage: any = null;
  isLoading = false;

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit() {}

  // form validation inputs
  registerForm: FormGroup = new FormGroup({
    fname: new FormControl('', [Validators.required]),
    lname: new FormControl('', [Validators.required]),
    userName: new FormControl('', [Validators.required]),
    email: new FormControl('', [
      Validators.required,
      Validators.pattern('[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,3}$'),
    ]),

    phoneNumber: new FormControl('', [
      Validators.required,
      Validators.pattern('^01[0-2,5]{1}[0-9]{8}$'),
    ]),
    password: new FormControl(
      '',
      Validators.compose([
        Validators.minLength(5),
        Validators.required,
        Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])[a-zA-Z0-9]+$'), //this is for the letters (both uppercase and lowercase) and numbers validation
      ])
    ),
    city: new FormControl('', [Validators.required]),
  });

  // registeration function
  onRegister() {
    // if the form is valid , do so ...
    if (this.registerForm.valid) {
      this.isLoading = true;
      this.authService.signup(this.registerForm.value).subscribe({
        next: (resData) => {
          // store tokens (jwt, refresh)
          this.authService.doLoginUser(this.registerForm.value.username, {
            jwt: resData.token,
            refreshToken: resData.refreshToken,
          });
          this.router.navigate(['Categories']);
          // console.log(this.authService.getJwtToken());
          this.authService.islogged = true;
          this.isLoading = false;
        },
        error: (err) => {
          // console.log(err.error);
          this.errorMessage = err.error;
          this.isLoading = false;
        },
        complete: () => {
          // console.log('completed');
          // this.registerForm.reset();
          this.isLoading = false;
        },
      });
    } else {
      console.log('invalid');
    }
  }
}
