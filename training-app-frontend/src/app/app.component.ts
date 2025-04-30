import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TrainingService } from './training.service';
import { ToastrModule } from 'ngx-toastr';
import { NavbarComponent } from './navbar/navbar.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavbarComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'training-app-frontend';

  constructor() {}
}
