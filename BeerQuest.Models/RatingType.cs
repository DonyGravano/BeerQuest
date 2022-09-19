using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BeerQuest.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RatingType
    {
        Null = 0,
        Beer,
        Atmosphere,
        Amenities,
        Value
    }
}
