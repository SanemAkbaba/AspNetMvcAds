using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcAds.Web.Mvc.Areas.Admin.Controllers
{
     [Area("Admin")]
    public class HomeController : Controller
    {        
        //Admin / Home
        public IActionResult Index()
        {
            return View();
        }
    }
}
