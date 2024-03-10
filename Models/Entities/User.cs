
using MgqsPollApp.Models.Enums;

namespace MgqsPollApp.Models.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;

        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string DisplayName { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public Gender Gender { get; set; } = default!;
        public ICollection<UserPollOption> UserSelections { get; set; } = new HashSet<UserPollOption>();

        public ICollection<ChatRoomUsers> ChatRoomUsers { get; set; } = new HashSet<ChatRoomUsers>();
        public ICollection<Message> Messages { get; set; } = new HashSet<Message>();
        public ICollection<Poll> Polls { get; set; } = new HashSet<Poll>(); 
    }
}