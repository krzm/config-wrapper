using DIHelper.MicrosoftDI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Config.Wrapper.MDI;

public class AppConfigSet 
    : MDIDependencySet
{
    public AppConfigSet(
        IServiceCollection container) 
        : base(container)
    {
    }

    public override void Register()
    {
        Container
            .AddSingleton<IConfigurationBuilder, ConfigurationBuilder>()
            .AddSingleton<IDirectorySys, DirectorySys>()
            .AddSingleton<IConfigBuilder, ConfigBuilder>();
        var configBuilder = Container
			.BuildServiceProvider()
			.GetService<IConfigBuilder>();
		ArgumentNullException.ThrowIfNull(configBuilder);
        Container
            .AddSingleton<IConfiguration>(
                configBuilder.BuildConfig())
            .AddSingleton<IConfigReader, ConfigReader>();
    }
}