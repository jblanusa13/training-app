import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TrainingService } from './training.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'training-app-frontend';

  constructor(public trainingService: TrainingService) {}

  ngOnInit() {
    this.getAll();
  }

  getAll(): void {
    this.trainingService.getAll().subscribe({
      next: (result) => {
        console.log(result);
      },
      error: (error) => {
        console.error(error);
      },
    });
  }
}
