using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcAds.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        // Admin/ Category
        public IActionResult Index()
        {
            return View();
        }
    }
}
