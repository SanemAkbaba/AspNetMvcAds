using AspNetMvcAds.Data.Entity;

namespace AspNetMvcAds.Web.Mvc.Models
{
    public class AdvertViewModel
    {
        public Advert Advert { get; set; }

        public List<AdvertImage> AdvertImages { get; set; }

        public List<AdvertComment> AdvertComments { get; set; }

        public Category Category { get; set; }
    }
}
