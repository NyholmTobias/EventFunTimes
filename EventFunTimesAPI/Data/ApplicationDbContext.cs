using EventFunTimesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventFunTimesAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }

        public DbSet<OpeningHours> OpeningHours { get; set; }
    }
}
