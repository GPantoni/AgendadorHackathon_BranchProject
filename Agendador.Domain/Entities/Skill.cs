using Agendador.Domain.Validation;

namespace Agendador.Domain.Entities;
public class Skill : Entity
{
    public Skill(string name)
    {
        ValidateDomain(name);
    }

    public string Name { get; private set; }

    public void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Name is required");
        DomainExceptionValidation.When(name.Length < 3, "Name must have at least 3 characters");

        Name = name;
    }
}
