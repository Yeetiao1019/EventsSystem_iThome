using EventsSystem_iThome.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventsSystem_iThome.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Events>()
                .HasOne<EventsInfo>(e => e.EventsInfo)
                .WithOne(ei => ei.Events)
                .HasForeignKey<EventsInfo>(ei => ei.EventsInfoOfEventsId);

            modelBuilder.Entity<EventsInfo>()
                .Property(ei => ei.PersonalSite)
                .HasMaxLength(2090)
                .IsRequired(true);

            modelBuilder.Entity<EventsInfo>()
                .Property(ei => ei.Location)
                .HasMaxLength(100)
                .IsRequired(true);

            modelBuilder.Entity<EventsInfo>()
                .Property(ei => ei.FullIntro)
                .HasMaxLength(1000)
                .IsRequired(true);
            
        }

        public DbSet<Events> Events { get; set; }
        public DbSet<EventsInfo> EventsInfo { get; set; }
        public DbSet<EventsCategory> EventsCategory { get; set; }
        public DbSet<EventsImage> EventsImage { get; set; }
        public DbSet<EventsImageUseType> EventsImageUseType { get; set; }
        public DbSet<EventsEnroll> EventsEnroll { get; set; }
    }
}