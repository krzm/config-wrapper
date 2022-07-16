using Config.Wrapper.Unity;
using DIHelper.Unity;
using Unity;

namespace Config.Wrapper;

public class ServiceSuite 
    : UnityDependencySuite
{
    public ServiceSuite(
        IUnityContainer container)
        : base(container)
    {
    }

    protected override void RegisterAppData()
    {
        RegisterSet<AppConfigSet>();  
    }
}