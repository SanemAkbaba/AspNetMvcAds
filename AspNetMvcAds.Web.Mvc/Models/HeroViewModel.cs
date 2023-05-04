using AspNetMvcAds.Data.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetMvcAds.Web.Mvc.Models
{
    public class HeroViewModel
    {
        public List<SelectListItem> MainCategoriesSelectList { get; set; }
        public List<Category> PopularCategories { get; set; }
    }
}