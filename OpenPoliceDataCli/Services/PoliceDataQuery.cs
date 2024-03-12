using FluentValidation;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenPoliceDataCli.Options;
using System.Text;

namespace OpenPoliceDataCli.Services;

internal class PoliceDataQuery : IHostedService
{
    private readonly LatLngOptions _lngLatOptions;
    private readonly IValidator<LatLngOptions> _validator;
    private readonly IPoliceApi _policeApi;
    private readonly ILogger<PoliceDataQuery> _logger;
    private readonly ILocalStorage _localStorage;

    public PoliceDataQuery(
        IPoliceApi policeApi, 
        ILogger<PoliceDataQuery> logger, 
        LatLngOptions lngLatOptions, 
        IValidator<LatLngOptions> validator,
        ILocalStorage localStorage
    )
    {
        _lngLatOptions = lngLatOptions;
        _validator = validator;
        _policeApi = policeApi;
        _logger = logger;
        _localStorage = localStorage;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(_lngLatOptions);

        if (!validationResult.IsValid)
        {
            _logger.LogError(validationResult.ToString());
            return;
        }

        var result = (await _policeApi.GetCrimesAtLocationAsync(_lngLatOptions.Latitude, _lngLatOptions.Longitude, _lngLatOptions.Date)).ToList();
        if (result.Count == 0)
        {
            _logger.LogWarning("No crimes found for the dates provided");
        }

        var sb = new StringBuilder();

        foreach (var crime in result)
        {
            if ()
            sb.Append(string.Format("Id: {0} Category: {1}{2}", crime.Id, crime.Category, Environment.NewLine));
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
