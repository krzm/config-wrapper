namespace Config.Wrapper;

public interface IConfigWrapper
{
    TData? GetConfigSection<TData>(string sectionName);
}