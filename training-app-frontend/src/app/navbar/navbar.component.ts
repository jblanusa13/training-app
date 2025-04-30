import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { User } from '../model/user.model';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [NgIf],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',
})
export class NavbarComponent {
  user: User = { email: '' };

  constructor(public router: Router, public authService: AuthService) {}

  ngOnInit(): void {
    this.authService.setUser();
    this.authService.user$.subscribe((user) => {
      this.user = user;
    });
  }

  login(): void {
    this.router.navigate(['/']);
  }

  register(): void {
    this.router.navigate(['register']);
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/']);
  }
}
