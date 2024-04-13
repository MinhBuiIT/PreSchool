using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QLPreschool.Data;
using QLPreschool.Models;
using QLPreschool.ModelViews;
using System.Data;

namespace QLPreschool.Areas.Authorization.Controllers
{
    [Area("Authorization")]
    [Authorize(Roles = "Administrator")]
    public class QLRoleController : Controller
    {
        private QlTMnContext _context { get; set; }
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserStore<AppUser> _userStore;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly int ELE_PER_PAGE = 8;
        public QLRoleController(QlTMnContext context,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment,
            UserManager<AppUser> userManager,
            IUserStore<AppUser> userStore,RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _userStore = userStore;
            _hostingEnvironment = hostingEnvironment;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.OrderBy(r => r.Name).ToList();
            return View(roles);
        }

        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateRole([Bind]RoleMV roleForm)
        {
            if(ModelState.IsValid)
            {
                var identityRole = new IdentityRole(roleForm.Name);
                var result = await _roleManager.CreateAsync(identityRole);
                if(result.Succeeded)
                {
                    TempData["StatusMessage"] = "Tạo Role thành công";
                }else
                {
                    TempData["StatusMessage"] = "Tạo Role không thành công";
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> EditRole(string roleid)
        {
            if (roleid == null)
            {
                return NotFound("Không tìm thấy Role");
            }
            var role = await _roleManager.FindByIdAsync(roleid);
            ViewBag.roleid = roleid;
            if (role == null)
            {
                return NotFound("Không tìm thấy Role");
            }
            var roleMV = new RoleMV() { Name = role.Name};
            return View(roleMV);
        }

        [HttpPost]
        public async Task<ActionResult> EditRole(string roleid, [Bind]RoleMV roleMV)
        {
            if (roleid == null)
            {
                return NotFound("Không tìm thấy Role");
            }
            var role = await _roleManager.FindByIdAsync(roleid);
            if (role == null)
            {
                return NotFound("Không tìm thấy Role");
            }
            role.Name  = roleMV.Name;
            var result = await _roleManager.UpdateAsync(role);
            if(result.Succeeded)
            {
                TempData["StatusMessage"] = "Cập nhật Role thành công";

            }else
            {
                TempData["StatusMessage"] = "Cập nhật Role không thành công";

            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> DeleteRole(string roleid)
        {
            if (roleid == null) return NotFound("Không tìm thấy Role");
            var role = await _roleManager.FindByIdAsync(roleid);
            if (role == null) return NotFound("Không tìm thấy Role");
            ViewBag.role = role;
            return View();
        }

        [HttpPost,ActionName("DeleteRole")]
        public async Task<ActionResult> DeleteRolePost(string roleid)
        {
            if (roleid == null) return NotFound("Không tìm thấy Role");
            var role = await _roleManager.FindByIdAsync(roleid);
            if (role == null) return NotFound("Không tìm thấy Role");
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                TempData["StatusMessage"] = "Xóa Role thành công";

            }else
            {
                TempData["StatusMessage"] = "Xóa Role không thành công";

            }
            return RedirectToAction("Index");
        }
    }
}
