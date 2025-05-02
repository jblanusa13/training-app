using TrainingApp.Core.Model;

namespace TrainingApp.API.DTO
{
    public class CreateTrainingDto
    {
        public TrainingType Type { get; set; }
        public string UserId { get; set; }
        public double Duration { get; set; }
        public double Calories { get; set; }
        public int Difficulty { get; set; }
        public int Tiredness { get; set; }
        public string Notes { get; set; }
        public string DateTime { get; set; }
    }
}
