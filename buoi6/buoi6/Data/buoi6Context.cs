using Microsoft.EntityFrameworkCore;

public class buoi6Context(DbContextOptions<buoi6Context> options) : DbContext(options)
{
    public DbSet<buoi6.Models.Genre> Genre { get; set; } = default!;
    public DbSet<buoi6.Models.Movie> Movie { get; set; } = default!;
}
