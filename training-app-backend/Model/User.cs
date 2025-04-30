using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace TrainingApp.Model
{
    public class User
    {
        private static readonly Regex EmailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled, TimeSpan.FromMilliseconds(2000));
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(string name, string lastName, string email, string password)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid Name");
            if (string.IsNullOrWhiteSpace(LastName)) throw new ArgumentException("Invalid Last name");
            if (string.IsNullOrWhiteSpace(Email)) throw new ArgumentException("Invalid Email");
            if (string.IsNullOrWhiteSpace(Password)) throw new ArgumentException("Invalid Password");
            if (!string.IsNullOrWhiteSpace(Email) && !EmailRegex.IsMatch(Email))
                throw new ArgumentException("Invalid Email format.");
        }
    }
}
