import { Component } from '@angular/core';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { Router } from '@angular/router';
import { TrainingService } from '../../training.service';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../auth.service';
import { LoginUser } from '../../model/user.model';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  constructor(
    private service: AuthService,
    private router: Router,
    private toast: ToastrService
  ) {}

  userForm = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });

  login(): void {
    const login: LoginUser = {
      email: this.userForm.value.email || '',
      password: this.userForm.value.password || '',
    };

    this.service.login(login).subscribe({
      next: (result) => {
        this.toast.success('Success!');
        if (result.accessToken) {
          this.router.navigate(['/welcome']);
        }
      },
      error: (error) => {
        this.toast.error(error, 'Error!');
      },
    });
  }
}
