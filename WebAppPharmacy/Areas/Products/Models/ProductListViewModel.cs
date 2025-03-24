using WebAppPharmacy.Models;

namespace WebAppPharmacy.Areas.Products.Models
{
    public class ProductListViewModel
    {
        public long Id { get; set; }
        public string? ImageUrl { get; set; } // Untuk gambar produk
        public string CategoryName { get; set; } = string.Empty;
        public string? ProductCode { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public long ProductCost { get; set; } // Harga Modal
        public long ProductPrice { get; set; } // Harga Jual
        public long ProductQuantity { get; set; } // Banyaknya stok
    }
}
