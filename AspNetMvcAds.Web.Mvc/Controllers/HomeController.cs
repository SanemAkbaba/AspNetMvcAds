using AspNetMvcAds.Business;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcAds.Web.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPageService pageService;

    public HomeController(ILogger<HomeController> logger, IPageService pageService)
    {
        _logger = logger;
        this.pageService = pageService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> AboutUs()
    {
        var page = await pageService.GetPageById(1);
        if (page != null)
            return View(page);
        else
            return NotFound();
    }

    public IActionResult ContactUs()
    {
        return View();
    }

    public IActionResult UserProfile()
    {
        return View();
    }

    public IActionResult Package()
    {
        return View();
    }

    public IActionResult StoreSingle()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View();
    }
}
