using WebAppPharmacy.Models;

namespace WebAppPharmacy.Repositories.RepoProduct
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(long id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(long id);

        // Pagination method
        Task<PagedResult<Product>> GetProductsAsync(string searchKeyword, bool sortDescending, int pageNumber, int pageSize);
    }
}
