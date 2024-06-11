using Agendador.Domain.Validation;

namespace Agendador.Domain.Entities;
public sealed class Squad : Entity
{
    public Squad(string name)
    {
        ValidateDomain(name);
    }

    public string Name { get; private set; }
    public ICollection<Mentor>? Mentors { get; set; }
    public ICollection<Participant>? Participants { get; set; }

    private void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required");
        DomainExceptionValidation.When(name.Length < 5, "Name must have at least 5 characters");

        Name = name;
    }
}
