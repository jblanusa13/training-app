import { Component } from '@angular/core';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { TrainingService } from '../training.service';
import { ToastrService } from 'ngx-toastr';
import { NgIf } from '@angular/common';
import { TrainingType } from '../model/training-types.model';
import { CalendarModule } from 'primeng/calendar';
import { DropdownModule } from 'primeng/dropdown';
import { User } from '../model/user.model';
import { AuthService } from '../auth/auth.service';
import { Training } from '../model/training.model';

@Component({
  selector: 'app-new-activity',
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule,
    NgIf,
    CalendarModule,
    DropdownModule,
  ],
  templateUrl: './new-activity.component.html',
  styleUrl: './new-activity.component.css',
})
export class NewActivityComponent {
  isFormValid: boolean = true;
  types: TrainingType[] = [];
  user: User = { id: '', email: '' };
  maxDate: Date | undefined;

  constructor(
    private service: TrainingService,
    private authService: AuthService,
    private router: Router,
    private toast: ToastrService
  ) {}

  activityForm = new FormGroup({
    type: new FormControl({ id: '', name: '' }, [Validators.required]),
    duration: new FormControl('', [
      Validators.pattern('^[-+]?[0-9]*\\.?[0-9]+$'),
    ]),
    calories: new FormControl('', [
      Validators.pattern('^[-+]?[0-9]*\\.?[0-9]+$'),
    ]),
    difficulty: new FormControl(),
    tiredness: new FormControl(),
    notes: new FormControl(''),
    dateTime: new FormControl('', [Validators.required]),
  });

  ngOnInit() {
    this.authService.user$.subscribe((user) => {
      this.user = user;
    });
    this.getAllTrainingTypes();
    this.maxDate = new Date();
  }

  getAllTrainingTypes() {
    this.service.getAllTypes().subscribe({
      next: (result) => {
        if (result) {
          this.types = result;
        }
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  createTraining(): void {
    if (this.activityForm.valid) {
      const trainingType = this.types.find(
        (t) => t.name == this.activityForm.value.type?.name
      );

      const rawDate = this.activityForm.value.dateTime ?? new Date();
      const localDate = new Date(rawDate);
      const utcString = localDate.toISOString();

      if (trainingType && this.user) {
        const training: Training = {
          type: trainingType,
          userId: this.user.id,
          duration: Number(this.activityForm.value.duration) || NaN,
          calories: Number(this.activityForm.value.calories) || NaN,
          difficulty: this.activityForm.value.difficulty || NaN,
          tiredness: this.activityForm.value.tiredness || NaN,
          notes: this.activityForm.value.notes || '',
          dateTime: utcString,
        };

        this.service.createTraining(training).subscribe({
          next: (result) => {
            if (result) {
              this.toast.success('Success!');
              this.router.navigate(['/welcome']);
            }
          },
          error: (error) => {
            console.log(error);
          },
        });
      }
    } else {
      this.toast.error('You must enter all fields correctly', 'Error!');
    }
  }
}
