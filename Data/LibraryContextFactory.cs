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
            optionsBuilder.UseNpgsql(
                "postgresql://neondb_owner:npg_cHwUp8P7IQGl@ep-summer-morning-adhfbz0m-pooler.c-2.us-east-1.aws.neon.tech/neondb?sslmode=require&channel_binding=require"
            );

            return new LibraryContext(optionsBuilder.Options);
        }
    }
}
