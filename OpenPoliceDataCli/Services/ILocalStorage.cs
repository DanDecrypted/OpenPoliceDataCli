using OpenPoliceDataCli.Models;

namespace OpenPoliceDataCli.Services;

public interface ILocalStorage
{
    public IEnumerable<LocalData> Get();

    public void Add(CrimeAtLocation crime);

    public bool Exists(CrimeAtLocation crime);
}