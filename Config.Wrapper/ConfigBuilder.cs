using Microsoft.Extensions.Configuration;

namespace Config.Wrapper;

public class ConfigBuilder 
    : IConfigBuilder
{
    private readonly IConfigurationBuilder configurationBuilder;
    private readonly IDirectorySys directorySystem;

    public IConfigurationBuilder ConfigurationBuilder => configurationBuilder;

    public ConfigBuilder(
        IConfigurationBuilder configurationBuilder
        , IDirectorySys directorySystem)
    {
        this.configurationBuilder = configurationBuilder;
        this.directorySystem = directorySystem;
        ArgumentNullException.ThrowIfNull(this.configurationBuilder);
        ArgumentNullException.ThrowIfNull(this.directorySystem);
    }

    public IConfigurationRoot BuildConfig()
    {
        var temp = directorySystem.GetAppDir();
        return configurationBuilder.SetBasePath(directorySystem.GetAppDir())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json"
                , optional: true)
            .AddEnvironmentVariables()
            .Build();
    }
}