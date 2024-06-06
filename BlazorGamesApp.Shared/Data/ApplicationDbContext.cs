using BlazorGamesApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorGamesApp.Shared.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Game> Games { get; set; }
    }
}
