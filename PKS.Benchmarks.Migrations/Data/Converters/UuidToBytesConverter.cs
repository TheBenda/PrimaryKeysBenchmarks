using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PKS.Benchmarks.Migrations.Data.Converters;

public class UuidToBytesConverter : ValueConverter<Guid, byte[]>
{
    public UuidToBytesConverter(Expression<Func<Guid, byte[]>> convertToProviderExpression, Expression<Func<byte[], Guid>> convertFromProviderExpression, ConverterMappingHints? mappingHints = null) : base(convertToProviderExpression, convertFromProviderExpression, mappingHints)
    {
    }

    public UuidToBytesConverter(Expression<Func<Guid, byte[]>> convertToProviderExpression, Expression<Func<byte[], Guid>> convertFromProviderExpression, bool convertsNulls, ConverterMappingHints? mappingHints = null) : base(convertToProviderExpression, convertFromProviderExpression, convertsNulls, mappingHints)
    {
    }
}