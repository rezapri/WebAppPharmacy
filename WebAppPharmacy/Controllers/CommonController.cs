using Microsoft.AspNetCore.Mvc;

namespace WebAppPharmacy.Controllers
{
    public class CommonController : Controller
    {
        public IActionResult GetCreateModal(string title, string fieldLabel)
        {
            ViewData["Title"] = title;
            ViewData["FieldLabel"] = fieldLabel;
            return PartialView("~/Views/Shared/_CreateModal.cshtml");
        }

    }
}
