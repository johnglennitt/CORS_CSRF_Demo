using MainSite.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MainSite.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            int seedId = -1;
            modelBuilder.Entity<LedgerEntry>().HasData(
                new LedgerEntry() { Id = seedId--, Amount = (decimal)(Random.Shared.NextDouble() * Random.Shared.NextDouble() * 100), Comment = "Sold soul to Elon Musk" },
                new LedgerEntry() { Id = seedId--, Amount = (decimal)(Random.Shared.NextDouble() * Random.Shared.NextDouble() * -100), Comment = "Cryptocurrency gambling" },
                new LedgerEntry() { Id = seedId--, Amount = (decimal)(Random.Shared.NextDouble() * Random.Shared.NextDouble() * 1000), Comment = "Ransom payment" }
                );

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<LedgerEntry> LedgerEntries { get; set; }
    }
}
