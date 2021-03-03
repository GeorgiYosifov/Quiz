import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, map } from 'rxjs/operators'

import { environment } from 'src/environments/environment';
import { IUserLoginRequest } from '../models/identity/user-login-request';

@Injectable()
export class IdentityService {
  private API_URL = environment.API_URL;
  private readonly loginUrl = this.API_URL + '/identity/login';

  constructor(private http: HttpClient,
    private router: Router) { }

  public login(body: IUserLoginRequest) {
    this.http.post(this.loginUrl, body).pipe(
      map(val => {
        console.log(val['text'])
        localStorage.setItem('userId', val['id'])
        localStorage.setItem('username', val['username'])
        this.router.navigate(['quiz'])
      }),
      catchError(err => { 
        console.log(err.error['text'])
        throw new Error(err.error)
      })
    ).subscribe();
  }

  public logout() {
    localStorage.clear();
    this.router.navigate([ '/login' ]);
  }

  public isAuthenticated(): Boolean {
    return this.getUserId() != null;
  }

  private getUserId(): string {
    return localStorage.getItem('userId');
  }
}
