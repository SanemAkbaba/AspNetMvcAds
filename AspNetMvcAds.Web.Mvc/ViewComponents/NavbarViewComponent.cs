using AspNetMvcAds.Business;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcAds.Web.Mvc.ViewComponents
{
    public class NavbarViewComponent : ViewComponent 
    {
        private readonly ICategoryService categoryService;

        public NavbarViewComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.MainCategories = categoryService.GetAllMainCategories();

            ViewBag.SubCategories = categoryService.GetAllSubCategories();

            return View();
        }
    }
}
