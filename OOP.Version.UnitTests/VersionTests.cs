using FluentAssertions;
using OOP.Version.Exceptions;

namespace OOP.Version.UnitTests;

public class VersionTests
{
    [Fact]
    public void GivenValidVersionString_WhenInstantiating_ThenSetsCorrectInitialValues()
    {
        // Arrange
        string versionString = "1.2.3";

        // Act
        var version = new Entities.Version(versionString);

        // Assert
        version.Release().Should().Be("1.2.3");
    }

    [Fact]
    public void GivenEmptyVersionString_WhenInstantiating_ThenSetsDefaultValues()
    {
        // Arrange
        string versionString = "";

        // Act
        var version = new Entities.Version(versionString);

        // Assert
        version.Release().Should().Be("0.0.1");
    }

    [Fact]
    public void GivenVersion_WhenIncrementingMajor_ThenResetsMinorAndPatch()
    {
        // Arrange
        var version = new Entities.Version("1.2.3");

        // Act
        version.Major();

        // Assert
        version.Release().Should().Be("2.0.0");
    }

    [Fact]
    public void GivenVersion_WhenIncrementingMinor_ThenResetsPatch()
    {
        // Arrange
        var version = new Entities.Version("1.2.3");

        // Act
        version.Minor();

        // Assert
        version.Release().Should().Be("1.3.0");
    }

    [Fact]
    public void GivenVersion_WhenIncrementingPatch_ThenIncrementsPatchOnly()
    {
        // Arrange
        var version = new Entities.Version("1.2.3");

        // Act
        version.Patch();

        // Assert
        version.Release().Should().Be("1.2.4");
    }

    [Fact]
    public void GivenVersion_WhenRollingBack_ThenRestoresPreviousState()
    {
        // Arrange
        var version = new Entities.Version("1.2.3");
        version.Major();
        version.Minor();

        // Act
        version.Rollback();

        // Assert
        version.Release().Should().Be("2.0.0");
    }

    [Fact]
    public void GivenVersion_WhenNoVersionToRollingBack_ThenThrowsVersionCannotRollbackException()
    {
        // Arrange
        var version = new Entities.Version("1.2.3");

        // Act
        Action act = () => version.Rollback();

        // Assert
        act.Should().Throw<VersionCannotRollbackException>();
    }

    [Fact]
    public void GivenChainedCalls_WhenExecuting_ThenMethodsAreChainable()
    {
        // Arrange
        var version = new Entities.Version("1.2.3");

        // Act
        version.Major().Minor().Patch();

        // Assert
        version.Release().Should().Be("2.1.1");
    }

    [Fact]
    public void GivenRollback_WhenCalledMultipleTimes_ThenRestoresCorrectStates()
    {
        // Arrange
        var version = new Entities.Version("1.2.3");
        version.Major();   // 2.0.0
        version.Minor();   // 2.1.0
        version.Patch();   // 2.1.1
        version.Major();   // 3.0.0

        // Act
        version.Rollback(); // 2.1.1
        version.Rollback(); // 2.1.0
        version.Rollback(); // 2.0.0

        // Assert
        version.Release().Should().Be("2.0.0");
    }
}
