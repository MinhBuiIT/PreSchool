using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLPreschool.Data;
using QLPreschool.Models;
using QLPreschool.ModelViews;

namespace QLPreschool.Areas.Authorization.Controllers
{
    [Area("Authorization")]
    [Authorize(Roles = "Administrator")]
    public class QLRoleGVController : Controller
    {
        private QlTMnContext _context { get; set; }
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserStore<AppUser> _userStore;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly int ELE_PER_PAGE = 8;
        public QLRoleGVController(QlTMnContext context,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment,
            UserManager<AppUser> userManager,
            IUserStore<AppUser> userStore, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _userStore = userStore;
            _hostingEnvironment = hostingEnvironment;
            _roleManager = roleManager;
        }
        public async Task<ActionResult> Index(int? pages)
        {
            List<AppUser> UsersAll = await _userManager.Users.Where(user => user.maGV != null).OrderBy(user => user.UserName).ToListAsync();
            List<UserRoleMV> dsUserRole = new List<UserRoleMV>();
            foreach (AppUser user in UsersAll)
            {
                var roleUsers = (await _userManager.GetRolesAsync(user)).ToList();
                string roleNames = String.Join(",", roleUsers);
                var gv = _context.GiaoViens.Where(item => item.MaGv == user.maGV).FirstOrDefault();
                dsUserRole.Add(new UserRoleMV() { Id = user.Id,UserName=gv.TenGv,Avatar=gv.AvatarGV,RoleName = roleNames});
            }
            if (pages == null) pages = 1;
            int currentPage = (int)pages;
            int countPages = (int)Math.Ceiling((double)dsUserRole.Count() / ELE_PER_PAGE);
            ViewBag.currentPage = currentPage;
            ViewBag.countPages = countPages;
            dsUserRole = dsUserRole.Skip((currentPage - 1) * ELE_PER_PAGE).Take(ELE_PER_PAGE).ToList();
            ViewBag.Stt = (currentPage - 1)*ELE_PER_PAGE;
            return View(dsUserRole);
        }
        public class MyViewModel
        {
            public string[] RoleNames { get; set; }
        }
        public async Task<ActionResult> AddRoleUser(string userid)
        {
            if (String.IsNullOrEmpty(userid)) return NotFound();
            var User = await _userManager.FindByIdAsync(userid);
            if (User == null) return NotFound("Không tìm thấy User");
            var RoleNames = (await _userManager.GetRolesAsync(User)).ToArray();
            string[] roleNameList = _roleManager.Roles.Select(r => r.Name).ToArray();
            var RollAll = new SelectList(roleNameList);
            ViewBag.RollAll = RollAll;
            ViewBag.User = User;
            MyViewModel model = new MyViewModel() { RoleNames = RoleNames };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddRoleUser(string userid, string[] RoleNames)
        {
            if (String.IsNullOrEmpty(userid)) return NotFound();
            var User = await _userManager.FindByIdAsync(userid);
            if (User == null) return NotFound("Không tìm thấy User");
            string[] roleNameList = _roleManager.Roles.Select(r => r.Name).ToArray();
            var RollAll = new SelectList(roleNameList);

            var OldRoleNames = (await _userManager.GetRolesAsync(User)).ToList();

            var deleteRoleNames = OldRoleNames.Where(o => !RoleNames.Contains(o)).ToList();
            var addRoleName = RoleNames.Where(n => !OldRoleNames.Contains(n)).ToList();

            if (deleteRoleNames.Count() > 0)
            {
                var resultDelete = await _userManager.RemoveFromRolesAsync(User, deleteRoleNames);
                if (!resultDelete.Succeeded)
                {
                    foreach (var err in resultDelete.Errors.ToList())
                    {
                        ModelState.AddModelError(String.Empty, err.Description);
                    }
                    TempData["StatusMessage"] = "Không thành công";

                    return RedirectToAction("Index");

                }
            }
            if (addRoleName.Count() > 0)
            {
                var resultAdd = await _userManager.AddToRolesAsync(User, addRoleName);
                // return Content(resultAdd.Succeeded.ToString());
                if (!resultAdd.Succeeded)
                {
                    foreach (var err in resultAdd.Errors.ToList())
                    {
                        ModelState.AddModelError(String.Empty, err.Description);
                    }
                    TempData["StatusMessage"] = "Không thành công";
                    return RedirectToAction("Index");

                }
            }
            TempData["StatusMessage"] = "Thành công";

            return RedirectToAction("Index");
        }
    }
}
