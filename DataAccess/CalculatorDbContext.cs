using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class CalculatorDbContext : DbContext
{
    public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options)
        : base(options)
    {
    }

    public DbSet<Calculations> Calculations { get; set; }
}