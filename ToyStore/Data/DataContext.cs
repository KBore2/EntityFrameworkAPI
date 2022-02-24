using Microsoft.EntityFrameworkCore;
using ToyStore.Models;

namespace ToyStore.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<AbstractToy> Toys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BearToy>();
            modelBuilder.Entity<CarToy>();
        }
    }
}
