namespace MgqsPollApp.Models.Entities
{
    public class Message : BaseEntity
    {
        public string Sender { get; set; } = default!;
        public string Content { get; set; } = default!;
        public DateTime Timestamp { get; set; }
        public int UserId { get; set; }
        public int ChatRoomId { get; set; }
        public User User { get; set; }
        public ChatRoom ChatRoom { get; set; }
    }
}

