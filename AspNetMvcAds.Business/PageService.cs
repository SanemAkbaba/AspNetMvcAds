using AspNetMvcAds.Data;
using AspNetMvcAds.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvcAds.Business
{
    public interface IPageService
    {
        Task<Page> GetPageById(int pid);
    }

    public class PageService : IPageService
    {
        public AppDbContext Db { get; }

        public PageService(AppDbContext db)
        {
            Db = db;
        }
        public async Task<Page> GetPageById(int pid)
        {
            var page = await Db.Pages.FirstOrDefaultAsync(e => e.Id == pid);

            return page;
        }
    }
}