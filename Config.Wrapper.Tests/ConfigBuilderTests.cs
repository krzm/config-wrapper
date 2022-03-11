using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Config.Wrapper.Tests;

public class ConfigBuilderTests
    : ConfigFileTests
{
    [Fact]
    public void Test_Required_Dependencies()
    {
        var doDep1 = () => SetSut(null, null);

        Assert.Throws<ArgumentNullException>("this.configurationBuilder",doDep1);

        var doDep2 = () => SetBuilder(null);

        Assert.Throws<ArgumentNullException>("this.directorySystem", doDep2);
    }

    #pragma warning disable 8604
    private static IConfigBuilder SetSut(
        IConfigurationBuilder? configurationBuilder
        , IDirectorySys? dsys)
    {
        return new ConfigBuilder(
            configurationBuilder
            , dsys);
    }
    #pragma warning restore 8604

    [Fact]
    public void Test_No_File_Exception()
    {
        IConfigBuilder sut = SetBuilderForNoFile();

        var @do = () => sut.BuildConfig();

        Assert.Throws<FileNotFoundException>(@do);
        Assert.NotNull(sut.ConfigurationBuilder);
    }

    [Fact]
    public void Test_Ok_Output()
    {
        IConfigBuilder sut = SetBuilderForOkFile();

        var config = sut.BuildConfig();

        Assert.NotNull(config);
        Assert.NotNull(sut.ConfigurationBuilder);
    }
}