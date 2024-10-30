using LibraryBookManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryBookManagement.Data
{
public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions  options) : base(options) 
    {

    }
    public DbSet<Book> Books { get; set; }
    public DbSet<BorrowingRecord> BorrowingRecords { get; set; }
      
}
}
