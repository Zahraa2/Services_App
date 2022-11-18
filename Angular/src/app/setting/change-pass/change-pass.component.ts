import { Component, OnInit } from '@angular/core';

import {
  FormGroup,
  FormControl,
  FormBuilder,
  Validators,
} from '@angular/forms';
@Component({
  selector: 'app-change-pass',
  templateUrl: './change-pass.component.html',
  styleUrls: ['./change-pass.component.css'],
})
export class ChangePassComponent implements OnInit {
  constructor(public formBuilder: FormBuilder) {}
  settingForm = this.formBuilder.group(
    {
      Newpassword: new FormControl(
        '',
        Validators.compose([
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(30),
        ])
      ),
      Confirmpassword: new FormControl(
        '',
        Validators.compose([
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(30),
        ])
      ),
    },
    {
      validators: this.checkPassword.bind(this),
    }
  );

  error_messages = {
    password: [
      { type: 'required', message: 'password is required.' },
      { type: 'minlength', message: 'password length too small.' },
      { type: 'maxlength', message: 'password length. too large' },
    ],
    confirmpassword: [
      { type: 'required', message: 'password is required . ' },
      { type: 'minlength', message: 'password length too small .' },
      { type: 'maxlength', message: 'password length too large .' },
    ],
  };

confirmPasswordError:any 

  checkPassword(formGroup: FormGroup) {
    const  password = formGroup.get('Newpassword')?.value;
    const  Confirmpassword = formGroup.get('Confirmpassword')?.value;
    return password === Confirmpassword ? this.confirmPasswordError=null : this.confirmPasswordError="| Password Not matched";
  }

  ngOnInit(): void {}
}
