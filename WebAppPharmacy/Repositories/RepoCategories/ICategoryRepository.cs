using WebAppPharmacy.Models;

namespace WebAppPharmacy.Repositories.RepoCategories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(long id);
        Task AddAsync(Category product);
        Task UpdateAsync(Category product);
        Task DeleteAsync(long id);
        Task<bool> ExistsAsync(string categoryCode, long excludeId);
        Task<bool> ExistsAsync(string categoryCode);

        // Pagination method
        Task<PagedResult<Category>> GetCategoriesDataTableAsync(string searchKeyword, string sortColumn, bool sortDescending, int pageNumber, int pageSize);

    }
}
