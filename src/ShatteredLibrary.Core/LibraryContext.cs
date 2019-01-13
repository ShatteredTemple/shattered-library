using Microsoft.EntityFrameworkCore;
using ShatteredLibrary.Entities;

namespace ShatteredLibrary
{
    public class LibraryContext : DbContext
    {
        public DbSet<Author>? Authors { get; set; }
    }
}
