
namespace TrainingApp.DTO
{
    public class UserRegistrationResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public UserRegistrationResponseDto(Guid id, string name, string lastName, string email)
        {
            Id = id.ToString();
            Name = name;
            LastName = lastName;
            Email = email;
        }
    }
}
