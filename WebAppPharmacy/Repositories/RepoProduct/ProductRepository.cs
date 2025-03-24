using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAppPharmacy.Areas.Products.Models;
using WebAppPharmacy.Data;
using WebAppPharmacy.Models;

namespace WebAppPharmacy.Repositories.RepoProduct
{
    public class ProductRepository : IProductRepository
    {
        private readonly WebAppPharmacyContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(WebAppPharmacyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
        public async Task<PagedResult<ProductListViewModel>> GetProductsDataTableAsync(string searchKeyword, string sortColumn, bool sortDescending, int pageNumber, int pageSize)
        {
            var result = new PagedResult<ProductListViewModel>
            {
                Status = "success", // Atur status awal
            };

            try
            {
                var query = _context.Products
                    .Include(p => p.Category) // Pastikan relasi ke kategori di-load
                    .AsQueryable();

                // Jika ada keyword pencarian
                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    query = query.Where(p => p.ProductName.Contains(searchKeyword));
                }

                // Sorting berdasarkan nama produk
                query = (sortColumn.ToLower() ?? "Id") switch
                {
                    "productname" => sortDescending ? query.OrderByDescending(p => p.ProductName) : query.OrderBy(p => p.ProductName),
                    "categoryname" => sortDescending ? query.OrderByDescending(p => p.Category.CategoryName) : query.OrderBy(p => p.Category.CategoryName),
                    "price" => sortDescending ? query.OrderByDescending(p => p.ProductPrice) : query.OrderBy(p => p.ProductPrice),
                    _ => sortDescending ? query.OrderByDescending(p => p.ProductName) : query.OrderBy(p => p.ProductName) // Default sorting
                };

                result.TotalCount = await query.CountAsync(); // Mendapatkan total produk setelah filter dan sort

                // Paginasi
                // Paginasi
                var products = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                // Mapping ke ViewModel
                result.Items = _mapper.Map<List<ProductListViewModel>>(products);
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
