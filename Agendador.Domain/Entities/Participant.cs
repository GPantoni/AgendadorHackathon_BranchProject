using Agendador.Domain.Validation;

namespace Agendador.Domain.Entities;
public sealed class Participant : Entity
{
    public Participant(string name, string email, string hashedPassword)
    {
        ValidateDomain(name, email, hashedPassword);
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public string HashedPassword { get; private set; }

    public Squad? Squad { get; set; }
    public Guid? SquadId { get; set; }

    private void ValidateDomain(string name, string email, string hashedPassword)
    {
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Name is required");
        DomainExceptionValidation.When(name.Length < 5, "Name must have at least 5 characters");

        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(email), "Email is required");

        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(hashedPassword), "Password is required");

        Name = name;
        Email = email;
        HashedPassword = hashedPassword;
    }
}
