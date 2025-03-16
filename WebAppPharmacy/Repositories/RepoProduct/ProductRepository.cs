using Microsoft.EntityFrameworkCore;
using WebAppPharmacy.Data;
using WebAppPharmacy.Models;

namespace WebAppPharmacy.Repositories.RepoProduct
{
    public class ProductRepository : IProductRepository
    {
        private readonly WebAppPharmacyContext _context;

        public ProductRepository(WebAppPharmacyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(long id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        // Implementasi Pagination
        public async Task<PagedResult<Product>> GetProductsAsync(string searchKeyword, bool sortDescending, int pageNumber, int pageSize)
        {
            var result = new PagedResult<Product>
            {
                Status = "success", // Atur status awal
            };

            try
            {
                var query = _context.Products.AsQueryable();

                // Jika ada keyword pencarian
                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    query = query.Where(p => p.ProductName.Contains(searchKeyword));
                }

                // Sorting berdasarkan nama produk
                query = sortDescending ? query.OrderByDescending(p => p.ProductName) : query.OrderBy(p => p.ProductName);

                result.TotalCount = await query.CountAsync(); // Mendapatkan total produk setelah filter dan sort

                // Paginasi
                result.Items = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                result.Status = "error"; // Mengubah status menjadi error
                result.ErrorList.Add($"Error occurred: {ex.Message}"); // Menambahkan pesan error ke list
            }

            return result;
        }
    }
}
