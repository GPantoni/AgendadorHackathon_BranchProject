using Agendador.Domain.Entities;
using Agendador.Domain.Validation;

using FluentAssertions;

namespace AgendadorxUnitTests.DomainTests;
public class AdministratorTests
{
    [Fact]
    public void Constructor_ValidParameters_SetsProperties()
    {
        // Arrange
        string name = "Admin Name";
        string email = "admin@example.com";
        string hashedPassword = "hashedpassword123";

        // Act
        var administrator = new Administrator(name, email, hashedPassword);

        // Assert
        administrator.Name.Should().Be(name);
        administrator.Email.Should().Be(email);
        administrator.HashedPassword.Should().Be(hashedPassword);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_InvalidName_ThrowsDomainException(string invalidName)
    {
        // Arrange
        string email = "admin@example.com";
        string hashedPassword = "hashedpassword123";

        // Act
        Action act = () => new Administrator(invalidName, email, hashedPassword);

        // Assert
        act.Should().Throw<DomainExceptionValidation>().WithMessage("Name is required");
    }

    [Theory]
    [InlineData("Ad")]
    public void Constructor_NameTooShort_ThrowsDomainException(string shortName)
    {
        // Arrange
        string email = "admin@example.com";
        string hashedPassword = "hashedpassword123";

        // Act
        Action act = () => new Administrator(shortName, email, hashedPassword);

        // Assert
        act.Should().Throw<DomainExceptionValidation>().WithMessage("Name must have at least 3 characters");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_InvalidEmail_ThrowsDomainException(string invalidEmail)
    {
        // Arrange
        string name = "Admin Name";
        string hashedPassword = "hashedpassword123";

        // Act
        Action act = () => new Administrator(name, invalidEmail, hashedPassword);

        // Assert
        act.Should().Throw<DomainExceptionValidation>().WithMessage("Email is required");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_InvalidHashedPassword_ThrowsDomainException(string invalidHashedPassword)
    {
        // Arrange
        string name = "Admin Name";
        string email = "admin@example.com";

        // Act
        Action act = () => new Administrator(name, email, invalidHashedPassword);

        // Assert
        act.Should().Throw<DomainExceptionValidation>().WithMessage("Password is required");
    }
}
