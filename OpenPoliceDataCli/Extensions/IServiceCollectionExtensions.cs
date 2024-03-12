using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OpenPoliceDataCli.Options;
using OpenPoliceDataCli.Services;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;
using Refit;

namespace OpenPoliceDataCli.Extensions;

internal static class IServiceCollectionExtensions
{
    public static IServiceCollection ConfigureRefitClient(this IServiceCollection svc)
    {
        return svc
            .AddRefitClient<IPoliceApi>()
            .ConfigureHttpClient((svc, c) =>
            {
                var policeApiOptions = svc.GetService<IOptions<PoliceApiOptions>>();
                c.BaseAddress = new Uri(policeApiOptions?.Value.BaseUri ?? "");
            })
            .SetHandlerLifetime(TimeSpan.FromMinutes(5))
            .AddPolicyHandler(GetRetryPolicy())
            .Services;
    }

    static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy() =>
        HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
            .WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(1), retryCount: 5));
}
