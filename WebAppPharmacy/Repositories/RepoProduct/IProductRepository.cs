using WebAppPharmacy.Areas.Products.Models;
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
        Task<PagedResult<ProductListViewModel>> GetProductsDataTableAsync(string searchKeyword, string sortColumn, bool sortDescending, int pageNumber, int pageSize);
    }
}
