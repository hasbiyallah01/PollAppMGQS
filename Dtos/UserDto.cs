using MgqsPollApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MgqsPollApp.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string PhoneNumber { get; set; }
        public IFormFile ImageUrl { get; set; } 
        public Gender Gender { get; set; } 
    }


    public class CreateUserRequestModel
    { 
        public string Password { get; set; } = default!;
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(8, MinimumLength = 5)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile ImageUrl { get; set; }
        public Gender Gender { get; set; }
    }
}