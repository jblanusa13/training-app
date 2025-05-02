import { TrainingType } from './training-types.model';

export interface Training {
  type: TrainingType;
  userId: string;
  duration: number;
  calories: number;
  difficulty: number;
  tiredness: number;
  notes: string;
  dateTime: string;
}

export interface TrainingResponse {
  id: string;
  typeId: string;
  duration: number;
  calories: number;
  difficulty: number;
  tiredness: number;
  notes: string;
  dateTime: string;
}
