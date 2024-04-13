using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLPreschool.Data;

namespace QLPreschool.Areas.GiaoVien.Controllers
{
    [Area("GiaoVien")]
    public class QLMonController : Controller
    {
        private QlTMnContext _context { get; set; }
        public QLMonController(QlTMnContext context)
        {

            _context = context;
        }
        //=============================================================================
        public async Task<IActionResult> ListSubjects()
        {
            var query = from monhoc in _context.MonHocs
                        select new
                        {
                            MonHoc = monhoc,
                            LoaiLops = string.Join(", ", monhoc.MaLoais.Select(loailop => loailop.TenLoai))
                        };

            var result = await query.ToListAsync();

            return View(result);
        }
        //=============================================================================
        [HttpGet, ActionName("CreateSubject")]
        public IActionResult CreateSubject()
        {
            var loaiLops = _context.LoaiLops.ToList();
            ViewBag.LoaiLops = loaiLops;
            return View();
        }
        //=============================================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSubject(MonHoc monhoc, string[] MaLoais)
        {

            if (ModelState.IsValid)
            {
                var mh = await _context.MonHocs.FindAsync(monhoc.MaMon);
                if (mh != null)
                {
                    ModelState.AddModelError("MaMon", "Mã môn này đã tồn tại");
                    var loaiLops = _context.LoaiLops.ToList();
                    ViewBag.LoaiLops = loaiLops;
                    return View(monhoc);
                }
                if (MaLoais == null || MaLoais.Length == 0)
                {
                    ModelState.AddModelError("MaLoais", "Vui lòng chọn ít nhất 1 loại lớp");
                    var loaiLops = _context.LoaiLops.ToList();
                    ViewBag.LoaiLops = loaiLops;
                    return View(monhoc);
                }
                foreach (var loaiLopId in MaLoais)
                {
                    var loaiLop = await _context.LoaiLops.FindAsync(loaiLopId);
                    if (loaiLop != null)
                    {
                        monhoc.MaLoais.Add(loaiLop);
                    }
                }

                _context.MonHocs.Add(monhoc);
                await _context.SaveChangesAsync();

                return RedirectToAction("ListSubjects");
            }


            return View(monhoc);
        }

        //=============================================================================
        [HttpGet]
        public async Task<IActionResult> EditSubject(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monHoc = await _context.MonHocs.FindAsync(id);
            if (monHoc == null)
            {
                return NotFound();
            }
            var loaiLops = _context.LoaiLops.ToList();
            ViewBag.LoaiLops = loaiLops;

            return View(monHoc);
        }
        //============================================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSubject(string id, MonHoc monhoc, string[] MaLoais)
        {

            if (id != monhoc.MaMon)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(monhoc);
                var monHoc = await _context.MonHocs.Include(m => m.MaLoais).FirstOrDefaultAsync(m => m.MaMon == id);
                if (monHoc != null)
                {
                    monHoc.MaLoais.Clear();
                    await _context.SaveChangesAsync();
                }
                if (MaLoais == null || MaLoais.Length == 0)
                {
                    ModelState.AddModelError("MaLoais", "Vui lòng chọn ít nhất 1 loại lớp");
                    var loaiLops = _context.LoaiLops.ToList();
                    ViewBag.LoaiLops = loaiLops;
                    return View(monhoc);
                }


                foreach (var loaiLopId in MaLoais)
                {
                    var loaiLop = await _context.LoaiLops.FindAsync(loaiLopId);
                    if (loaiLop != null)
                    {
                        monhoc.MaLoais.Add(loaiLop);
                    }
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("ListSubjects");
            }
            return View(monhoc);
        }


        //=============================================================================
        public async Task<IActionResult> DeleteSubject(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monHoc = await _context.MonHocs
                .FirstOrDefaultAsync(m => m.MaMon == id);
            if (monHoc == null)
            {
                return NotFound();
            }

            return View(monHoc);
        }

        //=============================================================================
        [HttpPost, ActionName("DeleteSubject")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var loaiLop = _context.LoaiLops.Include(ll => ll.MaMons).ToList();
            var monHoc = _context.MonHocs.Find(id);
            if (monHoc == null)
            {
                return NotFound();
            }
            foreach (var item in loaiLop)
            {
                var checkExist = item.MaMons.Where(mm => mm.MaMon == id).FirstOrDefault();
                if(checkExist != null)
                {
                    item.MaMons.Remove(monHoc);
                }
            }
            _context.MonHocs.Remove(monHoc);
            await _context.SaveChangesAsync();
            return RedirectToAction("ListSubjects");
        }
        //=============================================================================

    }
}
