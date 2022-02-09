using Microsoft.EntityFrameworkCore;
using PegSolitaire.Entity;

namespace PegSolitaire.Service
{
    class PegSolitaireDbContext : DbContext
    {
        public DbSet<Score> Scores { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=NPuzzle;Trusted_Connection=True;");
        }
    }
}
