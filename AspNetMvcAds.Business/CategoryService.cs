using AspNetMvcAds.Data;
using AspNetMvcAds.Data.Entity;

namespace AspNetMvcAds.Business
{
    public interface ICategoryService
    {
        List<Category> GetAllMainCategories();
        List<Category> GetAllSubCategories();
        List<Category> GetPopularCategories();
    }

    public class CategoryService : ICategoryService
    {
        public AppDbContext Db { get; }

        public CategoryService(AppDbContext db)
        {
            Db = db;
        }

        public List<Category> GetAllMainCategories()
        {
            List<Category>? categories = Db.Categories.Where(e => e.ParentId == null).ToList();

            return categories;
        }

        public List<Category> GetAllSubCategories()
        {
            List<Category>? categories = Db.Categories.Where(e => e.ParentId != null).ToList();

            return categories;
        }

        public List<Category> GetPopularCategories()
        {
            //var list = Db.Categories.FromSqlRaw(@"
            //    SELECT c.Name, count(c.Name)
            //    FROM Adverts a 
            //    INNER JOIN Categories c ON c.Id = a.CategoryId
            //    GROUP BY c.Name
            //").ToList();

            var list = Db.Categories.Where(e => e.IsPopular == true).ToList();

            return list;
        }
    }
}