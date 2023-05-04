using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcAds.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PageController : Controller
    {
        //Admin/Page
        public IActionResult Index()
        {
            return View();
        }
    }
}
