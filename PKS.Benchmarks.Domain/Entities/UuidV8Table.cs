using UUIDNext;

namespace PKS.Benchmarks.Domain.Entities;

public class UuidV8Table
{
    public Guid Id { get; init; }
    
    public static UuidV8Table Random()
        => new UuidV8Table
        {
            Id =  Uuid.NewDatabaseFriendly(Database.SqlServer)
        };
    public static UuidV8Table Random(DateTimeOffset dateTimeOffset)
        => new UuidV8Table
        {
            Id = Uuid.NewDatabaseFriendly(Database.SqlServer)
        };
}