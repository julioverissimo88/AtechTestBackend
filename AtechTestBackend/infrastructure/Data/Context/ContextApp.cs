using AtechTestBackend.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AtechTestBackend.infrastructure.Data.Context
{
    public class ContextApp : DbContext
    {
        public ContextApp(DbContextOptions<ContextApp> options) : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
