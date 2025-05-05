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
import { ParsedStatsResponse, StatsResponse } from '../model/stats.model';
import { DatePipe, NgFor, NgIf } from '@angular/common';
import { AuthService } from '../auth/auth.service';
import { User } from '../model/user.model';

@Component({
  selector: 'app-training-progress',
  standalone: true,
  imports: [
    CalendarModule,
    FormsModule,
    ReactiveFormsModule,
    NgFor,
    NgIf,
    DatePipe,
  ],
  templateUrl: './training-progress.component.html',
  styleUrl: './training-progress.component.css',
})
export class TrainingProgressComponent {
  statsList: StatsResponse[] = [];
  user: User = { id: '', email: '' };
  noActivities: boolean = false;

  constructor(
    private service: TrainingService,
    private authService: AuthService,
    private router: Router,
    private toast: ToastrService
  ) {}

  ngOnInit() {
    this.authService.user$.subscribe((user) => {
      this.user = user;
    });
  }

  calendarForm = new FormGroup({
    month: new FormControl('', [Validators.required]),
  });

  trackProgress() {
    const rawDate = this.calendarForm.value.month ?? new Date();
    const localDate = new Date(rawDate);
    const utcString = localDate.toISOString();

    const month: Month = {
      userId: this.user.id,
      dateTime: utcString,
    };

    if (this.calendarForm.valid) {
      this.service.trackProgress(month).subscribe({
        next: (result) => {
          if (result) {
            if (result.length > 0) {
              this.statsList = result.map((stat) => ({
                ...stat,
                startDate: this.getDatePart(stat.startDate),
                endDate: this.getDatePart(stat.endDate),
              }));
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

  getDatePart(dateString: string): string {
    const date = dateString.trim().split(' ')[0];
    return date;
  }
}
