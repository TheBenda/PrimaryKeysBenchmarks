using PKS.Benchmarks.Domain.Extensions;

namespace PKS.Benchmarks.Domain.Entities;

public class UlidStringTable
{
    public Ulid Id { get; init; }
    
    public static UlidStringTable Random()
        => new UlidStringTable
        {
            Id = Ulid.NewUlid()
        };
    
    public static UlidStringTable Random(DateTimeOffset dateTimeOffset)
        => new UlidStringTable
        {
            Id = Ulid.NewUlid(dateTimeOffset)
        };
}