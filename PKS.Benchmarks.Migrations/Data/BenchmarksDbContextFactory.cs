using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PKS.Benchmarks.Migrations.Data;

// public class BenchmarksDbContextFactory : IDesignTimeDbContextFactory<BenchmarksDbContext>
// {
//     public BenchmarksDbContext CreateDbContext(string[] args)
//     {
//         var optionsBuilder = new DbContextOptionsBuilder<BenchmarksDbContext>();
//         optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=datasource;User Id=dotnetuser;Password=supersecretpw;");
//     
//         return new BenchmarksDbContext(optionsBuilder.Options);
//     }
// }