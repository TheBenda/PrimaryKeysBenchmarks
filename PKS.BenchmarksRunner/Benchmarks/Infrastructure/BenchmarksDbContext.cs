using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PKS.Benchmarks.Domain.Entities;
using PKS.BenchmarksRunner.Benchmarks.Infrastructure.Converters;

namespace PKS.BenchmarksRunner.Benchmarks.Infrastructure;

public class BenchmarksDbContext : DbContext
{
    private const string ConnectionString = "Host=localhost;Port=52083;Username=postgres;Password=wuq8A_Fm9gkQnjZ5nZd5VV;Database=BenchmarkDb";
    public DbSet<CombinedTable> CombinedTables { get; set; }
    public DbSet<IntTable> IntTables { get; set; }
    public DbSet<UlidBinaryTable> UlidBinaryTables { get; set; }
    public DbSet<UlidStringTable> UlidStringTables { get; set; }
    public DbSet<UuidV4Table> UuidV4Tables { get; set; }
    public DbSet<UuidV7Table> UuidV7Tables { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CombinedTable>(e =>
        {
            e.HasKey(i => i.Id);
            e.Property(i => i.Id).ValueGeneratedNever();
            e.HasIndex(i => i.CreatedOn, "IX_CombinedPerson_CreatedOn");
            e.Property(p => p.CreatedOn)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<IntTable>(e =>
        {
            e.HasKey(p => p.Id);
            e.Property(p => p.Id).ValueGeneratedOnAdd();
        });
        
        modelBuilder.Entity<UlidBinaryTable>(e =>
        {
            e.HasKey(i => i.Id);
            e.Property(i => i.Id).ValueGeneratedNever().HasConversion<UlidToBytesConverter>();
        });
        
        modelBuilder.Entity<UlidStringTable>(e =>
        {
            e.HasKey(i => i.Id);
            e.Property(i => i.Id).ValueGeneratedNever().HasConversion<UlidToStringConverter>();
        });
        
        modelBuilder.Entity<UuidV4Table>(e =>
        {
            e.HasKey(i => i.Id);
            e.Property(i => i.Id).ValueGeneratedNever();
        });
        
        modelBuilder.Entity<UuidV7Table>(e =>
        {
            e.HasKey(i => i.Id);
            e.Property(i => i.Id).ValueGeneratedNever();
        });
    }
}