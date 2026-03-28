using Microsoft.EntityFrameworkCore;
using SharedResources.Models;

namespace SharedResources.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<AirlineModel> Airlines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AirlineModel>(entity =>
            {
                entity.HasKey(e => e.Code);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(30);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
