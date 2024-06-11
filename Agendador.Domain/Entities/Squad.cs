namespace Agendador.Domain.Entities;
public sealed class Squad(string name) : Entity
{
    public string Name { get; private set; } = name;
    public ICollection<Mentor>? Mentors { get; set; }
    public ICollection<Participant>? Participants { get; set; }
}
