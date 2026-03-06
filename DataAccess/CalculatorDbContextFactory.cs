using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccess;

public class CalculatorDbContextFactory : IDesignTimeDbContextFactory<CalculatorDbContext>
{
    public CalculatorDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CalculatorDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Database=calculator;Username=postgres;Password=postgres");

        return new CalculatorDbContext(optionsBuilder.Options);
    }
}