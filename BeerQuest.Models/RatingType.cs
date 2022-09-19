using System.Text.Json.Serialization;

namespace BeerQuest.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RatingType
{
    Null = 0,
    Beer,
    Atmosphere,
    Amenities,
    Value
}