import { Routes } from '@angular/router';
import { RegistrationComponent } from './auth/registration/registration.component';
import { LoginComponent } from './auth/login/login.component';
import { NewActivityComponent } from './new-activity/new-activity.component';

export const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'register', component: RegistrationComponent },
  { path: 'new', component: NewActivityComponent },
];
