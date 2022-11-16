import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { ForgotPassword } from '../../_passwordModels/forgetPass';

@Component({
  selector: 'app-forget-password',
  templateUrl: './forget-password.component.html',
  styleUrls: ['./forget-password.component.css'],
})
export class ForgetPasswordComponent implements OnInit {
  errorMessage: any 
  successMessage: string = '';
  isLoading = false;

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit() {}

  // form validation inputs
  forgetPassForm: FormGroup = new FormGroup({
    email: new FormControl('', [
      Validators.required,
      Validators.pattern('[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,3}$'),
    ]),
  });

  onForgetPass() {
    if (this.forgetPassForm.valid) {
      this.isLoading = true;
      // 🤝 body data 🤝
      const forgotPassDto: ForgotPassword = {
        email: this.forgetPassForm.value.email,
        url: 'http://localhost:4200/resetpassword',
      };
      this.authService.forgotPassword(forgotPassDto).subscribe({
        next: (_) => {
          this.isLoading = false;
          this.successMessage =
            'The link has been sent, please check your email to reset your password.';
        },
        error: (err) => {
          this.errorMessage = err.error;
          this.isLoading = false;
        },
        complete: () => {
          this.isLoading = false;
        }
      });
    } else {
      console.log('invalid');
    }
    
  }
}
