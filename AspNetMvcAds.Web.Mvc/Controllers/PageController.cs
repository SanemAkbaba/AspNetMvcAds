using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcAds.Web.Mvc.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //Page/ detail/ id
        public IActionResult Detail(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
