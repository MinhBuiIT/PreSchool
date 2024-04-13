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
    [Authorize(Roles = "Administrator")]
    [Area("GiaoVien")]
    public class QLLopController : Controller
    {
        private QlTMnContext _context { get; set; }
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserStore<AppUser> _userStore;
        private readonly int ELE_PER_PAGE = 8;
        public QLLopController(QlTMnContext context,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment,
            UserManager<AppUser> userManager,
            IUserStore<AppUser> userStore)
        {
            _context = context;
            _userManager = userManager;
            _userStore = userStore;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index(string? search,string? NamHoc,int? pages)
        {
            //lấy danh sách các năm
            var namHocDs = _context.HocKyNamHocs.Select(s => new {NamHoc = s.NamHoc }).Distinct().OrderByDescending(s => s.NamHoc).ToList();
            ViewBag.NamHoc = new SelectList(namHocDs, "NamHoc","NamHoc");

            var lop = _context.Lops.Select(l => l).ToList();
            var chitietLopDs = new List<ChiTietLopMV>();
            foreach (var item in lop)
            {
                var gd = _context.GiangDays.Where(gd => gd.MaLop == item.MaLop).FirstOrDefault();
                var  gvPt = _context.GiaoViens.Where(gv => gv.MaGv == gd.MaGv).FirstOrDefault();
                chitietLopDs.Add(new ChiTietLopMV()
                {
                    MaLop = item.MaLop,
                    TenLop = item.TenLop,
                    SiSo = item.SiSo,
                    hocKy = gd.HocKy,
                    NamHoc = gd.NamHoc,
                    GiaoVienPT = gvPt.TenGv
                });
            }
            if(!String.IsNullOrEmpty(search))
            {
                chitietLopDs = chitietLopDs.Where(l => l.TenLop.Contains(search)).ToList();
                ViewBag.Search = search;
            }
            if(!String.IsNullOrEmpty(NamHoc))
            {
                chitietLopDs = chitietLopDs.Where(l => l.NamHoc == Int32.Parse(NamHoc)).ToList();
                ViewBag.NamHocStr = NamHoc;
            }
            if (pages == null) pages = 1;
            ViewBag.pages = pages;
            int currentPage = (int)pages;
            int countPages = (int)Math.Ceiling((double)chitietLopDs.Count() / ELE_PER_PAGE);
            ViewBag.currentPage = currentPage;
            ViewBag.countPages = countPages;
            chitietLopDs = chitietLopDs.OrderByDescending(ct => ct.NamHoc).Skip((currentPage - 1) * ELE_PER_PAGE).Take(ELE_PER_PAGE).ToList();
            return View(chitietLopDs);
        }
        public async Task<ActionResult> DetailLop(string? idLop)
        {
            if (String.IsNullOrEmpty(idLop)) return NotFound();
            var lop = _context.Lops.Select(l => l).Where(l => l.MaLop == idLop).FirstOrDefault();
            var gd = _context.GiangDays.Where(gd => gd.MaLop == lop.MaLop).FirstOrDefault();
            var gvPt = _context.GiaoViens.Where(gv => gv.MaGv == gd.MaGv).FirstOrDefault();
            var loaiLop = _context.LoaiLops.Where(loai => loai.MaLoai == lop.MaLoai).FirstOrDefault();
            var chitietLop = new ChiTietLopMV() {
                MaLop = lop.MaLop,
                TenLop = lop.TenLop,
                SiSo = lop.SiSo,
                hocKy = gd.HocKy,
                NamHoc = gd.NamHoc,
                GiaoVienPT = gvPt.TenGv,
                TenLoaiLop = loaiLop.TenLoai
            };
            ViewBag.chitietLop = chitietLop;
            var dsTreEmCuaLop = await _context.Lops.Include(l => l.MaTes).FirstOrDefaultAsync(l => l.MaLop == lop.MaLop);
            return View(dsTreEmCuaLop);
        }

        public ActionResult DoiGVPhuTrach(string? idLop,int pages)
        {
            if (String.IsNullOrEmpty(idLop)) return NotFound();
            if (pages == null) pages = 1;
            int currentPage = (int)pages;
            int countPages = (int)Math.Ceiling((double)_context.GiaoViens.Count() / ELE_PER_PAGE);
            ViewBag.currentPage = currentPage;
            ViewBag.countPages = countPages;
            var dsGV = (from gv in _context.GiaoViens select gv).ToList()
                .Skip((currentPage - 1) * ELE_PER_PAGE).Take(ELE_PER_PAGE).ToList();
            ViewBag.idLop = idLop;
            return View(dsGV);
        }

        [HttpPost]
        public async Task<ActionResult> DoiGVPhuTrach(string? idLop,string? MaGv)
        {
            //check gv đã dạy ở học kỳ năm học của lớp đó chưa
            var lopCheck = _context.GiangDays.Where(gd => gd.MaLop == idLop).FirstOrDefault();
            var gvCheck = _context.GiangDays.Where(gd => gd.MaGv == MaGv && gd.HocKy == lopCheck.HocKy && gd.NamHoc == lopCheck.NamHoc).FirstOrDefault();
            if(gvCheck != null)
            {
                TempData["StatusMessage"] = $"Giáo viên này đã phụ trách lớp ở học kỳ {lopCheck.HocKy} - {lopCheck.NamHoc}";
                return RedirectToAction("DetailLop", new { idLop = idLop });
            }


            var gd =  _context.GiangDays.Where(gd => gd.MaLop == idLop).FirstOrDefault();
            var hk = gd.HocKy;
            var namHoc = gd.NamHoc;
            _context.GiangDays.Remove(gd);
            await _context.SaveChangesAsync();
            await _context.GiangDays.AddAsync(new GiangDay()
            {
                MaGv = MaGv,
                MaLop = idLop,
                HocKy = hk,
                NamHoc = namHoc
            });
            await _context.SaveChangesAsync();
            TempData["StatusMessage"] = "Đổi giáo viên phụ trách thành công";
            return RedirectToAction("DetailLop",new {idLop = idLop});
        }

        public async Task<ActionResult> ChangeClass(string oldLop,string idTreEm,string HK,string NH)
        {
            var lopDS = _context.Lops.Select(l => l).Where(l => l.MaLop != oldLop).ToList();
            var chiTiepLopDs = new List<ChiTietLopMV>();
            foreach (var item in lopDS)
            {
                var gdLop = (from gd in _context.GiangDays
                             where gd.MaLop == item.MaLop && gd.HocKy == Int32.Parse(HK) && gd.NamHoc == Int32.Parse(NH)
                             select gd).FirstOrDefault();
                if (gdLop == null) continue;
                var giaovien = _context.GiaoViens.Where(gv => gv.MaGv == gdLop.MaGv).FirstOrDefault();
                var soLuongTreEmTrongLop = await _context.Lops.Include(l => l.MaTes).FirstOrDefaultAsync(l => l.MaLop == item.MaLop);
                chiTiepLopDs.Add(new ChiTietLopMV()
                {
                    MaLop = item.MaLop,
                    hocKy = gdLop.HocKy,
                    NamHoc = gdLop.NamHoc,
                    TenLop = item.TenLop,
                    SiSo = item.SiSo,
                    GiaoVienPT = giaovien.TenGv,
                    ConLai = item.SiSo - soLuongTreEmTrongLop.MaTes.Count
                });
            }
            ViewBag.HK = HK;
            ViewBag.NH = NH;
            ViewBag.idTreEm = idTreEm;
            ViewBag.oldLop = oldLop;
            return View(chiTiepLopDs);
        }

        [HttpPost]
        public async Task<ActionResult> ChangeClass(string oldLop,string maLopNew, string idTreEm, string HK, string NH)
        {
            try
            {
                var lopHocOld = await _context.Lops.Include(l => l.MaTes).FirstOrDefaultAsync(l => l.MaLop == oldLop);
                var treEm = await _context.TreEms.FindAsync(idTreEm);
                if (treEm != null)
                {
                    lopHocOld.MaTes.Remove(treEm);
                    await _context.SaveChangesAsync();
                    var lopHocNew = await _context.Lops.Include(l => l.MaTes).FirstOrDefaultAsync(l => l.MaLop == maLopNew);
                    lopHocNew.MaTes.Add(treEm);
                    await _context.SaveChangesAsync();
                    TempData["StatusMessage"] = "Đổi thành công";
                }
            }catch(Exception ex) {
                TempData["StatusMessage"] = "Đổi không thành công";
            }
            return RedirectToAction("DetailLop", new {idLop = oldLop});
        }

        public async Task<ActionResult> DeleteClass(string id)
        {
            if (String.IsNullOrEmpty(id)) return NotFound();
            var lopDelete = _context.Lops.Find(id);
            var gdDelete = _context.GiangDays.Where(gd => gd.MaLop == id).FirstOrDefault();
            try
            {
                _context.GiangDays.Remove(gdDelete);
                _context.Lops.Remove(lopDelete);
                await _context.SaveChangesAsync();
                TempData["StatusMessage"] = "Xóa lớp thành công";
            }
            catch(Exception ex)
            {
                TempData["StatusMessage"] = "Xóa lớp không thành công";
            }
            return RedirectToAction("Index");
        }
    }
}
