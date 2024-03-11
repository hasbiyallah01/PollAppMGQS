using MgqsPollApp.Models.Enums;

namespace PollAppMGQS.Dtos
{
    public class UserDto
    {
        public string Email { get; set; } 
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string PhoneNumber { get; set; }
        public IFormFile ImageUrl { get; set; } 
        public Gender Gender { get; set; } 
    }
}