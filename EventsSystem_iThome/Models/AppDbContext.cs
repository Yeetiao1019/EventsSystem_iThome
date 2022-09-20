using EventsSystem_iThome.Models;
using Microsoft.EntityFrameworkCore;

namespace EventsSystem_iThome.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Events> Events { get; set; }
        public DbSet<EventsInfo> EventsInfo { get; set; }
        public DbSet<EventsCategory> EventsCategory { get; set; }
        public DbSet<EventsImage> EventsImage { get; set; }
        public DbSet<EventsImageUseType> EventsImageUseType { get; set; }
    }
}