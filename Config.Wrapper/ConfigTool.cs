using System.ComponentModel;
using Microsoft.Extensions.Configuration;

namespace Config.Wrapper;

public static class ConfigTool
{
    private static ConfigReader reader = new ConfigReader(
        new ConfigBuilder(
            new ConfigurationBuilder()
            , new DirectorySys()
        ).BuildConfig());
    
    public static TData? ReadConfig<TData>()
    {
        return reader.GetConfigSection<TData>(typeof(TData).Name);
    }
}