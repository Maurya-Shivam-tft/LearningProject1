using CQRS_Pattern.Model;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Pattern.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Model.Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model.Product>().Property(p => p.Price).HasPrecision(18, 2);
        }
    }
}
