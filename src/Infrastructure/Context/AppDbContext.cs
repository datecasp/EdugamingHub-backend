using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext( DbContextOptions<AppDbContext> options): base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<UserGame> UserGames { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) { }
    }
}
