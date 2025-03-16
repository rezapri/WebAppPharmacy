using WebAppPharmacy.Models;

namespace WebAppPharmacy.Repositories.RepoCategories
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(long id);
        Task AddAsync(Category product);
        Task UpdateAsync(Category product);
        Task DeleteAsync(long id);

        // Pagination method
        Task<PagedResult<Category>> GetProductsAsync(string searchKeyword, bool sortDescending, int pageNumber, int pageSize);

    }
}
