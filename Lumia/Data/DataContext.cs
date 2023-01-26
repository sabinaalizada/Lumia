using Lumia.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lumia.Data
{
    public class DataContext:IdentityDbContext
    {
        public DataContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {

        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Setting> Settings { get; set; }
    }
}
