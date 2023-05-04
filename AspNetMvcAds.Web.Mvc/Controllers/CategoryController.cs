using AspNetMvcAds.Business;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcAds.Web.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public CategoryController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        // category/index/cid
        public IActionResult Index(int cid)
        {
            var list = _productService.GetAllAdvert(cid);
            ViewBag.SubCategories = _categoryService.GetAllSubCategories();
            return View(list);
        }

        public IActionResult AddListing()
        {
            return View();
        }
    }
}
