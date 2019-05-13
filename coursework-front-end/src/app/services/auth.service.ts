import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

import * as jwtDecode from 'jwt-decode';

import { environment } from 'src/environments/environment';

import { SignUpModel } from '../models/sign-up-model';
import { SignInModel } from '../models/sign-in-model';
import { tap } from 'rxjs/operators';
import { AuthToken } from '../models/auth-token';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private http: HttpClient,
    private router: Router
  ) { }

  public signUp(signUpModel: SignUpModel): Observable<any> {
    return this.http.post(
      `${environment.apiLink}/account/register`,
      signUpModel
    );
  }

  public signIn(signInModel: SignInModel): Observable<AuthToken> {
    return this.http.post<AuthToken>(
      `${environment.apiLink}/account/token`,
      signInModel
    ).pipe(
      tap(token => sessionStorage.setItem('jwt', token.value))
    );
  }

  public isSignedIn(): boolean {
    return !!sessionStorage.getItem('jwt');
  }

  public isAdmin(): boolean {
    let res = false;

    if (this.isSignedIn()) {
      res = (jwtDecode(sessionStorage.getItem('jwt'))
        ['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] ==
          "Admin");
    }

    return res;
  }

  public isUser(): boolean {
    let res = false;

    if (this.isSignedIn()) {
      res = (jwtDecode(sessionStorage.getItem('jwt'))
        ['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] ==
          "User");
    }

    return res;
  }

  public signOut(): void {
    sessionStorage.removeItem('jwt');
    this.router.navigate(['/']);
  }
}