using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
{
    public MyDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();

        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MaBaseDDD;Trusted_Connection=True;");

        return new MyDbContext(optionsBuilder.Options);
    }
}