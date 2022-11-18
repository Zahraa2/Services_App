import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { config } from './../config';
import { Tokens } from '../models/tokens';
import { User } from '../models/user.model';
import { ForgotPassword } from '../_passwordModels/forgetPass';
import { ResetPasswordDto } from '../_passwordModels/resetPass';
import {AuthResponseData} from "../models/AuthResponseData"


@Injectable({
  providedIn: 'root',
})

export class AuthService {
  private readonly JWT_TOKEN = 'JWT_TOKEN';
  private readonly REFRESH_TOKEN = 'REFRESH_TOKEN';
  loggedUser: any;
  islogged: boolean = false;
  constructor(private http: HttpClient) {}

  userSub = new Subject<User>();


  //Register as user => return observable 😥
  signup(user: {
    fname: string;
    lname: string;
    userName: string;
    email: string;
    phoneNumber: string;
    city: string;
    password: string;
  }) {
    return this.http.post<AuthResponseData>(
      `${config.apiUrl}/customer-register`,
      user
    )
    .pipe(
      tap((response) => {
        const user = new User(
          response.token,
          response.expirOn,
          response.refreshToken,
          response.refershTokenExpirOn,
          response.message
        );
        this.userSub.next(user);
      })
    );
  }

  //Register as user => return observable 😥
  signupProvider(user: {
    fname: string;
    lname: string;
    userName: string;
    email: string;
    phoneNumber: string;
    city: string;
    password: string;
    serviceId:string; 
    sammary:string
  }) {
    return this.http.post<AuthResponseData>(
      `${config.apiUrl}/Provider-register`,
      user
    )
    .pipe(
      tap((response) => {
        const user = new User(
          response.token,
          response.expirOn,
          response.refreshToken,
          response.refershTokenExpirOn,
          response.message
        );
        this.userSub.next(user);
      })
    );
  }
  // login 😥
  login(user: { username: string; password: string }) {
    return this.http
      .post<AuthResponseData>(`${config.apiUrl}/Login`, user)
      .pipe(
        tap((response) => {
          const user = new User(
            response.token,
            response.expirOn,
            response.refreshToken,
            response.refershTokenExpirOn,
            response.message
          );
          this.userSub.next(user);
        })
      );
  }

  // Logout 😥
  logout() {
    return this.http.get<any>(`${config.apiUrl}/Logout`);
  }

  //resfreshing the token
  refreshToken() {
    return this.http
      .post<any>(`${config.apiUrl}/refreshtoken`,this.getRefreshToken())
      .pipe(
        tap((tokens: Tokens) => {
          console.log(tokens.jwt);
          this.storeJwtToken(tokens.jwt);
        })
      );
  }

  // log in | register actions => store tokens in local storage
  doLoginUser(username: string, tokens: Tokens) {
    this.loggedUser = username;
    this.storeTokens(tokens);
  }

  // storing token in local storage
  storeTokens(tokens: Tokens) {
    localStorage.setItem(this.JWT_TOKEN, tokens.jwt);
    localStorage.setItem(this.REFRESH_TOKEN, tokens.refreshToken);
  }

  // get jwt
  getJwtToken(): any {
    return localStorage.getItem(this.JWT_TOKEN);
  }

  // check logging
  isLoggedIn() {
    // null => !true => false => [not to return null]
    return !!this.getJwtToken();
  }

  // log out actions => remove the token from local storage
  doLogoutUser() {
    this.loggedUser = '';
    this.removeTokens();
  }

  // remove token from local storage
  removeTokens() {
    localStorage.removeItem(this.JWT_TOKEN);
    localStorage.removeItem(this.REFRESH_TOKEN);
  }

  // get refresh token
  getRefreshToken() {
    return localStorage.getItem(this.REFRESH_TOKEN);
  }

  // store token
  storeJwtToken(jwt: string) {
    localStorage.setItem(this.JWT_TOKEN, jwt);
  }

  // 👉 Handling Passwords => (Forget && Reset) 👈
  // ============== Forget ==============

  forgotPassword = (body: ForgotPassword) => {
    return this.http.post<any>(`${config.apiUrl}/forgerPassword`, body);
  }
  
  // ============== Reset ==============

  resetPassword = (body: ResetPasswordDto) => {
    return this.http.post<any>(`${config.apiUrl}/resetPassword`, body);
  }


  // 👉 Getting services to select 👈

  getAllServices(){
    return this.http.get<any>(`https://localhost:7142/api/Services`);
  }
}

