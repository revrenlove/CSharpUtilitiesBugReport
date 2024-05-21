using Microsoft.Extensions.DependencyInjection;

namespace RevrenLove.CSharpUtilitiesBugReport;

public static class Extensions
{
    public static IServiceCollection AddAppSettings(this IServiceCollection services)
    {
        var appSettings = new AppSettings
        {
            ToEmailAddress = GetEnvironmentVariable(nameof(AppSettings.ToEmailAddress)),
            FromEmailAddress = GetEnvironmentVariable(nameof(AppSettings.FromEmailAddress)),
            SmtpHost = GetEnvironmentVariable(nameof(AppSettings.SmtpHost)),
            SmtpHostPortNumber = int.Parse(GetEnvironmentVariable(nameof(AppSettings.SmtpHostPortNumber))),
            EmailAccountLogin = GetEnvironmentVariable(nameof(AppSettings.EmailAccountLogin)),
            EmailAccountKey = GetEnvironmentVariable(nameof(AppSettings.EmailAccountKey)),
        };

        services.AddSingleton(appSettings);

        return services;
    }

    private static string GetEnvironmentVariable(string name)
    {
        var rawValue = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process)!;

        return rawValue;
    }
}
