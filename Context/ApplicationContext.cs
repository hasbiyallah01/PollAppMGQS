using MgqsPollApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MgqsPollApp.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<PollOption> PollOptions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<ChatRoomUsers> ChatRoomUsers { get; set; }
        public DbSet<UserPollOption> UserPollSelection { get; set; }


            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Poll>()
                    .HasOne(p => p.User)
                    .WithMany(u => u.Polls)
                    .HasForeignKey(p => p.UserId)
                    .IsRequired();

                modelBuilder.Entity<User>()
                    .HasMany(u => u.Polls)
                    .WithOne(p => p.User)
                    .HasForeignKey(p => p.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            }
    }
}

