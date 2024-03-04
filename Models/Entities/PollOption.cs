namespace MgqsPollApp.Models.Entities
{
    public class PollOption : BaseEntity
    {
        public string Text { get; set; } = default!;
        public int VoteCount { get; set; }
    }

}

