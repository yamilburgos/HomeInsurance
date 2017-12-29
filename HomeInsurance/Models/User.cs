using System.ComponentModel.DataAnnotations;

namespace HomeInsurance.Models {

    public class User {

        public User() { }

        public User(NewUser basedOn) {
            Username = basedOn.Username;
            Password = basedOn.Password;
            IsAdmin = false;
        }

        public int Id { get; set; }

        [Required]
        [IsStringLengthBelow(20)]
        [IsAlphanumeric]
        public string Username { get; set; }

        [Required]
        [IsStringLengthBelow(20)]
        [IsAlphanumeric]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}