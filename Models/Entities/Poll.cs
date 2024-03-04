namespace MgqsPollApp.Models.Entities
{
    public class Poll : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ChatRoomId { get; set; }
        public DateTime Deadline { get; set; }
        public string Question { get; set; } = default!;
        public ICollection<PollOption> Options { get; set; } = new List<PollOption>();
        public ICollection<UserPollSelection> UserSelections { get; set; } = new List<UserPollSelection>();
    }





}

