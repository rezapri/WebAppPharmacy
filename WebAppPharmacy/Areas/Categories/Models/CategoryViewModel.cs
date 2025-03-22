using System.ComponentModel.DataAnnotations;
using WebAppPharmacy.Models;

namespace WebAppPharmacy.Areas.Categories.Models
{
    public class CategoryViewModel
    {
        public long Id { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Category Code cannot be longer than 10 characters.")]
        public string CategoryCode { get; set; } = null!;

        [Required]
        [StringLength(100, ErrorMessage = "Category Name cannot be longer than 100 characters.")]
        public string CategoryName { get; set; } = null!;

    }
}
