using AspNetMvcAds.Data;
using AspNetMvcAds.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvcAds.Business
{
    public interface IProductService
    {
        List<Advert> GetAllTrendingsAdds();

        List<Advert> GetAllAdvert(int id);

        List<Advert> AdvertSearch(string q, int categoryId, string location);
    }

    public class ProductService : IProductService
    {
        public AppDbContext Db { get; }

        public ProductService(AppDbContext db)
        {
            Db = db;
        }

        public List<Advert> GetAllAdvert(int id)
        {
            var advert = Db.Adverts
                .Include(e => e.AdvertImages)
                .Include(e => e.AdvertComments)
                .Include(e => e.User)
                .Include(e => e.Category).Where(e => e.Category.Id == id).ToList();
            return advert;
        }

        public List<Advert> GetAllTrendingsAdds()
        {
            var trendProducts = Db.Adverts
                .Include(e => e.Category)
                .Include(e => e.AdvertImages)
                .Where(e => e.IsTrend == true).ToList();

            return trendProducts;
        }

        public List<Advert> AdvertSearch(string q, int categoryId, string location)
        {
            var list = new List<Advert>();

            if (!string.IsNullOrEmpty(q))
            {
                var kelime = q.Split(" ").ToList();
                foreach (var item in kelime)
                {
                    var subList = Db.Adverts
                        .Include(e => e.AdvertImages)
                        .Include(e => e.User)
                        .Include(e => e.Category)
                        .Include(e => e.AdvertComments)
                        .Where(e => e.Title != null && e.Title.ToLower().Contains(item.ToLower()))
                        .ToList();

                    list.AddRange(subList);
                }

                var listTam = list.Distinct().ToList();

                return listTam;
            }

            return list;
        }
    }
}