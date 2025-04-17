using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAppPharmacy.Models;

namespace WebAppPharmacy.Areas.Products.Models
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        [Required]
        [Display(Name = "Kategori ")]
        public long CategoryId { get; set; }

        [Required]
        [Display(Name = "Nama Produk ")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Kode Produk ")]
        public string? ProductCode { get; set; }

        [Required]
        [Display(Name = "Banyak / QTY ")]
        public long ProductQuantity { get; set; }

        [Required]
        [Display(Name = "Stock ")]
        public long ProductStockAlert { get; set; }

        [Required]
        [Display(Name = "Biaya ")]
        public long ProductCost { get; set; }

        [Required]
        [Display(Name = "Jual ")]
        public long ProductPrice { get; set; }

        [Required]
        [Display(Name = "Satuan ")]
        public string? ProductUnit { get; set; }
        public short IsExpired { get; set; }

        [Required]
        [Display(Name = "Pabrikan ")]
        public string? Manufacturer { get; set; }

        [Required]
        [Display(Name = "Nomor Batch ")]
        public string? BatchNumber { get; set; }
        public short IsPrescriptionRequired { get; set; }
        public short IsPublished { get; set; }

        [Required]
        [Display(Name = "Instruksi Penyimpanan ")]
        public string? StorageInstructions { get; set; }

        [Required]
        [Display(Name = "Catatan ")]
        public string? ProductNote { get; set; }

        [Required]
        [Display(Name = "Tanggal Kadaluarsa ")]
        public DateOnly? ExpirationDate { get; set; }
        [Required]
        [Display(Name = "Simbol Barcode ")]
        public string? ProductBarcodeSymbology { get; set; }
        [Required]
        [Display(Name = "Tipe Pajak ")]
        public short? ProductTaxType { get; set; }
        [Required]
        [Display(Name = "Pajak (%) ")]
        public long? ProductOrderTax { get; set; }
        // Tambahkan ini:
        public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem>? UnitList { get; set; } = new List<SelectListItem>();
    }
}
