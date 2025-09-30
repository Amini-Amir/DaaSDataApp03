using Microsoft.EntityFrameworkCore;

public class dbDataContext(DbContextOptions<dbDataContext> options) : DbContext(options)
{
    public DbSet<BlazorApp03.Models.Book> Book { get; set; } = default!;
}
