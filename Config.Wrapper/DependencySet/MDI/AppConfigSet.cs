using DIHelper.Unity;
using Microsoft.Extensions.Configuration;
using Unity;

namespace Config.Wrapper.MDI;

public class AppConfigSet 
    : UnityDependencySet
{
    public AppConfigSet(
        IUnityContainer container) 
        : base(container)
    {
    }

    public override void Register()
    {
        Container.RegisterSingleton<IConfigurationBuilder, ConfigurationBuilder>();
        Container.RegisterSingleton<IDirectorySys, DirectorySys>();
        Container.RegisterSingleton<IConfigBuilder, ConfigBuilder>();
        Container.RegisterInstance<IConfiguration>(
            Container.Resolve<IConfigBuilder>().BuildConfig());
        Container.RegisterSingleton<IConfigReader, ConfigReader>();
    }
}