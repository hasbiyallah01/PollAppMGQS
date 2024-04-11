using MgqsPollApp.Models.Entities;

namespace MgqsPollApp.Dtos
{
    public class PollDto
    {
        public DateTime Deadline { get; set; }
        public string Question { get; set; } 
    }

    public class CreatePollRequestModel
    {
        public DateTime Deadline { get; set; }
        public string Question { get; set; }
    }
}
