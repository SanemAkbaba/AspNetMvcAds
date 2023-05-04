using AspNetMvcAds.Business;
using AspNetMvcAds.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetMvcAds.Web.Mvc.ViewComponents
{
    public class HeroAreaViewComponent : ViewComponent
    {
        private readonly ICategoryService _service;

        public HeroAreaViewComponent(ICategoryService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var vm = new HeroViewModel()
            {
                MainCategoriesSelectList = _service.GetAllMainCategories().Select(e => new SelectListItem { Text = e.Name, Value = e.Id.ToString() }).ToList(),
                PopularCategories = _service.GetPopularCategories()
            };

            return View(vm);
        }
    }
}
