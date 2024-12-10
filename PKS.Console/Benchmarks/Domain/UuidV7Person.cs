using System.ComponentModel.DataAnnotations;
using PKS.Console.Benchmarks.Domain.Extensions;

namespace PKS.Console.Benchmarks.Domain;

public class UuidV7Person
{
    [Key]
    public Guid Id { get; init; }
    public required string Name { get; init; }
    
    public static UuidV7Person CreateRandom()
        => new UuidV7Person
        {
            Id = Guid.CreateVersion7(),
            Name = NameFaker.RandomName()
        };
}