using BookRental.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookRental.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Rental> Rentals { get; set; }
    }
}
