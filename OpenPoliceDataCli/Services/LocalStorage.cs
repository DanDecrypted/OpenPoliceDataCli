using OpenPoliceDataCli.Models;
using System.Text.Json;

namespace OpenPoliceDataCli.Services;

public class LocalStorage : ILocalStorage, IAsyncDisposable
{
    private IList<LocalData> _localData;

    public LocalStorage()
    {
        if (!File.Exists("cache.json"))
        {
            _localData = new List<LocalData>();
            return;
        }

        _localData = JsonSerializer.Deserialize<List<LocalData>>(File.ReadAllText("cache.json"));
    }

    public IEnumerable<LocalData> Get() => _localData;

    public void Add(CrimeAtLocation crime)
    {
        if (_localData.Any(x => x.Crimes.Any(y => y.Id == crime.Id)))
            return;

        var existingCategory = _localData.FirstOrDefault(x => x.Category == crime.Category);

        if (existingCategory is null)
        {
            existingCategory = new LocalData()
            {
                Category = crime.Category
            };

            _localData.Add(existingCategory);
        }

        existingCategory.Crimes.Add(LocalStorageCrimes.FromCrimesAtLocation(crime));
    }

    public async ValueTask DisposeAsync()
    {
        if (_localData == null)
            return;

        var fileWriter = new FileStream("cache.json", FileMode.OpenOrCreate);
        await JsonSerializer.SerializeAsync(fileWriter, _localData);
    }
}
