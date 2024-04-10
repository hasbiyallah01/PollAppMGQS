namespace MgqsPollApp.Dtos
{
    public class ChatRoomDto
    {
        public string Name { get; set; } 
        public string Description { get; set; } 
    }

    public class CreateChatRoomRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
