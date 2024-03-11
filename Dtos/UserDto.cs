using MgqsPollApp.Models.Enums;

namespace PollAppMGQS.Dtos
{
    public class UserDto
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string DisplayName { get; set; } = default!;

        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public IFormFile ImageUrl { get; set; } = default!;
        public Gender Gender { get; set; } = default!;
    }
}