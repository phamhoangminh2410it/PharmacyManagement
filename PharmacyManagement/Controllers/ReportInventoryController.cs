using Microsoft.AspNetCore.Mvc;

namespace PharmacyManagement.Controllers
{
    public class ReportInventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
