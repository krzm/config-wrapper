using Microsoft.Extensions.Configuration;

namespace Config.Wrapper;

public interface IConfigBuilder
{
    IConfigurationBuilder ConfigurationBuilder { get; }

    IConfigurationRoot BuildConfig();
}