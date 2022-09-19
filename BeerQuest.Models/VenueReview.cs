using System.Text.Json.Serialization;

namespace BeerQuest.Models;

public class VenueReview
{
    public string Name { get; set; }
    public string Category { get; set; }
    public string Url { get; set; }
    public DateTime Date { get; set; }
    public string Excerpt { get; set; }
    public string Thumbnail { get; set; }
    public double Lat { get; set; }
    public double Lng { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Twitter { get; set; }
    public double BeerRating { get; set; }
    public double AtmosphereRating { get; set; }
    public double AmenitiesRating { get; set; }
    public double ValueRating { get; set; }

    [JsonIgnore] public string JoinedTags { get; set; }

    public string[] Tags => JoinedTags.Split(',');
}