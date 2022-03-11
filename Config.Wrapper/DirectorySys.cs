namespace Config.Wrapper;

public class DirectorySys 
    : IDirectorySys
{
    public string GetAppDir() =>
        Directory.GetCurrentDirectory();
}