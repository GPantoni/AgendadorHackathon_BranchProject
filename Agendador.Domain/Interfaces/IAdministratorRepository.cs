using Agendador.Domain.Entities;

namespace Agendador.Domain.Interfaces;
public interface IAdministratorRepository
{
    Task<IEnumerable<Administrator>> GetAdministratorsAsync();
    Task<Administrator> GetAdministratorByIdAsync(Guid id);
    Task<Administrator> CreateASync(Administrator administrator);
    Task<Administrator> UpdateAsync(Administrator administrator);
    Task<Administrator> DeleteAsync(Administrator administrator);
}
