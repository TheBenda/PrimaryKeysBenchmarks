namespace PKS.Benchmarks.Domain.Entities;

public class UuidV7BinaryTable
{
    public Guid Id { get; init; }
    
    public static UuidV7BinaryTable Random()
        => new UuidV7BinaryTable
        {
            Id = Guid.CreateVersion7()
        };
    public static UuidV7BinaryTable Random(DateTimeOffset dateTimeOffset)
        => new UuidV7BinaryTable
        {
            Id = Guid.CreateVersion7(dateTimeOffset)
        };
}