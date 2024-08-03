using BenchMarksDatabase.Converters;
using BenchMarksDatabase.Entities;
using Microsoft.EntityFrameworkCore;

namespace BenchMarksDatabase;

public class BenchMarkDbContext : DbContext
{
    private const string ConnectionString = ""; //paste your own connection string here

    public DbSet<TableInt> TableInt { get; set; }
    public DbSet<TableGuid> TableGuid { get; set; }
    public DbSet<TableUlid> TableUlid { get; set; }
    public DbSet<TableUlidBinary> TableUlidBinary { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseNpgsql(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TableInt>().HasKey(b => b.Id);
        modelBuilder.Entity<TableInt>().Property(b => b.Id).ValueGeneratedOnAdd();
        
        modelBuilder.Entity<TableGuid>().HasKey(b => b.Id);
        modelBuilder.Entity<TableGuid>().Property(b => b.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<TableUlid>().HasKey(b => b.Id);
        modelBuilder.Entity<TableUlid>().Property(b => b.Id).ValueGeneratedNever().HasConversion<UlidToStringConverter>();
        
        modelBuilder.Entity<TableUlidBinary>().HasKey(b => b.Id);
        modelBuilder.Entity<TableUlidBinary>().Property(b => b.Id).ValueGeneratedNever().HasConversion<UlidToBytesConverter>();
    }
}