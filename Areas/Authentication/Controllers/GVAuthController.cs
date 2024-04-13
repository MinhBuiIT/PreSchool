using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Shared;
using QLPreschool.Data;
using QLPreschool.Models;
using QLPreschool.ModelViews;

namespace QLPreschool.Areas.Authentication.Controllers
{
    [Area("Authentication")]
    public class GVAuthController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<LoginInputMV> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly QlTMnContext _context;
        public GVAuthController(QlTMnContext context,SignInManager<AppUser> signInManager, 
            UserManager<AppUser> userManager, 
            ILogger<LoginInputMV> logger,RoleManager<IdentityRole> roleManager) {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        [Route("loginGV")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        [Route("loginGV")]
        public async Task<IActionResult> Index([Bind]LoginInputMV inputGV)
        {
            
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(inputGV.Email, 
                    inputGV.Password, inputGV.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(inputGV.Email);
                    //check là giáo viên
                    if(String.IsNullOrEmpty(user.maGV)) {
                        await _signInManager.SignOutAsync();
                        ModelState.AddModelError(string.Empty, "Mật khẩu hoặc email không đúng.");
                        return View("Index");
                    }
                    _logger.LogInformation("User logged in.");


                    var roles = await _userManager.GetRolesAsync(user);
                    var roleNames = new List<string>();
                    foreach (var roleName in roles)
                    {
                        var role = await _roleManager.FindByNameAsync(roleName);
                        if (role != null)
                        {
                            roleNames.Add(role.Name);
                        }
                    }
                    if (roleNames.Contains("Administrator"))
                    {
                        return RedirectToAction("Index", "QLGiaoVien", new { area = "GiaoVien" });
                    }else
                    {
                        return RedirectToAction("ThongTinLop", "GiaoVienPT", new { area = "GiaoVien" });

                    }

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Mật khẩu hoặc email không đúng.");
                    
                }
            }
            return View("Index");
        }

        [Route("logoutGV")]
        public async Task<IActionResult> LogoutGV()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("Bạn đã đăng xuất");
            TempData["StatusMessage"] = "Bạn đã đăng xuất";
            return RedirectToAction("Index");
        }
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}
