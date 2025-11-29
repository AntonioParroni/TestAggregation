using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext : DbContext
{

    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Employment> Employment { get; set; }
    public DbSet<Projects> Projects { get; set; }
    public DbSet<Activities> Activities { get; set; }
}