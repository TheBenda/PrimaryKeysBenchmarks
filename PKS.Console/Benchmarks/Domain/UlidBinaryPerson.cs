using System.ComponentModel.DataAnnotations;
using PKS.Console.Benchmarks.Domain.Extensions;

namespace PKS.Console.Benchmarks.Domain;

public class UlidBinaryPerson
{
    [Key]
    public Ulid Id { get; init; }
    public required string Name { get; init; }

    public static UlidBinaryPerson CreateRandom()
        => new UlidBinaryPerson
        {
            Id = Ulid.NewUlid(),
            Name = NameFaker.RandomName()
        };
}