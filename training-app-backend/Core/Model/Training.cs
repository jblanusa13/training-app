using System.Xml.Linq;

namespace TrainingApp.Core.Model
{
    public class Training
    {
        public Guid Id { get; set; }
        public Guid TypeId { get; set; }
        public TrainingType Type { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public double Duration { get; set; }
        public double Calories { get; set; }
        public int Difficulty { get; set; }
        public int Tiredness { get; set; }
        public string Notes { get; set; }
        public DateTime DateTime { get; set; }

        public Training(Guid typeId,Guid userId, double duration, double calories, int difficulty, int tiredness, string notes, DateTime dateTime)
        {
            TypeId = typeId;
            UserId = userId;
            Duration = duration;
            Calories = calories;
            Difficulty = difficulty;
            Tiredness = tiredness;
            Notes = notes;
            DateTime = dateTime;
            Validate();
            
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(TypeId.ToString())) throw new ArgumentException("Invalid Type");
            if (Difficulty > 10 || Difficulty < 0) throw new ArgumentException("Invalid Difficulty");
            if (Tiredness > 10 || Tiredness < 0) throw new ArgumentException("Invalid Tiredness");
        }
    }
}
