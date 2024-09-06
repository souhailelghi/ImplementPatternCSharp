using ExampleForAutoMapper.Enums;
using ExampleForAutoMapper.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ExampleForAutoMapper.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options): base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "John", Age = 30, Amount = 1000, TypeEmployee = TypeEmployee.Developer },
            new Employee { Id = 2, Name = "Diby", Age = 14, Amount = 4700, TypeEmployee = TypeEmployee.Manager },
            new Employee { Id = 3, Name = "somy", Age = 22, Amount = 200, TypeEmployee = TypeEmployee.Tester }
                );
        }
    }
}
