using Bogus;

namespace PKS.Benchmarks.Domain.Extensions;

public static class NameFaker
{
    private static readonly Faker Faker = new Faker();
    
    public static string RandomName() => Faker.Name.FirstName();
}