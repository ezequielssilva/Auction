using Auction.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Auction.Infra.Data
{
    public class AuctionContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Negotiation> Negotiations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQL;Database=Auction;User Id=sa;Password=E34A18M@gf;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Negotiation>().ToTable("Negotiation");
        }
    }
}
