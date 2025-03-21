﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using WebAppPharmacy.Models;
using WebAppPharmacy.Repositories.RepoCategories;

namespace WebAppPharmacy.Areas.Categories.Controllers
{
    [Area("Categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.AddAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Edit(long id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.UpdateAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(long id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _categoryRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task <JsonResult> GetCategories(DataTableAjaxPostModel model)
        {
            var searchKeyword = model.search?.value; // Kata kunci pencarian
            var sortDescending = model.order != null && model.order.Count > 0 && model.order[0].dir == "desc"; // Arah sorting

            // Ambil nomor halaman (page) dan ukuran halaman (pageSize) dari DataTables
            var pageNumber = (model.start / model.length) + 1; // Menghitung halaman berdasarkan start dan length
            var pageSize = model.length; // Ukuran halaman (jumlah data per halaman)

            // Ambil data menggunakan repository
            var result = await _categoryRepository.GetProductsDataTableAsync(searchKeyword, sortDescending, pageNumber, pageSize);

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
