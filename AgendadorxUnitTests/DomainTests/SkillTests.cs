using Agendador.Domain.Entities;
using Agendador.Domain.Validation;

using FluentAssertions;

namespace AgendadorxUnitTests.DomainTests;
public class SkillTests
{
    [Fact]
    public void TestConstructor_ValidName_SetsName()
    {
        var skill = new Skill("Programming");
        skill.Name.Should().Be("Programming");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void TestConstructor_NullOrWhiteSpaceName_ThrowsDomainException(string invalidName)
    {
        Action act = () => new Skill(invalidName);
        act.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Name is required");
    }

    [Fact]
    public void TestConstructor_NameTooShort_ThrowsDomainException()
    {
        Action act = () => new Skill("No");
        act.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Name must have at least 3 characters");
    }
}