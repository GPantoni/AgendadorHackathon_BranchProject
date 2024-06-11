using Agendador.Domain.Entities;

namespace Agendador.Domain.Interfaces;
public interface IParticipantRepository
{
    Task<IEnumerable<Participant>> GetParticipantsAsync();
    Task<Participant> GetParticipantByIdAsync(Guid id);
    Task<Participant> CreateASync(Participant participant);
    Task<Participant> UpdateAsync(Participant participant);
    Task<Participant> DeleteAsync(Participant participant);
}
