using PKS.Benchmarks.Domain.Extensions;

namespace PKS.Benchmarks.Domain.Entities;

public class UlidBinaryTable
{
    public Ulid Id { get; init; }

    public static UlidBinaryTable Random()
        => new UlidBinaryTable
        {
            Id = Ulid.NewUlid()
        };
    
    public static UlidBinaryTable Random(DateTimeOffset dateTime)
        => new UlidBinaryTable
        {
            Id = Ulid.NewUlid(dateTime)
        };
}