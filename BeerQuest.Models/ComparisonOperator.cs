using System.Text.Json.Serialization;

namespace BeerQuest.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ComparisonOperator
{
    NotEqual = 0,
    Equal,
    GreaterThan,
    GreaterThanOrEqualTo,
    LessThan,
    LessThanOrEqualTo
}