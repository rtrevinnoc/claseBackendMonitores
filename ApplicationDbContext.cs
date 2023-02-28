using Microsoft.EntityFrameworkCore;
using Monitores.Entidades;

namespace Monitores
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EMonitor> Monitors { get; set; }
        public DbSet<Room> Rooms { get; set; }

    }
}
