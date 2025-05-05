using TrainingApp.Core.Model;

namespace TrainingApp.API.DTO
{
    public class CreateTrainingResponseDto
    {
        public string Id { get; set; }
        public string TypeId { get; set; }
        public double Duration { get; set; }
        public double Calories { get; set; }
        public int Difficulty { get; set; }
        public int Tiredness { get; set; }
        public string Notes { get; set; }
        public string DateTime { get; set; }


    }
}
