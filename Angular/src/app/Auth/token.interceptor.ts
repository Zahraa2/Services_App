import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
} from '@angular/common/http';
import { AuthService } from './services/auth.service';
import { Observable, throwError, BehaviorSubject } from 'rxjs';
import { catchError, filter, take, switchMap } from 'rxjs/operators';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  //  👉 Attatching the token with the request 👈
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    req = req.clone({
      setHeaders: {
        'Content-Type': 'application/json; charset=utf-8',
        Accept: 'application/json',
        Authorization: `Bearer ${this.authService.getJwtToken()}`,
      },
    });
    return next.handle(req);
  }
  constructor(public authService: AuthService) {}
   
  // intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
  //   req = req.clone({
  //     setHeaders: {
  //       'Content-Type': 'application/json; charset=utf-8',
  //       Accept: 'application/json',
  //       Authorization: `Bearer ${this.authService.getJwtToken()}`,
  //     },
  //   });
  //   return next.handle(req).pipe(
  //     catchError((error) => {
  //       if (
  //         error instanceof HttpErrorResponse &&
  //         !req.url.includes('Auth/login') &&
  //         error.status === 401
  //       ) {
  //         return this.handle401Error(req, next);
  //       }
  //       return throwError(() => error);
  //     })
  //   );
  // }
  // private handle401Error(request: HttpRequest<any>, next: HttpHandler) {
  //   if (!this.isRefreshing) {
  //     this.isRefreshing = true;
  //     if (this.authService.isLoggedIn()) {
  //       return this.authService.refreshToken().pipe(
  //         switchMap(() => {
  //           this.isRefreshing = false;
  //           return next.handle(request);
  //         }),
  //         catchError((error) => {
  //           this.isRefreshing = false;
  //           if (error.status == '403') {
  //             console.log('error');
              
  //           }
  //           return throwError(() => error);
  //         })
  //       );
  //     }
  //   }
}



