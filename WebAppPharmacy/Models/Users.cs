using Microsoft.AspNetCore.Identity;

namespace WebAppPharmacy.Models
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
        public string ProfilePicture { get; set; }
        public string Address { get; set; }
    }
}
