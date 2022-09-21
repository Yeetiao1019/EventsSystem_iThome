using EventsSystem_iThome.Models;
using Microsoft.EntityFrameworkCore;

namespace EventsSystem_iThome.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Events>()
                .HasOne<EventsInfo>(e => e.EventsInfo)
                .WithOne(ei => ei.Events)
                .HasForeignKey<EventsInfo>(ei => ei.EventsInfoOfEventsId);
        }

        public DbSet<Events> Events { get; set; }
        public DbSet<EventsInfo> EventsInfo { get; set; }
        public DbSet<EventsCategory> EventsCategory { get; set; }
        public DbSet<EventsImage> EventsImage { get; set; }
        public DbSet<EventsImageUseType> EventsImageUseType { get; set; }
    }
}