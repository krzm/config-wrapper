using Microsoft.Extensions.Configuration;
using CLIHelper;

namespace Config.Wrapper;

public class ConfigWrapper 
    : IConfigWrapper
{
    private readonly IOutput output;
    private readonly IConfiguration configuration;

    public ConfigWrapper(
        IOutput output
        , IConfiguration configuration)
    {
        this.output = output;
        this.configuration = configuration;
    }

    public TData? GetConfigSection<TData>(string sectionName)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(configuration);
            return configuration
                .GetRequiredSection(sectionName)
                    .Get<TData>();
        }
        catch (ArgumentNullException anex)
        {
            if (anex.ParamName == nameof(configuration))
                output.Log("App Configuration dependency not registered");
        }
        catch (Exception ex)
        {
            output.Log(ex.Message);
        }
        return default;
    }
}