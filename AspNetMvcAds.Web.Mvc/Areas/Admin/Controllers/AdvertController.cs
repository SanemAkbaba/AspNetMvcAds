using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcAds.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdvertController : Controller
    {
        // Admin / Advert
        public IActionResult Index()
        {
            return View();
        }
    }
}
