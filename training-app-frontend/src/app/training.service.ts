import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../env/environment';
import { RegistrationUser, RegistrationUserResponse } from './model/user.model';
import { TrainingType } from './model/training-types.model';
import { Training, TrainingResponse } from './model/training.model';
import { Month } from './model/month.model';
import { StatsResponse } from './model/stats.model';

@Injectable({
  providedIn: 'root',
})
export class TrainingService {
  constructor(private http: HttpClient) {}

  getAllTypes(): Observable<TrainingType[]> {
    return this.http.get<TrainingType[]>(environment.apiURL + '/trainingType');
  }

  createTraining(training: Training): Observable<TrainingResponse> {
    return this.http.post<TrainingResponse>(
      environment.apiURL + '/training',
      training
    );
  }

  trackProgress(month: Month): Observable<StatsResponse[]> {
    return this.http.put<StatsResponse[]>(
      environment.apiURL + '/training/progress',
      month
    );
  }
}
