using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PKS.Benchmarks.Domain.Entities;
using PKS.Benchmarks.Migrations.Data.Converters;

namespace PKS.Benchmarks.Migrations.Data;

public class BenchmarksSqlServerDbContext(DbContextOptions<BenchmarksSqlServerDbContext> options) : DbContext(options)
{
    public DbSet<CombinedTable> CombinedTables { get; set; }
    public DbSet<IntTable> IntTables { get; set; }
    public DbSet<UlidBinaryTable> UlidBinaryTables { get; set; }
    public DbSet<UlidStringTable> UlidStringTables { get; set; }
    public DbSet<UuidV4Table> UuidV4Tables { get; set; }
    public DbSet<UuidV7Table> UuidV7Tables { get; set; }
    public DbSet<UuidV8Table> UuidV8Tables { get; set; }
    public DbSet<UuidV7BinaryTable> UuidV7BinaryTables { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CombinedTable>(e =>
        {
            e.HasKey(i => i.Id).IsClustered(false);
            e.Property(i => i.Id).ValueGeneratedNever();
            e.HasIndex(i => i.CreatedOn, "IX_CombinedPerson_CreatedOn").IsClustered();
            e.Property(p => p.CreatedOn)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETUTCDATE()");
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
            e.HasKey(i => i.Id).IsClustered();
            e.Property(i => i.Id).ValueGeneratedNever();
        });
        
        modelBuilder.Entity<UuidV8Table>(e =>
        {
            e.HasKey(i => i.Id).IsClustered();
            e.Property(i => i.Id).ValueGeneratedNever();
        });
        
        modelBuilder.Entity<UuidV7BinaryTable>(e =>
        {
            e.HasKey(i => i.Id);
            e.Property(i => i.Id).ValueGeneratedNever().HasConversion<GuidToBytesConverter>();
        });
    }
}