using Microsoft.EntityFrameworkCore;
using WebAppPharmacy.Models;

namespace WebAppPharmacy.Repositories.RepoCategories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly WebAppPharmacyContext _context;

        public CategoryRepository(WebAppPharmacyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(long id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        // Implementasi Pagination
        public async Task<PagedResult<Category>> GetProductsAsync(string searchKeyword, bool sortDescending, int pageNumber, int pageSize)
        {
            var result = new PagedResult<Category>
            {
                Status = "success", // Atur status awal
            };

            try
            {
                var query = _context.Categories.AsQueryable();

                // Jika ada keyword pencarian
                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    query = query.Where(p => p.CategoryName.Contains(searchKeyword));
                }

                // Sorting berdasarkan nama produk
                query = sortDescending ? query.OrderByDescending(p => p.CategoryName) : query.OrderBy(p => p.CategoryName);

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
