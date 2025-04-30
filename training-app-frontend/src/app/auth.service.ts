import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {
  LoginUser,
  LoginUserResponse,
  RegistrationUser,
  RegistrationUserResponse,
  User,
} from './model/user.model';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { environment } from '../env/environment';
import { TokenService } from './token.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  user$ = new BehaviorSubject<User>({
    email: '',
  });

  jwtHelperService = new JwtHelperService();

  constructor(private http: HttpClient, private tokenService: TokenService) {}

  register(
    registration: RegistrationUser
  ): Observable<RegistrationUserResponse> {
    return this.http.post<RegistrationUserResponse>(
      environment.apiURL + '/user',
      registration
    );
  }

  login(login: LoginUser): Observable<LoginUserResponse> {
    return this.http
      .post<LoginUserResponse>(environment.apiURL + '/user/login', login)
      .pipe(
        tap((loginResponse) => {
          this.tokenService.saveAccessToken(loginResponse.accessToken);
          this.setUser();
        })
      );
  }

  setUser(): void {
    const accessToken = this.tokenService.getAccessToken() || '';
    const user: User = {
      email: this.jwtHelperService.decodeToken(accessToken).sub,
    };

    this.user$.next(user);
  }

  logout(): void {
    this.tokenService.clear();
    this.user$.next({ email: '' });
  }
}
