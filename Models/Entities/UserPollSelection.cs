namespace MgqsPollApp.Models.Entities
{
    public class UserPollSelection : BaseEntity
    {
        public int UserId { get; set; }
        public int PollOptionId { get; set; }
        public User User { get; set; }
        public PollOption PollOption { get; set; }
    }

}

