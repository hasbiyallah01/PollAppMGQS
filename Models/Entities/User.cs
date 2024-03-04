
namespace MgqsPollApp.Models.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string DisplayName { get; set; } = default!;
        public ICollection<ChatRoomUsers> ChatRoomUsers { get; set; } = new HashSet<ChatRoomUsers>();
        public ICollection<Message> Messages { get; set; } = new HashSet<Message>();
        public ICollection<Poll> Polls { get; set; } = new HashSet<Poll>(); 
    }
}