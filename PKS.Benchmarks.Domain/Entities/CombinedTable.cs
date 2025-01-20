using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PKS.Benchmarks.Domain.Entities;

public class CombinedTable
{
    public Guid Id { get; init; }
    public DateTime? CreatedOn { get; init; }
    
    public static CombinedTable Random()
        => new CombinedTable
        {
            Id = Guid.NewGuid()
        };
}