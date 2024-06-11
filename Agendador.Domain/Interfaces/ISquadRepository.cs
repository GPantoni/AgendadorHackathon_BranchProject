using Agendador.Domain.Entities;

namespace Agendador.Domain.Interfaces;
public interface ISquadRepository
{
    Task<IEnumerable<Squad>> GetSquadsAsync();
    Task<Squad> GetSquadByIdAsync(Guid id);
    Task<Squad> CreateASync(Squad squad);
    Task<Squad> UpdateAsync(Squad squad);
    Task<Squad> DeleteAsync(Squad squad);
}
