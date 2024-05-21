using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RevrenLove.CSharpUtilitiesBugReport;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services
            .AddAppSettings()
            .AddSingleton<EmailClient>();
    })
    .Build();

host.Run();
