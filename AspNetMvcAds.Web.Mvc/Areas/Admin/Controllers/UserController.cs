using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcAds.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {  
        //Admin/ User
        public IActionResult Index()
        {
            return View();
        }
    }
}
