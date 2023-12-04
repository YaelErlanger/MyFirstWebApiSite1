using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }

        //[EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        //[StringLength(5)]
        public string? Password { get; set; }
    }
}