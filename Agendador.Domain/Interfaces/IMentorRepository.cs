using Agendador.Domain.Entities;

namespace Agendador.Domain.Interfaces;
public interface IMentorRepository
{
    Task<IEnumerable<Mentor>> GetMentorsAsync();
    Task<Mentor> GetMentorByIdAsync(Guid id);
    Task<Mentor> CreateASync(Mentor mentor);
    Task<Mentor> UpdateAsync(Mentor mentor);
    Task<Mentor> DeleteAsync(Mentor mentor);
}
