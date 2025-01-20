using PKS.Benchmarks.Domain.Extensions;

namespace PKS.Benchmarks.Domain.Entities;

public class UuidV4Table
{
    public Guid Id { get; init; }
    
    public static UuidV4Table Random()
        => new UuidV4Table
        {
            Id = Guid.NewGuid()
        };
}