using OpenPoliceDataCli.Models;
using Refit;

namespace OpenPoliceDataCli.Services;

internal interface IPoliceApi
{
    [Get("/crimes-categories")]
    public Task<IEnumerable<UrlAndName>> GetCrimeCategoriesAsync();

    [Get("/forces/{forceName}")]
    public Task<SpecificForce> GetSpecificForceAsync(string forceName);

    [Get("/crimes-street/all-crime")]
    public Task<IEnumerable<CrimeStreet>> GetStreetCrimesAsync(string lat, string lng, string date);

    [Get("/crimes-street/all-crime")]
    public Task<IEnumerable<CrimeStreet>> GetStreetCrimesAsync(string poly, string date);

    [Get("/crimes-at-location")]
    public Task<IEnumerable<CrimeAtLocation>> GetCrimesAtLocationAsync(string lat, string lng, string date);

    [Get("/crimes-at-location")]
    public Task<IEnumerable<CrimeAtLocation>> GetCrimesAtLocationAsync(string locationId, string date);
}