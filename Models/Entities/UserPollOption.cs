namespace MgqsPollApp.Models.Entities
{
    public class UserPollOption : BaseEntity
    {
        public int UserId { get; set; }
        public int PollOptionId { get; set; }
        public User User { get; set; }
        public PollOption PollOption { get; set; }
    }

}

