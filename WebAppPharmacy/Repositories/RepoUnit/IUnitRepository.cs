using WebAppPharmacy.Models;

namespace WebAppPharmacy.Repositories.RepoUnit
{
    public interface IUnitRepository
    {
        Task<IEnumerable<Unit>> GetAllAsync();
        Task<Unit> GetByIdAsync(long id);
        Task AddAsync(Unit unit);
        Task UpdateAsync(Unit unit);
        Task DeleteAsync(long id);
        Task<bool> ExistsAsync(string unitName, long? excludeId = null);
    }
}
