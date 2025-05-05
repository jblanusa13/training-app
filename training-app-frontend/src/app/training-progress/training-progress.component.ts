import { Component } from '@angular/core';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { TrainingService } from '../training.service';
import { CalendarModule } from 'primeng/calendar';
import { Month } from '../model/month.model';
import { StatsResponse } from '../model/stats.model';
import { NgFor, NgIf } from '@angular/common';

@Component({
  selector: 'app-training-progress',
  standalone: true,
  imports: [CalendarModule, FormsModule, ReactiveFormsModule, NgFor, NgIf],
  templateUrl: './training-progress.component.html',
  styleUrl: './training-progress.component.css',
})
export class TrainingProgressComponent {
  statsList: StatsResponse[] = [];
  noActivities: boolean = false;

  constructor(
    private service: TrainingService,
    private router: Router,
    private toast: ToastrService
  ) {}

  calendarForm = new FormGroup({
    month: new FormControl('', [Validators.required]),
  });

  trackProgress() {
    const rawDate = this.calendarForm.value.month ?? new Date();
    const localDate = new Date(rawDate);
    const utcString = localDate.toISOString();

    console.log('MNTH: ', utcString);
    const month: Month = {
      dateTime: utcString,
    };

    if (this.calendarForm.valid) {
      this.service.trackProgress(month).subscribe({
        next: (result) => {
          if (result) {
            console.log('STATS: ', result);
            if (result.length > 0) {
              this.statsList = result;
              this.noActivities = false;
            } else {
              this.statsList = [];
              this.noActivities = true;
            }
          }
        },
        error: (error) => {
          console.log(error);
        },
      });
    }
  }
}
