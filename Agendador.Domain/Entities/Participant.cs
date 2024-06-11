namespace Agendador.Domain.Entities;
public sealed class Participant(string name, string email, string hashedPassword) : Entity
{
    public string Name { get; private set; } = name;
    public string Email { get; private set; } = email;
    public string HashedPassword { get; private set; } = hashedPassword;

    public Squad? Squad { get; set; }
    public Guid SquadId { get; set; }
}
