using FluentAssertions;
using OOP.Version.Entities;
using OOP.Version.Exceptions;

namespace OOP.Version.UnitTests;

public class VersionStringParserTests
{
    [Fact]
    public void GivenValidVersionString_WhenGettingMajor_ThenReturnsCorrectMajor()
    {
        // Arrange
        string versionString = "1.2.3";

        // Act
        uint major = VersionStringParser.GetMajor(versionString);

        // Assert
        major.Should().Be(1u);
    }

    [Fact]
    public void GivenValidVersionString_WhenGettingMinor_ThenReturnsCorrectMinor()
    {
        // Arrange
        string versionString = "1.2.3";

        // Act
        uint minor = VersionStringParser.GetMinor(versionString);

        // Assert
        minor.Should().Be(2u);
    }

    [Fact]
    public void GivenValidVersionString_WhenGettingPatch_ThenReturnsCorrectPatch()
    {
        // Arrange
        string versionString = "1.2.3";

        // Act
        uint patch = VersionStringParser.GetPatch(versionString);

        // Assert
        patch.Should().Be(3u);
    }

    [Fact]
    public void GivenInvalidVersionString_WhenGettingMajor_ThenThrowsInvalidVersionStringException()
    {
        // Arrange
        string versionString = "invalid";

        // Act
        Action act = () => VersionStringParser.GetMajor(versionString);

        // Assert
        act.Should().Throw<InvalidVersionStringException>();
    }

    [Fact]
    public void GivenInvalidVersionString_WhenGettingMinor_ThenThrowsInvalidVersionStringException()
    {
        // Arrange
        string versionString = "1.invalid.3";

        // Act
        Action act = () => VersionStringParser.GetMinor(versionString);

        // Assert
        act.Should().Throw<InvalidVersionStringException>();
    }

    [Fact]
    public void GivenInvalidVersionString_WhenGettingPatch_ThenThrowsInvalidVersionStringException()
    {
        // Arrange
        string versionString = "1.2.invalid";

        // Act
        Action act = () => VersionStringParser.GetPatch(versionString);

        // Assert
        act.Should().Throw<InvalidVersionStringException>();
    }

    [Fact]
    public void GivenVersionStringWithFewerElements_WhenGettingMinor_ThenReturnsZeroMinor()
    {
        // Arrange
        string versionString = "1";

        // Act
        uint minor = VersionStringParser.GetMinor(versionString);

        // Assert
        minor.Should().Be(0u);
    }

    [Fact]
    public void GivenVersionStringWithFewerElements_WhenGettingPatch_ThenReturnsZeroPatch()
    {
        // Arrange
        string versionString = "1.2";

        // Act
        uint minor = VersionStringParser.GetPatch(versionString);

        // Assert
        minor.Should().Be(0u);
    }
}