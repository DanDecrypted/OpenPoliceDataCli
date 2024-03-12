namespace OpenPoliceDataCli.Models;

public class LocalData
{
    public string Category { get; set; } = string.Empty;
    public IList<LocalStorageCrimes> Crimes { get; set; } = new List<LocalStorageCrimes>();
}

public class LocalStorageCrimes
{
    public int Id { get; set; }
    public string Context { get; set; }
    public Location Location { get; set; }

    public static LocalStorageCrimes FromCrimesAtLocation(CrimeAtLocation crime)
    {
        return new LocalStorageCrimes
        {
            Id = crime.Id,
            Context = crime.Context,
            Location = crime.Location
        };
    }
}