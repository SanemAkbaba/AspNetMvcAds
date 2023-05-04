using AspNetMvcAds.Business;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcAds.Web.Mvc.ViewComponents
{
    public class PopularDealsViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public PopularDealsViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.AllTrendingAdds = _productService.GetAllTrendingsAdds();

            return View();
        }
    }
}
