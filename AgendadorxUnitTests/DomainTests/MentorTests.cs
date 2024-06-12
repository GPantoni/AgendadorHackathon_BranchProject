using Agendador.Domain.Entities;
using Agendador.Domain.Validation;

using FluentAssertions;

namespace AgendadorxUnitTests.DomainTests;
public class MentorTests
{
    [Fact]
    public void Mentor_WhenValidParameters_ShouldCreateMentor()
    {
        // Arrange
        string name = "John Doe";
        string email = "john.doe@example.com";
        string hashedPassword = "hashedPassword";

        // Act
        Mentor mentor = new Mentor(name, email, hashedPassword);

        // Assert
        mentor.Name.Should().Be(name);
        mentor.Email.Should().Be(email);
        mentor.HashedPassword.Should().Be(hashedPassword);
    }

    [Theory]
    [InlineData(null, "john.doe@example.com", "hashedPassword")]
    [InlineData("", "john.doe@example.com", "hashedPassword")]
    [InlineData("John Doe", null, "hashedPassword")]
    [InlineData("John Doe", "", "hashedPassword")]
    [InlineData("John Doe", "john.doe@example.com", null)]
    [InlineData("John Doe", "john.doe@example.com", "")]
    [InlineData("Jo", "john.doe@example.com", "hashedPassword")]
    public void Mentor_WhenInvalidParameters_ShouldThrowDomainException(string name, string email, string hashedPassword)
    {
        // Act
        Action act = () => new Mentor(name, email, hashedPassword);

        // Assert
        act.Should().Throw<DomainExceptionValidation>();
    }
}
