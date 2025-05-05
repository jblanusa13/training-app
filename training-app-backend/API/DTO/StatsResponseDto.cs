namespace TrainingApp.API.DTO
{
    public class StatsResponseDto
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int TrainingsNumber { get; set; }
        public double TrainingsDuration { get; set; }
        public double DifficultyAvg { get; set; }
        public double TirednessAvg { get; set; }
    }
}
