using Agendador.Domain.Validation;

namespace Agendador.Domain.Entities;
public sealed class Administrator : Entity
{
    public Administrator(string name, string email, string hashedPassword)
    {
        ValidateDomain(name, email, hashedPassword);
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public string HashedPassword { get; private set; }

    public void ValidateDomain(string name, string email, string hashedPassword)
    {
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Name is required");
        DomainExceptionValidation.When(name.Length < 3, "Name must have at least 3 characters");

        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(email), "Email is required");

        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(hashedPassword), "Password is required");

        Name = name;
        Email = email;
        HashedPassword = hashedPassword;
    }
}
