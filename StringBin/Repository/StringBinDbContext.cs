using Microsoft.EntityFrameworkCore;
using StringBin.Models;

namespace StringBin.Repository;

public class StringBinDbContext : DbContext
{
    public DbSet<StringBinEntry> EntrySet { get; private set; }

    public StringBinDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}