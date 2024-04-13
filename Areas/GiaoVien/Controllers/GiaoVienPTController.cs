using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLPreschool.Data;
using QLPreschool.Models;
using QLPreschool.ModelViews;

namespace QLPreschool.Areas.GiaoVien.Controllers
{
    [Authorize(Roles = "Normal")]
    [Area("GiaoVien")]
    public class GiaoVienPTController : Controller
    {
        private QlTMnContext _context { get; set; }
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserStore<AppUser> _userStore;
        private readonly int ELE_PER_PAGE = 8;
        public GiaoVienPTController(QlTMnContext context,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment,
            UserManager<AppUser> userManager,
            IUserStore<AppUser> userStore)
        {
            _context = context;
            _userManager = userManager;
            _userStore = userStore;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<IActionResult> ThongTinLop()
        {
            var user = await _userManager.GetUserAsync(User);
            var userInfo = _context.Users.Where(u => u.Id == user.Id).FirstOrDefault();

            var TTGiaoVien = _context.GiaoViens.Where(gv => gv.MaGv == userInfo.maGV).FirstOrDefault();
            ViewBag.TTGiaoVien = TTGiaoVien;

            var gdDSUserNow = _context.GiangDays.Where(gd => gd.MaGv == userInfo.maGV && gd.NamHoc == DateTime.Now.Year).ToList();
            var chiTietLopDS = new List<ChiTietLopMV>();
            foreach (var item in gdDSUserNow)
            {
                var TTLop = _context.Lops.Where(l => l.MaLop == item.MaLop).FirstOrDefault();
                var TTLoaiLop = _context.LoaiLops.Where(ll => ll.MaLoai == TTLop.MaLoai).FirstOrDefault();
                chiTietLopDS.Add(new ChiTietLopMV()
                {
                    MaLop = TTLop.MaLop,
                    TenLop = TTLop.TenLop,
                    SiSo = TTLop.SiSo,
                    hocKy = item.HocKy,
                    NamHoc = item.NamHoc,
                    TenLoaiLop = TTLoaiLop.TenLoai,
                    GiaoVienPT = TTGiaoVien.TenGv
                });
            }

            return View(chiTietLopDS);
        }
        public async Task<ActionResult> ChiTietLopPT(string idLop)
        {
            
            if (String.IsNullOrEmpty(idLop)) return NotFound();
            var lopTreEm = await _context.Lops.Include(l => l.MaTes).FirstOrDefaultAsync(l => l.MaLop == idLop);
            var dsTreEm = new List<TTTreEmMV>();
            foreach (var item in lopTreEm.MaTes)
            {
                var phuHuynh = _context.PhuHuynhs.Where(ph => ph.MaPh == item.MaPh).FirstOrDefault();
                dsTreEm.Add(new TTTreEmMV()
                {
                    
                    Photo = item.AvatarTE,
                    TenTe = item.TenTe,
                    NgaySinhTE = item.NgaySinhTE,
                    GioiTinh = item.GioiTinh,
                    TenPh = phuHuynh.TenPh,
                    MaTe = item.MaTe
                });

            }
            dsTreEm = dsTreEm.OrderByDescending(s => s.TenTe).ToList();
            return View(dsTreEm);
        }

        public ActionResult TheTrangTreEm(string idTreEm, string Nam)
        {
            if (String.IsNullOrEmpty(idTreEm)) return NotFound();
            var NamFilter = Nam;
            if (String.IsNullOrEmpty(NamFilter)) NamFilter = DateTime.Now.Year.ToString();
            var dsTheTrangTreEm = _context.TheTrangs.Where(tt => tt.MaTe == idTreEm).Where(tt => tt.Nam == NamFilter).ToList();
            var TTTreEm = _context.TreEms.Where(te => te.MaTe == idTreEm).FirstOrDefault();
            ViewBag.TTTreEm = TTTreEm;
            var NamList = _context.ThoiGians.Select(tg => new {Nam = tg.Nam.Trim() }).Distinct().ToList();
            ViewBag.Nam = new SelectList(NamList, "Nam", "Nam", DateTime.Now.Year);
            dsTheTrangTreEm = dsTheTrangTreEm.OrderBy(te => { var month = Int32.Parse(te.Thang); return month; }).ToList();
            //check cho nhập tháng năm hiện tại
            var TreEm = _context.TheTrangs.Where(tt => tt.MaTe == idTreEm && tt.Nam.Contains(DateTime.Now.Year.ToString()) && tt.Thang.Contains(DateTime.Now.Month.ToString())).FirstOrDefault();
            ViewBag.CheckTT = TreEm == null ? false : true;

            return View(dsTheTrangTreEm);
        }

        public ActionResult NhapTheTrang(string idTreEm)
        {
            if (String.IsNullOrEmpty(idTreEm)) return NotFound();
            ViewBag.idTreEm  = idTreEm;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> NhapTheTrang([Bind]TheTrangMV theTrangForm)
        {
            if(ModelState.IsValid)
            {
                //check
                var checkExistTG = await _context.ThoiGians.Where(tg => tg.Thang == theTrangForm.Thang && tg.Nam == theTrangForm.Nam).FirstOrDefaultAsync();
                if(checkExistTG == null)
                {
                    await _context.ThoiGians.AddAsync(new ThoiGian() { Thang = theTrangForm.Thang,Nam = theTrangForm.Nam });

                }
                await _context.TheTrangs.AddAsync(new TheTrang()
                {
                    MaTe = theTrangForm.MaTe,
                    Thang = theTrangForm.Thang,
                    Nam = theTrangForm.Nam,
                    ChieuCao = theTrangForm.ChieuCao,
                    CanNang = theTrangForm.CanNang
                });
                await _context.SaveChangesAsync();
                TempData["StatusMessage"] = "Thêm Thành Công";
            }else
            {
                TempData["StatusMessage"] = "Thêm không Thành Công";

            }
            return RedirectToAction("TheTrangTreEm", new { idTreEm = theTrangForm.MaTe });
        }
        public async Task<ActionResult> ThongTinLopPLL()
        {
            var user = await _userManager.GetUserAsync(User);
            var userInfo = _context.Users.Where(u => u.Id == user.Id).FirstOrDefault();

            var TTGiaoVien = _context.GiaoViens.Where(gv => gv.MaGv == userInfo.maGV).FirstOrDefault();
            ViewBag.TTGiaoVien = TTGiaoVien;

            var gdDSUserNow = _context.GiangDays.Where(gd => gd.MaGv == userInfo.maGV && gd.NamHoc == DateTime.Now.Year).ToList();
            var chiTietLopDS = new List<ChiTietLopMV>();
            foreach (var item in gdDSUserNow)
            {
                var TTLop = _context.Lops.Where(l => l.MaLop == item.MaLop).FirstOrDefault();
                var TTLoaiLop = _context.LoaiLops.Where(ll => ll.MaLoai == TTLop.MaLoai).FirstOrDefault();
                chiTietLopDS.Add(new ChiTietLopMV()
                {
                    MaLop = TTLop.MaLop,
                    TenLop = TTLop.TenLop,
                    SiSo = TTLop.SiSo,
                    hocKy = item.HocKy,
                    NamHoc = item.NamHoc,
                    TenLoaiLop = TTLoaiLop.TenLoai,
                    GiaoVienPT = TTGiaoVien.TenGv
                });
            }
            return View(chiTietLopDS);
        }
        public async Task<ActionResult> ChiTietLopPTPLL(string idLop)
        {
            if (String.IsNullOrEmpty(idLop)) return NotFound();
            var lopTreEm = await _context.Lops.Include(l => l.MaTes).FirstOrDefaultAsync(l => l.MaLop == idLop);
            var dsTreEm = new List<TTTreEmMV>();
            foreach (var item in lopTreEm.MaTes)
            {
                var phuHuynh = _context.PhuHuynhs.Where(ph => ph.MaPh == item.MaPh).FirstOrDefault();
                dsTreEm.Add(new TTTreEmMV()
                {

                    Photo = item.AvatarTE,
                    TenTe = item.TenTe,
                    NgaySinhTE = item.NgaySinhTE,
                    GioiTinh = item.GioiTinh,
                    TenPh = phuHuynh.TenPh,
                    MaTe = item.MaTe
                });

            }
            dsTreEm = dsTreEm.OrderByDescending(s => s.TenTe).ToList();
            return View(dsTreEm);
        }
        public ActionResult PhieuLienLacTreEm(string idTreEm,string Nam)
        {
            if (String.IsNullOrEmpty(idTreEm)) return NotFound();
            var NamFilter = Nam;
            if (String.IsNullOrEmpty(NamFilter)) NamFilter = DateTime.Now.Year.ToString();
            var dsPLLTreEm = _context.PhieuLienLacs.Where(tt => tt.MaTe == idTreEm).Where(tt => tt.Nam == NamFilter).ToList();

            var TTTreEm = _context.TreEms.Where(te => te.MaTe == idTreEm).FirstOrDefault();
            ViewBag.TTTreEm = TTTreEm;

            var NamList = _context.ThoiGians.Select(tg => new { Nam = tg.Nam.Trim() }).Distinct().ToList();
            ViewBag.Nam = new SelectList(NamList, "Nam", "Nam", DateTime.Now.Year);

            dsPLLTreEm = dsPLLTreEm.OrderBy(te => { var month = Int32.Parse(te.Thang); return month; }).ToList();
            //check cho nhập tháng năm hiện tại
            var TreEm = _context.PhieuLienLacs.Where(tt => tt.MaTe == idTreEm && tt.Nam.Contains(DateTime.Now.Year.ToString()) && tt.Thang.Contains(DateTime.Now.Month.ToString())).FirstOrDefault();
            ViewBag.CheckTT = TreEm == null ? false : true;

            return View(dsPLLTreEm);
        }
        public ActionResult NhapPhieuLienLac(string idTreEm)
        {
            if (String.IsNullOrEmpty(idTreEm)) return NotFound();
            ViewBag.idTreEm = idTreEm;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> NhapPhieuLienLac([Bind]PhieuLienLacMV PLL)
        {
            if (ModelState.IsValid)
            {
                //check
                var checkExistTG = await _context.ThoiGians.Where(tg => tg.Thang == PLL.Thang && tg.Nam == PLL.Nam).FirstOrDefaultAsync();
                if (checkExistTG == null)
                {
                    await _context.ThoiGians.AddAsync(new ThoiGian() { Thang = PLL.Thang, Nam = PLL.Nam });

                }
                await _context.PhieuLienLacs.AddAsync(new PhieuLienLac()
                {
                    MaTe = PLL.MaTe,
                    Thang = PLL.Thang,
                    Nam = PLL.Nam,
                    LoiNhanXet = PLL.LoiNhanXet
                });
                await _context.SaveChangesAsync();
                TempData["StatusMessage"] = "Thêm Thành Công";
            }
            else
            {
                TempData["StatusMessage"] = "Thêm không Thành Công";

            }
            return RedirectToAction("PhieuLienLacTreEm", new { idTreEm = PLL.MaTe });
        }

        public ActionResult EditPhieuLienLac(string idTreEm)
        {
            if (String.IsNullOrEmpty(idTreEm)) return NotFound();
            var TTPhieuLienLacQuery = _context.PhieuLienLacs.Where(pll => pll.MaTe == idTreEm && pll.Thang.Contains(DateTime.Now.Month.ToString())
            && pll.Nam.Contains(DateTime.Now.Year.ToString())).FirstOrDefault();
            var TTPhieuLienLac = new PhieuLienLacMV()
            {
                MaTe = TTPhieuLienLacQuery.MaTe,
                Nam = TTPhieuLienLacQuery.Nam,
                Thang = TTPhieuLienLacQuery.Thang,
                LoiNhanXet = TTPhieuLienLacQuery.LoiNhanXet
            };
            return View(TTPhieuLienLac);
        }

        [HttpPost]
        public ActionResult EditPhieuLienLac([Bind]PhieuLienLacMV PLLEdit)
        {
            if(ModelState.IsValid)
            {
                var pll = _context.PhieuLienLacs.Where(pll => pll.MaTe == PLLEdit.MaTe && pll.Nam.Contains(PLLEdit.Nam) && pll.Thang.Contains(PLLEdit.Thang)).FirstOrDefault();
                pll.LoiNhanXet = PLLEdit.LoiNhanXet;
                _context.SaveChanges();
                TempData["StatusMessage"] = "Chỉnh Sửa Thành Công";
            }else
            {
                TempData["StatusMessage"] = "Chỉnh Sửa Không Thành Công";

            }
            return RedirectToAction("PhieuLienLacTreEm", new { idTreEm = PLLEdit.MaTe });
        }
    }
}
 