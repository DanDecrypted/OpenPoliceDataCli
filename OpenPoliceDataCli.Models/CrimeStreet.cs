using System.Text.Json.Serialization;

namespace OpenPoliceDataCli.Models;

public class CrimeStreet 
{
    public string Category { get; set; } = string.Empty;
    [JsonPropertyName("location_type")]
    public string LocationType { get; set; } = string.Empty;
    public Location? Location { get; set; }
}

public record Street(int Id, string Name);