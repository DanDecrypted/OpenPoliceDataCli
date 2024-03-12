using CommandLine;

namespace OpenPoliceDataCli.Options;

public class LatLngOptions
{
    [Option('n', "longitude", Required = true, HelpText = "Longitude to query in the police API")]
    public string Longitude { get; set; } = string.Empty;

    [Option('t', "latitude", Required = true, HelpText = "Latitude to query in the police API")]
    public string Latitude { get; set; } = string.Empty;

    [Option('d', "date", Required = false, HelpText = "Date to pass to the police API. Defaults to Today")]
    public string Date { get; set; } = DateTime.UtcNow.ToString("yyyy-MM");
}
