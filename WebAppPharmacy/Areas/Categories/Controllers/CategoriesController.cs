using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using WebAppPharmacy.Areas.Categories.Models;
using WebAppPharmacy.Models;
using WebAppPharmacy.Repositories.RepoCategories;

namespace WebAppPharmacy.Areas.Categories.Controllers
{
    [Authorize]
    [Area("Categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Add Category";
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel categoryVM)
        {
            if (await _categoryRepository.ExistsAsync(categoryVM.CategoryCode))
            {
                ModelState.AddModelError("CategoryCode", "Category Code already exists.");
            }

            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(categoryVM);
                await _categoryRepository.AddAsync(category);

                // ✅ Return JSON agar AJAX bisa menangani respons
                return Json(new { success = true });
            }

            // ✅ Jika validasi gagal, kirim HTML partial + success: false
            return Json(new
            {
                success = false,
                errors = ModelState.Where(kvp => kvp.Value.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    )
            });
        }


        public IActionResult GetCreateModal()
        {
            return PartialView("~/Areas/Categories/Views/Categories/Partial/_CreateModalCategories.cshtml");
        }

        public async Task<IActionResult> Edit(long id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryView = _mapper.Map<CategoryViewModel>(category);
            return View(categoryView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryViewModel categoryVM)
        {
            // Cek apakah CategoryCode sudah dipakai oleh kategori lain (dengan ID berbeda)
            if (await _categoryRepository.ExistsAsync(categoryVM.CategoryCode, categoryVM.Id))
            {
                ModelState.AddModelError("CategoryCode", "Category Code already exists.");
            }

            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(categoryVM);
                await _categoryRepository.UpdateAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(categoryVM);
        }

        public async Task<IActionResult> Delete(long id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryView = _mapper.Map<CategoryViewModel>(category);
            return Json(categoryView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _categoryRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task <JsonResult> GetCategories(DataTableAjaxPostModel model)
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
            var result = await _categoryRepository.GetCategoriesDataTableAsync(searchKeyword, sortColumn, sortDescending, pageNumber, pageSize);

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
