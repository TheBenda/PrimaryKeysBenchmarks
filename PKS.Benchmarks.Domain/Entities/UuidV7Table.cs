using PKS.Benchmarks.Domain.Extensions;

namespace PKS.Benchmarks.Domain.Entities;

public class UuidV7Table
{
    public Guid Id { get; init; }
    
    public static UuidV7Table Random()
        => new UuidV7Table
        {
            Id = Guid.CreateVersion7()
        };
    public static UuidV7Table Random(DateTimeOffset dateTimeOffset)
        => new UuidV7Table
        {
            Id = Guid.CreateVersion7(dateTimeOffset)
        };
}