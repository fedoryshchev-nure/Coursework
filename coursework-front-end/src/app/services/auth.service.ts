import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

import * as jwtDecode from 'jwt-decode';

import { environment } from 'src/environments/environment';

import { SignUpModel } from '../models/sign-up-model';
import { SignInModel } from '../models/sign-in-model';

const headers = new HttpHeaders({
  'Content-Type': 'application/json; charset=utf-8',
});

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
      signUpModel,
      { headers: headers }
    );
  }

  public signIn(signInModel: SignInModel): Observable<string> {
    return this.http.post<string>(
      `${environment.apiLink}/account/token`,
      signInModel,
      { headers: headers }
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