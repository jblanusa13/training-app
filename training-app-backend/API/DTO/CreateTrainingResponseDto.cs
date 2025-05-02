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

        public CreateTrainingResponseDto(string id, string typeId, double duration, double calories, int difficulty, int tiredness, string notes, string dateTime)
        {
            Id = id;
            TypeId = typeId;
            Duration = duration;
            Calories = calories;
            Difficulty = difficulty;
            Tiredness = tiredness;
            Notes = notes;
            DateTime = dateTime;
        }
    }
}
