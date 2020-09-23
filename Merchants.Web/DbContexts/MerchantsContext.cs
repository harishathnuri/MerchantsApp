using Merchants.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace Merchants.Web.DbContexts
{
    public class MerchantContext : DbContext
    {
        public MerchantContext(DbContextOptions<MerchantContext> options)
            : base(options)
        {

        }

        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Country>().HasData(SeedData.Countries);
            modelBuilder.Entity<Currency>().HasData(SeedData.Currencies);
        }
    }
}
