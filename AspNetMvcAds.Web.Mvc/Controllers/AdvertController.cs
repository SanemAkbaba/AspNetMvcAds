using AspNetMvcAds.Business;
using AspNetMvcAds.Data;
using AspNetMvcAds.Data.Entity;
using AspNetMvcAds.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvcAds.Web.Mvc.Controllers
{
    public class AdvertController : Controller
    {
        private readonly AppDbContext context;
        private readonly IProductService productService;
        private readonly ICategoryService _categoryService;
        public AdvertController(AppDbContext db, IProductService productService, ICategoryService _categoryService)
        {
            this.context = db;
            this.productService = productService;
            this._categoryService = _categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Advert/ Search / ? query
        public IActionResult Search(string q, int categoryId, string location)
        {
            var list = productService.AdvertSearch(q, categoryId, location);
            ViewBag.SubCategories = _categoryService.GetAllSubCategories();

            ViewBag.QueryText = q;

            return View(list);
        }

        // Advert/Detail/id
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advert = context.Adverts
                .Include(e => e.User)
                .Include(e => e.AdvertComments).ThenInclude(e => e.User)
                .Include(e => e.AdvertImages)
                .Include(e => e.Category)
                .FirstOrDefault(e => e.Id == id);

            if (advert == null)
            {
                return NotFound();
            }

            var vm = new AdvertViewModel()
            {
                Advert = advert,
                Category = advert.Category,
                AdvertImages = advert.AdvertImages,
                AdvertComments = advert.AdvertComments
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult SaveComment(int advertId, string comment, int star)
        {
            //var userName = User.Identity.Name;
            var userName = "Nilüfer Ülgen";
            var user = context.Users.FirstOrDefault(e => e.Name == userName);

            var advertComment = new AdvertComment()
            {
                AdvertId = advertId,
                UserId = user.Id,
                Comment = comment,
                CreatedAt = DateTime.Now,
                IsActive = false,
                CommentStar = star
            };

            context.AdvertComments.Add(advertComment);
            context.SaveChanges();

            return Ok("Yorum kaydedildi");
        }
    }
}