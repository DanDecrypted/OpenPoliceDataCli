using CommandLine;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenPoliceDataCli.Extensions;
using OpenPoliceDataCli.Options;
using OpenPoliceDataCli.Services;
using System.Reflection;


var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureServices((hostContext, services) =>
{
    services
        .AddScoped<ILocalStorage, LocalStorage>()
        .AddOptions<PoliceApiOptions>()
        .BindConfiguration(PoliceApiOptions.SectionName)
        .Services
        .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
        .ConfigureRefitClient()
        .AddHostedService<PoliceDataQuery>();
});


await Parser.Default.ParseArguments<LatLngOptions>(args)
    .WithParsedAsync(o =>
    {
        var app = builder
            .ConfigureServices(svc => svc.AddSingleton(o))
            .Build();

        return app.RunAsync();
    });