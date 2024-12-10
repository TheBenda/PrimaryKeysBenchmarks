using System.ComponentModel.DataAnnotations;
using PKS.Console.Benchmarks.Domain.Extensions;

namespace PKS.Console.Benchmarks.Domain;

public class UuidV4Person
{
    [Key]
    public Guid Id { get; init; }
    public required string Name { get; init; }
    
    public static UuidV4Person CreateRandom()
        => new UuidV4Person
        {
            Id = Guid.NewGuid(),
            Name = NameFaker.RandomName()
        };
}