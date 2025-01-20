using System.ComponentModel.DataAnnotations;
using PKS.Benchmarks.Domain.Extensions;

namespace PKS.Benchmarks.Domain.Entities;

public class IntTable
{
    public int Id { get; init; }

    public static IntTable Random() =>
        new IntTable
        {
        };
}