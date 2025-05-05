import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';
import { User } from '../model/user.model';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard {
  user: User = { id: '', email: '' };

  constructor(private authService: AuthService, private router: Router) {}

  canActivate(): boolean {
    this.authService.user$.subscribe((user) => {
      this.user = user;
    });

    if (this.user.email) {
      return true;
    } else {
      this.router.navigate(['']);
      return false;
    }
  }
}
