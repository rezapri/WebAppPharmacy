using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppPharmacy.Models;
using WebAppPharmacy.Repositories.RepoCategories;
using WebAppPharmacy.Repositories.RepoProduct;

namespace WebAppPharmacy.Areas.Products.Controllers
{
    [Authorize]
    [Area("Products")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetProductList(DataTableAjaxPostModel model)
        {
            var searchKeyword = model.search?.value; // Kata kunci pencarian
            // Cek apakah ada order data
            string sortColumn = "Id"; // Default sorting pakai kolom ID
            bool sortDescending = false;

            if (model.order != null && model.order.Count > 0)
            {
                int columnIndex = model.order[0].column; // Ambil index kolom yang diurutkan
                sortDescending = model.order[0].dir == "desc";

                // Ambil nama kolom dari daftar columns[] yang dikirim DataTables
                if (model.columns != null && model.columns.Count > columnIndex)
                {
                    sortColumn = model.columns[columnIndex].data; // Misalnya: "CategoryName"
                }
            }
            // Ambil nomor halaman (page) dan ukuran halaman (pageSize) dari DataTables
            var pageNumber = (model.start / model.length) + 1; // Menghitung halaman berdasarkan start dan length
            var pageSize = model.length; // Ukuran halaman (jumlah data per halaman)

            // Ambil data menggunakan repository
            var result = await _productRepository.GetProductsDataTableAsync(searchKeyword, sortColumn, sortDescending, pageNumber, pageSize);

            return Json(new
            {
                draw = model.draw,
                recordsTotal = result.TotalCount,
                recordsFiltered = result.TotalCount,
                data = result.Items,
            });
        }
    }
}
