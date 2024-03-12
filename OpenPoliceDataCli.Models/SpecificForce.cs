using System.Text.Json.Serialization;

namespace OpenPoliceDataCli.Models;

public record SpecificForce
{
    public string Description { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;

    [JsonPropertyName("engagement_methods")]
    public IEnumerable<EngagementMethod> EngagementMethods { get; set; } = Enumerable.Empty<EngagementMethod>();
    public string Telephone { get; set; } = string.Empty;
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

public record EngagementMethod(string Url, string Descritpion, string Title);