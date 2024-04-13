using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLPreschool.Data;
using QLPreschool.Models;
using QLPreschool.ModelViews;
using System.Linq;

namespace QLPreschool.Areas.PhuHuynh.Controllers
{
    [Area("PhuHuynh")]
    [Authorize]
    [Route("trang-phu-huynh")]
    public class PhuHuynhPageController : Controller
    {
        private QlTMnContext _context { get; set; }
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserStore<AppUser> _userStore;
        private readonly int ELE_PER_PAGE = 8;
        public PhuHuynhPageController(QlTMnContext context,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment,
            UserManager<AppUser> userManager,
            IUserStore<AppUser> userStore)
        {
            _context = context;
            _userManager = userManager;
            _userStore = userStore;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var userInfo = _context.Users.Where(u => u.Id == user.Id).FirstOrDefault();

            var phuHuynh = _context.PhuHuynhs.Where(ph => ph.MaPh == userInfo.maPH).FirstOrDefault();
            var treEm = _context.TreEms.Where(te => te.MaPh == phuHuynh.MaPh).FirstOrDefault();

            ViewBag.treEm = treEm;

            var treEmLop = await _context.TreEms.Include(te => te.MaLops).FirstOrDefaultAsync(te => te.MaTe == treEm.MaTe);
            var chiTietLopGV = new List<ChiTietLopGVPHMV>();
            
            foreach (var lopTE in treEmLop.MaLops)
            {
                var gdLopTE = _context.GiangDays.Where(gd => gd.MaLop == lopTE.MaLop && gd.NamHoc == DateTime.Now.Year).FirstOrDefault();
                if(gdLopTE != null)
                {
                    var gvLopTE = _context.GiaoViens.Where(gv => gv.MaGv == gdLopTE.MaGv).FirstOrDefault();
                    var phongHocTE = _context.PhongHocs.Where(ph => ph.MaPhong == lopTE.MaPhong).FirstOrDefault();
                    var loaiLopTE = _context.LoaiLops.Where(ll => ll.MaLoai == lopTE.MaLoai).FirstOrDefault();
                    chiTietLopGV.Add(new ChiTietLopGVPHMV()
                    {
                        maLop = lopTE.MaLop,
                        tenLop = lopTE.TenLop,
                        siSo = lopTE.SiSo,
                        tenLoai = loaiLopTE.TenLoai,
                        tenPhong = phongHocTE.TenPhong,
                        tenGiaoVien = gvLopTE.TenGv,
                        chucVu = gvLopTE.ChucVu,
                        sdt = gvLopTE.SdtGv,
                        avatarGV = gvLopTE.AvatarGV ?? "",

                    });
                }
            }

            var phieuLLTreEm = _context.PhieuLienLacs.Where(tt => tt.MaTe == treEm.MaTe && tt.Nam.Contains(DateTime.Now.Year.ToString())).ToList();
            ViewBag.phieuLLTreEm = phieuLLTreEm;
            return View(chiTietLopGV);
        }
        [Route("the-trang")]
        public async Task<ActionResult> DetailTheTrang(string Nam)
        {
            var user = await _userManager.GetUserAsync(User);
            var userInfo = _context.Users.Where(u => u.Id == user.Id).FirstOrDefault();

            var treEm = _context.TreEms.Where(te => te.MaPh == userInfo.maPH).FirstOrDefault();

            var NamFilter = Nam;
            if (String.IsNullOrEmpty(NamFilter)) NamFilter = DateTime.Now.Year.ToString();
            var dsTheTrangTreEm = _context.TheTrangs.Where(tt => tt.MaTe == treEm.MaTe).Where(tt => tt.Nam == NamFilter).ToList();
            ViewBag.TTTreEm = treEm;
            var NamList = _context.ThoiGians.Select(tg => new { Nam = tg.Nam.Trim() }).Distinct().ToList();
            ViewBag.Nam = new SelectList(NamList, "Nam", "Nam", DateTime.Now.Year);
            dsTheTrangTreEm = dsTheTrangTreEm.OrderBy(te => { var month = Int32.Parse(te.Thang); return month; }).ToList();
            return View(dsTheTrangTreEm);

        }
    }
}
