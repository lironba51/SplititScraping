using Microsoft.EntityFrameworkCore;
using SplitItScrap.Domain.Services.Actors.Entities;

namespace SplitItScrap.DB
{
    public class SplitItScrapDbContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }

        public SplitItScrapDbContext(DbContextOptions<SplitItScrapDbContext> options) : base(options)
        {
        }
    }
}
