import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { of, Observable, Subject } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { config } from './../config';
import { Tokens } from '../models/tokens';
import { User } from '../models/user.model';
import { ForgotPassword } from '../_passwordModels/forgetPass';
import { ResetPasswordDto } from '../_passwordModels/resetPass';

// 🥳

export interface AuthResponseData {
  token: string;
  expirOn: string;
  refreshToken: string;
  refershTokenExpirOn: string;
  message?: string;
}

// {
//   "token": "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjczMjNhYzgwLWEyOTEtNGI5YS1iMmE2LWIzY2MyOWFjYWI2OCIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6ImN1c3RvbWVyIiwidW5pcXVlX25hbWUiOiJhaGxhbSIsImVtYWlsIjoiZ29nb0BnbWFpbC5jb20iLCJuYmYiOjE2Njg0NjIyMTIsImV4cCI6MTY2ODQ2MjI3Mn0.p4n41FZ1qcpXFqAWbgrOq9YWBfGmvgOjtNSQEsAY0ls",
//   "expirOn": "2022-11-14T23:44:32.5076945+02:00",
//   "refreshToken": "JY0P4da4U+L8V74RffIdQPc2BFUIS4khOZtuBbkSfis=",
//   "refershTokenExpirOn": "2022-11-24T18:30:18.8642512",
//   "message": null
// }

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

  // 👉 try some code  👈

  // 👉 try some code  👈

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
    return this.http.post<any>(
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

  // resfreshing the token
  refreshToken() {
    return this.http
      .post<any>(`${config.apiUrl}/refreshtoken`, {
        refreshToken: this.getRefreshToken(),
      })
      .pipe(
        tap((tokens: Tokens) => {
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

