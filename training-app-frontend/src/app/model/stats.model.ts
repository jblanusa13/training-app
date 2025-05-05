export interface StatsResponse {
  startDate: string;
  endDate: string;
  trainingsNumber: number;
  trainingsDuration: number;
  difficultyAvg: number;
  tirednessAvg: number;
}

export interface ParsedStatsResponse
  extends Omit<StatsResponse, 'startDate' | 'endDate'> {
  startDate: Date;
  endDate: Date;
}
