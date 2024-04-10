namespace MgqsPollApp.Models.Entities
{
    public class ChatRoom : BaseEntity
    {
        protected string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public  ICollection<Message> Messages { get; set; } = new HashSet<Message>();
        public ICollection<ChatRoomUsers> ChatRoomUsers { get; set; } = new HashSet<ChatRoomUsers>();
    }
}

