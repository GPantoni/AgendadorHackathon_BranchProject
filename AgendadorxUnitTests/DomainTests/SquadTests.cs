using Agendador.Domain.Entities;
using Agendador.Domain.Validation;

using FluentAssertions;

namespace AgendadorxUnitTests.DomainTests;
public class SquadTests
{
    [Fact]
    public void Squad_WhenValidName_ShouldSetPropertiesCorrectly()
    {
        // Arrange
        string name = "Test Squad";

        // Act
        var squad = new Squad(name);

        // Assert
        squad.Name.Should().Be(name);
        squad.Mentors.Should().BeNull();
        squad.Participants.Should().BeNull();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Squad_WhenInvalidName_ShouldThrowException(string name)
    {
        // Arrange

        // Act
        Action act = () => new Squad(name);

        // Assert
        act.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Name is required");
    }

    [Theory]
    [InlineData("1234")]
    [InlineData("abc")]
    public void Squad_WhenInvalidNameLength_ShouldThrowException(string name)
    {
        // Arrange

        // Act
        Action act = () => new Squad(name);

        // Assert
        act.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Name must have at least 5 characters");
    }
}
