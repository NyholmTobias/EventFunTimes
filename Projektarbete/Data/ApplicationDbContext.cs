using Microsoft.EntityFrameworkCore;
using Projektarbete.Models;

namespace Projektarbete.Data
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
