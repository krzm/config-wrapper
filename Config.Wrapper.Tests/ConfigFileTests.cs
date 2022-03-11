using System.IO;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace Config.Wrapper.Tests;

public abstract class ConfigFileTests
{
    protected Mock<IDirectorySys> SetDirSysMock(string path)
    {
        var dsysMock = new Mock<IDirectorySys>();
        dsysMock.Setup(m => m.GetAppDir()).Returns(path);
        return dsysMock;
    }

    protected string AssertFile(string path)
    {
        Assert.True(File.Exists(Path.Combine(path, "appsettings.json")));
        return path;
    }

    protected virtual IConfigBuilder SetBuilderForNoFile()
    {
        return SetBuilder(
            SetDirSysMock(
                "C:\\kmazanek@gmail.com\\Code\\config\\Config.Wrapper.Tests\\ConfigFile\\NoFile")
                    .Object);
    }

    protected IConfigBuilder SetBuilderForOkFile()
    {
        return SetBuilder(
            SetDirSysMock(
                AssertFile("C:\\kmazanek@gmail.com\\Code\\config\\Config.Wrapper.Tests\\ConfigFile\\Ok"))
                    .Object);
    }

    protected IConfigBuilder SetBuilderForNotOkFile()
    {
        return SetBuilder(
            SetDirSysMock(
                AssertFile("C:\\kmazanek@gmail.com\\Code\\config\\Config.Wrapper.Tests\\ConfigFile\\NotOk"))
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