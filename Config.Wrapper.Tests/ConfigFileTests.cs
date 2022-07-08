using System.IO;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace Config.Wrapper.Tests;

public abstract class ConfigFileTests
{
    private const string ConfigFile = "appsettings.json";
    private const string RootPath = "C:\\kmazanek.gmail.com";
    private const string TestFolderPath = "Code\\config-wrapper\\Config.Wrapper.Tests\\ConfigFile";
    private const string NoFilePath = $"{RootPath}\\{TestFolderPath}\\NoFile";
    private const string OkFilePath = $"{RootPath}\\{TestFolderPath}\\Ok";
    private const string NotOkFilePath = $"{RootPath}\\{TestFolderPath}\\NotOk";

    protected Mock<IDirectorySys> SetDirSysMock(string path)
    {
        var dsysMock = new Mock<IDirectorySys>();
        dsysMock.Setup(m => m.GetAppDir()).Returns(path);
        return dsysMock;
    }

    protected string AssertFile(string path)
    {
        Assert.True(File.Exists(Path.Combine(path, ConfigFile)));
        return path;
    }

    protected virtual IConfigBuilder SetBuilderForNoFile()
    {
        return SetBuilder(
            SetDirSysMock(
                NoFilePath)
                    .Object);
    }

    protected IConfigBuilder SetBuilderForOkFile()
    {
        return SetBuilder(
            SetDirSysMock(
                AssertFile(OkFilePath))
                    .Object);
    }

    protected IConfigBuilder SetBuilderForNotOkFile()
    {
        return SetBuilder(
            SetDirSysMock(
                AssertFile(NotOkFilePath))
                    .Object);
    }

    #pragma warning disable 8604
    protected IConfigBuilder SetBuilder(
        IDirectorySys? dsys)
    {
        return new ConfigBuilder(
            new ConfigurationBuilder()
            , dsys);
    }
    #pragma warning restore 8604
}