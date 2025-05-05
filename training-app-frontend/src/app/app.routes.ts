import { Routes } from '@angular/router';
import { RegistrationComponent } from './auth/registration/registration.component';
import { LoginComponent } from './auth/login/login.component';
import { NewActivityComponent } from './new-activity/new-activity.component';
import { TrainingProgressComponent } from './training-progress/training-progress.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { AuthGuard } from './auth/auth.guard';

export const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'register', component: RegistrationComponent },
  { path: 'new', component: NewActivityComponent, canActivate: [AuthGuard] },
  {
    path: 'progress',
    component: TrainingProgressComponent,
    canActivate: [AuthGuard],
  },
  { path: 'welcome', component: WelcomeComponent },
];
