using AspNetMvcAds.Business;
using AspNetMvcAds.Data;
using AspNetMvcAds.Data.Entity;
using AspNetMvcAds.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcAds.Web.Mvc.Controllers
{
    public class AuthController : Controller
    {      
          public UserService _userService { get; }
           
          public AppDbContext Db { get; }

        public AuthController(UserService userService, AppDbContext db)
        {


            _userService = userService;
            Db = db;

         }
        public IActionResult Index()
        {
            return View();
        }

        //Auth / Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetUserByUserNameOrEmail(model.UserName, model.Email);

                if (user != null)
                {
                    ModelState.AddModelError(string.Empty, "Exist user");
                    return View();
                }

                var newUser = new User()
                {
                    Name = model.UserName,
                    Email = model.Email,
                    Password = model.Password,
                    Roles = "Guest",
                   

                };

                Db.Users.Add(newUser);
                Db.SaveChanges();

                return RedirectToAction(nameof(RegisterSuccess));
            
            }


            return View();
        }

        public IActionResult RegisterSuccess()
        {
            return View();


        }

        // Auth/ Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost] // Cookie Authentication
        public async Task<IActionResult> Login_Direct(LoginViewModel model, string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (model.EmailAddressOrUsername == "bilge@webmail.com" && model.Password == "123")
                {
                    // Kimlik Bilgileri
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, "1"),
                        new Claim(ClaimTypes.Name, "Bilge"),
                        new Claim(ClaimTypes.Surname, "Köroğlu"),
                        new Claim(ClaimTypes.GivenName, "Bilge"),
                        new Claim(ClaimTypes.Email, model.EmailAddressOrUsername)
                    };

                    if (model.EmailAddressOrUsername == "bilge@webmail.com")
                    {
                        claims.Add(new Claim("Role", "Admin"));
                    }

                    // Kimlik
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    // Cüzdan
                    var claimsPrinciple = new ClaimsPrincipal(claimsIdentity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe,
                        ExpiresUtc = DateTime.UtcNow.AddDays(1)
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrinciple, properties); //Cookie Authentication kodu 

                    return Redirect(returnUrl != null ? returnUrl : "/");
                }
            }

            ModelState.AddModelError(string.Empty, "Email or password is incorrect!");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = Db.Users.FirstOrDefault(e =>
                    (e.Email == model.EmailAddressOrUsername.Trim() || e.Name == model.EmailAddressOrUsername.Trim()) &&
                    e.Password == model.Password.Trim()
                );

                if (user != null)
                {
                    // Kimlik Bilgileri
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Surname, ""),
                        new Claim(ClaimTypes.Email, user.Email)
                    };

                    if (user.Roles.Contains("Admin"))
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                    }

                    // Kimlik
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    // Cüzdan
                    var claimsPrinciple = new ClaimsPrincipal(claimsIdentity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe,
                        ExpiresUtc = DateTime.UtcNow.AddDays(1)
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrinciple, properties);

                    return Redirect(returnUrl != null ? returnUrl : "/");
                }
            }

            ModelState.AddModelError(string.Empty, "Email or password is incorrect!");

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/");
        }

        public IActionResult AccessDenied()  //Login sayfası yapılırken eklendi.
        {
            return View();
        }

        // Auth ForgotPassword
        public IActionResult ForgotPassword()
        {
            return View();
        }



      
        
    }
}
