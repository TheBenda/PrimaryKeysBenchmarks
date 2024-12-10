using System.ComponentModel.DataAnnotations;
using PKS.Console.Benchmarks.Domain.Extensions;

namespace PKS.Console.Benchmarks.Domain;

public class UlidStringPerson
{
    [Key]
    public Ulid Id { get; init; }
    public required string Name { get; init; }
    
    public static UlidStringPerson CreateRandom()
        => new UlidStringPerson
        {
            Id = Ulid.NewUlid(),
            Name = NameFaker.RandomName()
        };
}