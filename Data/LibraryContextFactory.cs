using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookRental.Data
{
    public class LibraryContextFactory : IDesignTimeDbContextFactory<LibraryContext>
    {
        public LibraryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();

            // 👇 Use the same connection string you put in appsettings.json
            optionsBuilder.UseNpgsql("Host=ep-summer-morning-adhfbz0m-pooler.c-2.us-east-1.aws.neon.tech;Port=5432;Database=neondb;Username=neondb_owner;Password=npg_cHwUp8P7IQGl;SSL Mode=Require;Trust Server Certificate=true");


            return new LibraryContext(optionsBuilder.Options);
        }
    }
}
