import { NgIf } from '@angular/common';
import { Component, Injectable } from '@angular/core';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { TrainingService } from '../../training.service';
import { Router } from '@angular/router';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { RegistrationUser } from '../../model/user.model';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, NgIf, ToastrModule],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css',
})
export class RegistrationComponent {
  isFormValid: boolean = true;

  constructor(
    private service: AuthService,
    private router: Router,
    private toast: ToastrService
  ) {}

  userForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    lastName: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required]),
    rePassword: new FormControl('', [Validators.required]),
  });

  register(): void {
    if (this.userForm.value.password !== this.userForm.value.rePassword) {
      this.toast.error(
        'Passwords do not match! Please make sure both passwords are identical',
        'Error!'
      );
      return;
    }

    const registration: RegistrationUser = {
      name: this.userForm.value.name || '',
      lastName: this.userForm.value.lastName || '',
      email: this.userForm.value.email || '',
      password: this.userForm.value.password || '',
    };

    if (this.userForm.valid) {
      this.service.register(registration).subscribe({
        next: (result) => {
          this.toast.success('Success!');
          if (result.id) {
            this.router.navigate(['']);
          }
        },
        error: (error) => {
          console.log(error);
        },
      });
    } else {
      this.isFormValid = false;
    }
  }
}
