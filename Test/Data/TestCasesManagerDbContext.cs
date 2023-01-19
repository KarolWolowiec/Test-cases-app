using Microsoft.EntityFrameworkCore;
using Test.Data.Models;

namespace Test.Data
{
    public class TestCasesManagerDbContext : DbContext
    {
        public TestCasesManagerDbContext(
            DbContextOptions<TestCasesManagerDbContext> options) :base(options){ }
        public DbSet<TestCase> TestCases => Set<TestCase>();
        public DbSet<Category> Categories => Set<Category>();

    }
}
