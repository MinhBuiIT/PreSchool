using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QLPreschool.Data;
using QLPreschool.Models;
using QLPreschool.ModelViews;

namespace QLPreschool.Areas.Authentication.Controllers
{
    [Area("Authentication")]
    public class PHAuthController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<LoginInputMV> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly QlTMnContext _context;
        public PHAuthController(QlTMnContext context, SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,
            ILogger<LoginInputMV> logger, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        [Route("loginPH")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        [Route("loginPH")]
        public async Task<IActionResult> Index([Bind] LoginInputMV inputGV)
        {

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(inputGV.Email,
                    inputGV.Password, inputGV.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(inputGV.Email);
                    //check là phụ huynh
                    if (String.IsNullOrEmpty(user.maPH))
                    {
                        await _signInManager.SignOutAsync();
                        ModelState.AddModelError(string.Empty, "Mật khẩu hoặc email không đúng.");
                        return View("Index");
                    }

                    _logger.LogInformation("User logged in.");


                    return RedirectToAction("Index", "PhuHuynhPage", new { area = "PhuHuynh" });

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Mật khẩu hoặc email không đúng.");

                }
            }
            return View("Index");
        }

        [Route("logoutPH")]
        public async Task<IActionResult> LogoutPH()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("Bạn đã đăng xuất");
            TempData["StatusMessage"] = "Bạn đã đăng xuất";
            return RedirectToAction("Index");
        }
    }
}
