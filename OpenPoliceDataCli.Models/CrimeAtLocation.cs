using System.Text.Json.Serialization;

namespace OpenPoliceDataCli.Models;

public record CrimeAtLocation
{
    public string Category { get; set; } = string.Empty;

    [JsonPropertyName("location_type")]
    public string LocationType { get; set; } = string.Empty;
    public Location? Location { get; set; }
    public string Context { get; set; } = string.Empty;
    [JsonPropertyName("outcome_status")]
    public OutcomeStatus? OutcomeStatus { get; set; }

    [JsonPropertyName("persistent_id")]
    public string PersistentId { get; set; } = string.Empty;
    public int Id { get; set; }

    [JsonPropertyName("location_subtype")]
    public string LocationSubtype { get; set; } = string.Empty;
    public string Month { get; set; } = string.Empty;
}