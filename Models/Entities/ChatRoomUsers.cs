namespace MgqsPollApp.Models.Entities
{
    public class ChatRoomUsers : BaseEntity
    {
        public int UserId { get; set; }
        public int ChatRoomId { get; set; }
        public User User { get; set; }
        public ChatRoom ChatRoom { get; set; } 
    }
}
