using Microsoft.EntityFrameworkCore;
using rest_api_items.Domain.Models;

namespace rest_api_items.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        public DbSet<Item> Items { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Item>().ToTable("Items");
            builder.Entity<Item>().HasKey(p => p.Id);
            builder.Entity<Item>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Item>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Item>().Property(p => p.ManufacturerName).IsRequired().HasMaxLength(30);
            builder.Entity<Item>().Property(p => p.Model).IsRequired().HasMaxLength(30);

            builder.Entity<Item>().HasData
            (
                new Item { Id = 1, Name = "Bateria", ManufacturerName = "Moura", Model = "M60GE" },
                new Item { Id = 2, Name = "Calculadora Científica", ManufacturerName = "Casio", Model = "FX-82MS" }
            );
        }
    }
}