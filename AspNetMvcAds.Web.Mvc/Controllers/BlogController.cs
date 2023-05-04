using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcAds.Web.Mvc.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SingleBlog()
        {
            return View();
        }
    }
}
