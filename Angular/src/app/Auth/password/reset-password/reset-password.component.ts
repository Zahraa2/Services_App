import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { ForgotPassword } from '../../_passwordModels/forgetPass';
import { ResetPasswordDto } from '../../_passwordModels/resetPass';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css'],
})
export class ResetPasswordComponent implements OnInit {
  hide = true;
  errorMessage: any;
  successMessage: any;
  isLoading = false;

  token: any;
  email: any;

  constructor(
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    // 👉 getting token && email from email link route 👈
    this.token = this.route.snapshot.queryParams['token'];
    this.email = this.route.snapshot.queryParams['email'];
  }

  // form validation inputs
  resetPassForm: FormGroup = new FormGroup({
    password: new FormControl(
      '',
      Validators.compose([
        Validators.minLength(7),
        Validators.required,
        Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])[a-zA-Z0-9]+$'), //this is for the letters (both uppercase and lowercase) and numbers validation
      ])
    ),
  });

  onResetPassword() {
    if (this.resetPassForm.valid) {
      this.isLoading = true;
      // 🤝 body data 🤝
      const resetPassDto: ResetPasswordDto = {
        email: this.email,
        token: this.token,
        password: this.resetPassForm.value.password,
        confirmPassword: this.resetPassForm.value.password
      };
      this.authService.resetPassword(resetPassDto).subscribe({
        next: (_) => {
          this.isLoading = false;
          this.successMessage =
            'your password has been reset successfully';
            console.log(resetPassDto);
            
        },
        error: (err) => {
          this.errorMessage = 'An error has just occurred. Please try again';
          this.isLoading = false;
        },
        complete: () => {
          this.isLoading = false;
        },
      });
    } else {
      console.log('invalid');
    }
  }

  LoginRedirect() {
    this.router.navigate(['login'])
  }
}
