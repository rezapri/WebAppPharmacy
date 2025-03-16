namespace WebAppPharmacy.Models
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
        public string Status { get; set; } // Menambahkan status
        public List<string> ErrorList { get; set; } // Menambahkan list error

        public PagedResult()
        {
            ErrorList = new List<string>();
        }
    }
}
