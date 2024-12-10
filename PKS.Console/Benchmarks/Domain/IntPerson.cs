using System.ComponentModel.DataAnnotations;

namespace PKS.Console.Benchmarks.Domain;

public class IntPerson
{
    [Key]
    public int Id { get; init; }
    public required string Name { get; init; }
}