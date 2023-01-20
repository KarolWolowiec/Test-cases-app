using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Test.Data.Models;

namespace Test.Data
{
    public class TestCasesManagerDbContext : DbContext
    {
        public TestCasesManagerDbContext(
            DbContextOptions<TestCasesManagerDbContext> options) :base(options){ }
        public DbSet<TestCase> TestCases => Set<TestCase>();
        public DbSet<Category> Categories => Set<Category>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "User interface" },
                new Category { Id = 2, Name = "API" },
                new Category { Id = 3, Name = "Documentation" },
                new Category { Id = 4, Name = "Performance" },
                new Category { Id = 5, Name = "Other" });

            modelBuilder.Entity<TestCase>().HasData(
                new TestCase { Id = 1, Title = "Simple title", Description = "A test description", CategoryId = 1 },
                new TestCase { Id = 2, Title = "Simple title 2", Description = "A test description 2", CategoryId = 2 },
                new TestCase { Id = 3, Title = "Simple title 3", Description = "A test description 3", CategoryId = 3 },
                new TestCase { Id = 4, Title = "Simple title 4", Description = "A test description 4", CategoryId = 4 },
                new TestCase { Id = 5, Title = "Simple title 5", Description = "A test description 5", CategoryId = 5 });
        }
    }
}
