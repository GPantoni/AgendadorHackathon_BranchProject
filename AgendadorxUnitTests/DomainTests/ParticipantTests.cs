using Agendador.Domain.Entities;
using Agendador.Domain.Validation;

using FluentAssertions;

namespace AgendadorxUnitTests.DomainTests;
public class ParticipantTests
{
    [Fact]
    public void Participant_WhenValidParameters_ShouldCreateParticipant()
    {
        // Arrange
        string name = "John Doe";
        string email = "johndoe@example.com";
        string hashedPassword = "hashedpassword";

        // Act
        var participant = new Participant(name, email, hashedPassword);

        // Assert
        participant.Name.Should().Be(name);
        participant.Email.Should().Be(email);
        participant.HashedPassword.Should().Be(hashedPassword);
    }

    [Theory]
    [InlineData(null, "johndoe@example.com", "hashedpassword")]
    [InlineData("", "johndoe@example.com", "hashedpassword")]
    [InlineData("John Doe", null, "hashedpassword")]
    [InlineData("John Doe", "", "hashedpassword")]
    [InlineData("John Doe", "johndoe@example.com", null)]
    [InlineData("John Doe", "johndoe@example.com", "")]
    [InlineData("John", "johndoe@example.com", "hashedpassword")]
    public void Participant_WhenInvalidParameters_ShouldThrowException(string name, string email, string hashedPassword)
    {
        // Act
        Action act = () => new Participant(name, email, hashedPassword);

        // Assert
        act.Should().Throw<DomainExceptionValidation>();
    }
}
