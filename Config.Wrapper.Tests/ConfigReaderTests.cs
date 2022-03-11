using System;
using CLIHelper;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Config.Wrapper.Tests;

public class ConfigReaderTests
    : ConfigFileTests
{
    [Fact]
    public void Test_Required_Dependencies()
    {
        var @do = () => SetSut(null);

        Assert.Throws<ArgumentNullException>("this.configuration", @do);
    }

    #pragma warning disable 8604
    private static IConfigReader SetSut(
        IConfiguration? configuration)
    {
        return new ConfigReader(
            configuration);
    }
    #pragma warning restore 8604

    [Fact]
    public void Test_No_Section_Exception()
    {
        IConfigReader sut = SetSutForNotOkFile();

        var @do = () => sut.GetConfigSection<TestSettings>(nameof(TestSettings));

        Assert.Throws<InvalidOperationException>(@do);
    }

    private IConfigReader SetSutForNotOkFile()
    {
        return new ConfigReader(
            SetBuilderForNotOkFile()
                .BuildConfig());
    }

    [Fact]
    public void Test_Ok_Output()
    {
        var expected = new TestSettings
        {
            Key = "test"
            , Number = 3
            , Flag = true
        };
        IConfigReader sut = SetSutForOkFile();

        var result = sut.GetConfigSection<TestSettings>(nameof(TestSettings));

        ArgumentNullException.ThrowIfNull(result);
        Assert.Equal(expected.Key, result.Key);
        Assert.Equal(expected.Number, result.Number);
        Assert.Equal(expected.Flag, result.Flag);
    }

    private IConfigReader SetSutForOkFile()
    {
        return new ConfigReader(
            SetBuilderForOkFile()
                .BuildConfig());
    }
}