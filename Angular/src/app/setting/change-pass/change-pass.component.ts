import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

import {
  FormGroup,
  FormControl,
  FormBuilder,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { Role } from 'src/app/Auth/models/Role';
import { AuthService } from 'src/app/Auth/services/auth.service';
@Component({
  selector: 'app-change-pass',
  templateUrl: './change-pass.component.html',
  styleUrls: ['./change-pass.component.css'],
})
export class ChangePassComponent implements OnInit {

  notConfirmed:boolean = true ; 

  constructor(public formBuilder: FormBuilder, public router: Router,private http: HttpClient, private authService: AuthService) {}
  settingForm = this.formBuilder.group(
    {
      Currentpassword:new FormControl ([
        '', Validators.compose([
          Validators.required, Validators.minLength(5),
          Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])[a-zA-Z0-9]+$'),
        ])
      ]),
      Newpassword: new FormControl(
        '',
        Validators.compose([
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(30),
          Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])[a-zA-Z0-9]+$'),
        ])
      ),
      Confirmpassword: new FormControl(
        '',
        Validators.compose([
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(30),
          Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])[a-zA-Z0-9]+$'),
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

  
  checkPassword(formGroup: FormGroup) {
    const  password = formGroup.get('Newpassword')?.value;
    const  Confirmpassword = formGroup.get('Confirmpassword')?.value;
    return password === Confirmpassword ? this.confirmPasswordError=null : this.confirmPasswordError="| Password Not matched";
  }
   
  userdata :any
  id : any
  type: any

  ngOnInit(): void {
    this.http.get('https://localhost:7142/api/Auth/GetLoggedInUser')
    .subscribe(resData => {
      this.userdata = resData;
      this.id = this.userdata.id; 
      this.type = this.userdata.type; 
    });
    // console.log(this.settingForm.get("Currentpassword")?.value);
    this.settingForm.controls['Currentpassword'].setValue("")
  }
 
  // Confirming Password 
  // 👉 this.settingForm.get("Currentpassword")?.value => currentpassword 
  // id , type , password
  confirmPasswordError:any 
  confirmPass(){
    // handling confirm pass logic here => true | false
    return this.http.post("https://localhost:7142/api/Auth/isPasswordCorrect", { 
      id : this.id, 
      type : this.type, 
      password:this.settingForm.get("Currentpassword")?.value
    }).subscribe(
      response => {
        this.notConfirmed = !response
      }
    )
  }

  changePass(){
    return this.http.post("https://localhost:7142/api/Auth/ChangePassword", { 
      id : this.id, 
      type : this.type, 
      oldPassword:this.settingForm.get("Currentpassword")?.value,
      newPassword:this.settingForm.get("Newpassword")?.value,
      confirmPassword:this.settingForm.get("Confirmpassword")?.value
    }).subscribe(
      response => {
        this.authService.removeTokens();
        this.router.navigate(['login']);
      }
    )  }


}
