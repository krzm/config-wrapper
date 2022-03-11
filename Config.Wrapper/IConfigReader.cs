namespace Config.Wrapper;

public interface IConfigReader
{
    TData? GetConfigSection<TData>(string sectionName);
}