using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcAds.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingController : Controller
    {
        // Admin/ Setting
        public IActionResult Index()
        {
            return View();
        }
    }
}
