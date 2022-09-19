using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BeerQuest.Models
{
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
}
