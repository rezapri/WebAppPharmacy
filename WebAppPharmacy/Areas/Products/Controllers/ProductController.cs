using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppPharmacy.Areas.Products.Models;
using WebAppPharmacy.Models;
using WebAppPharmacy.Repositories.RepoCategories;
using WebAppPharmacy.Repositories.RepoProduct;
using WebAppPharmacy.Repositories.RepoUnit;

namespace WebAppPharmacy.Areas.Products.Controllers
{
    [Authorize]
    [Area("Products")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitRepository _unitsRepository;
        private readonly IMapper _mapper;
        private readonly WebAppPharmacyContext _webAppPharmacyContext;

        public ProductController(IProductRepository productRepository,
                                 ICategoryRepository categoryRepository,
                                 IUnitRepository unitsRepository,
                                 IMapper mapper,
                                 WebAppPharmacyContext webAppPharmacyContext)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _unitsRepository = unitsRepository;
            _mapper = mapper;
            _webAppPharmacyContext = webAppPharmacyContext;
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

        [HttpGet]
        public async Task<IActionResult>Upsert(long? id)
        {
            var categories = await _categoryRepository.GetAllAsync();
            var units = await _unitsRepository.GetAllAsync();

            var vm = new ProductViewModel
            {
                Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.CategoryName
                }).ToList(),
                UnitList = units.Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.Name + " | " + u.ShortName
                }).ToList()
            };

            if (id == null)
            {
                // Mode Tambah
                return View(vm);
            }

            var product = await _productRepository.GetByIdAsync(id.Value);
            if (product == null) return NotFound();

            // Mapping manual ke ViewModel
            vm.Id = product.Id;
            vm.ProductName = product.ProductName;
            vm.ProductCode = product.ProductCode;
            vm.ProductQuantity = product.ProductQuantity;
            vm.ProductCost = product.ProductCost;
            vm.ProductPrice = product.ProductPrice;
            vm.IsPrescriptionRequired = product.IsPrescriptionRequired;
            vm.IsPublished = product.IsPublished;
            vm.CategoryId = product.CategoryId;
            vm.ProductUnit = product.ProductUnit;

            return View(vm);
        }

    }
}
