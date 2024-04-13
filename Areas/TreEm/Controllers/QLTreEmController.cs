using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLPreschool.Data;
using QLPreschool.Models;
using QLPreschool.ModelViews;
using System;

namespace QLPreschool.Areas.TreEm.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("TreEm")]
    public class QLTreEmController : Controller
    {
        private QlTMnContext _context { get; set; }
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserStore<AppUser> _userStore;
        private readonly int ELE_PER_PAGE = 8;
        public QLTreEmController(QlTMnContext context,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment,
            UserManager<AppUser> userManager,
            IUserStore<AppUser> userStore)
        {
            _context = context;
            _userManager = userManager;
            _userStore = userStore;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<IActionResult> Index(string? search,string? MaLop, int? pages)
        {
            ViewBag.MaLop = MaLop;
            ViewBag.pages = pages;
            var lop = _context.Lops.Select(l => l).ToList();
            lop.Add(new Lop()
            {
                MaLop = "L00",
                TenLop = "Chưa có lớp"
            });
            ViewBag.Lop = new SelectList(lop, "MaLop", "TenLop",MaLop);
            if (!String.IsNullOrEmpty(search))
            {
                var dsTreEmSearch = (from te in _context.TreEms
                                     join ph in _context.PhuHuynhs on te.MaPh equals ph.MaPh
                                     where te.TenTe.Contains(search)
                                     select new { TreEm = te, PhuHuynh = ph }).ToList();
                ViewBag.Search = search;
                ViewBag.TTTreEm = dsTreEmSearch;
                return View();
            }
            if (!String.IsNullOrEmpty(MaLop))
            {

                if(MaLop == "L00")
                {
                    var dsTEKoLop =  _context.TreEms.Include(t => t.MaLops);
                    var dsTreEmFilter = (from te in dsTEKoLop
                                         join ph in _context.PhuHuynhs on te.MaPh equals ph.MaPh
                                         where te.MaLops.Count == 0
                                         select new { TreEm = te, PhuHuynh = ph }).ToList();
                    ViewBag.TTTreEm = dsTreEmFilter;
                }
                else
                {
                    var dsTETheoLop = await _context.Lops.Include(lop => lop.MaTes).FirstOrDefaultAsync(l => l.MaLop == MaLop);
                    var dsTreEmFilter = (from te in dsTETheoLop.MaTes
                                         join ph in _context.PhuHuynhs on te.MaPh equals ph.MaPh
                                         select new { TreEm = te, PhuHuynh = ph }).ToList();
                    ViewBag.TTTreEm = dsTreEmFilter;
                }
                
                
                return View();
            }
            var queryDsTreEm = (from te in _context.TreEms
                                join ph in _context.PhuHuynhs on te.MaPh equals ph.MaPh
                                select new { TreEm = te, PhuHuynh = ph }).ToList();
            if (pages == null) pages = 1;
            ViewBag.pages = pages;
            int currentPage = (int)pages;
            int countPages = (int)Math.Ceiling((double)queryDsTreEm.Count() / ELE_PER_PAGE);
            ViewBag.currentPage = currentPage;
            ViewBag.countPages = countPages;
            var dsTreEm = queryDsTreEm.Skip((currentPage - 1) * ELE_PER_PAGE).Take(ELE_PER_PAGE).ToList();
            ViewBag.TTTreEm = dsTreEm;
            return View();
        }

        [HttpGet]
        public IActionResult AddPhuHuynh()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddPhuHuynh([Bind]PhuHuynhMV ph)
        {
            if (ModelState.IsValid)
            {
                if(DateTime.Now.Year - ph.NgaySinh.Year < 18)
                {
                    ModelState.AddModelError("NgaySinh", "Tuổi phải trên 18");
                    return View();
                }
                //check email trùng
                var userCheck = _context.Users.Where(u => u.Email == ph.Email).FirstOrDefault();
                if(userCheck != null)
                {
                    ModelState.AddModelError("Email", "Email đã tồn tại");
                    return View();
                }

                var idNewPH = "";
                var PhNumbers = _context.PhuHuynhs
                .Select(l => new { PH = l, Number = l.MaPh.Substring(2) })
                .ToList();
                var PHFinal = PhNumbers
                .OrderByDescending(item => {
                    if (int.TryParse(item.Number, out int number))
                        return number;
                    return 0; // Hoặc giá trị mặc định khác bạn muốn sử dụng
                })
                .Select(item => item.PH.MaPh)
                .FirstOrDefault();
                if (PHFinal == null) idNewPH = "PH01";
                else
                {
                    int idNum = Int32.Parse(PHFinal.Substring(2));
                    idNewPH = $"PH0{++idNum}";
                }

                var phuHuynhNew = new QLPreschool.Data.PhuHuynh() {
                    MaPh = idNewPH,
                    TenPh = ph.TenPh,
                    DiaChiPh = ph.DiaChiPh,
                    GioiTinh = ph.GioiTinh,
                    NgaySinh = ph.NgaySinh,
                    SdtPhuhuynh = ph.SdtPhuhuynh
                };
                _context.PhuHuynhs.Add(phuHuynhNew);
                _context.SaveChanges();
                ViewBag.idPh = idNewPH;
                //Tạo user Ph
                //Kiểm tra unique Email


                var user = CreateUser();
                await _userStore.SetUserNameAsync(user, ph.Email, CancellationToken.None);
                await _userManager.SetEmailAsync(user, ph.Email);
                user.maPH = idNewPH;
                var result = await _userManager.CreateAsync(user, ph.MatKhau);
                if (result.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    //tạo ra token email confirm
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    await _userManager.ConfirmEmailAsync(user, code);
                }


                TempData["StatusMessage"] = "Tạo phụ huynh thành công. Nhập thông tin trẻ em phụ huynh đó.";
                return RedirectToAction("AddTreEm","QLTreEm",new {area = "TreEm",idPh = idNewPH});
            }
            ModelState.AddModelError("", "Lỗi dữ liệu đầu vào!");
            return View();
        }

        [HttpGet]
        public IActionResult AddTreEm(string? idPh)
        {
            if (idPh == null) return NotFound();
            ViewBag.idPh = idPh;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddTreEm([Bind]TreEmMV treEmView)
        {
           
            if(ModelState.IsValid)
            {
                var tuoiTE = DateTime.Now.Year - treEmView.NgaySinhTE.Year;
                if (tuoiTE < 3 || tuoiTE > 6)
                {
                    ModelState.AddModelError("NgaySinhTE", "Tuổi không hợp lệ (từ 3 đến 6 tuổi)");
                    ViewBag.idPh = treEmView.idPh;
                    return View();
                }
                var fileUpload = treEmView.AvatarTE;

                if (fileUpload != null)
                {
                    var fileName = GetUniqueFileName(fileUpload.FileName);

                    var path = Path.Combine(_hostingEnvironment.WebRootPath, "AdminDashboard\\img\\TreEm");
                    var pathImg = Path.Combine(path, fileName);
                    if (!System.IO.File.Exists(pathImg))
                    {
                        await fileUpload.CopyToAsync(new FileStream(pathImg, FileMode.Create));
                    }
                    var idNewTE = "";
                    var TeNumbers = _context.TreEms
                    .Select(l => new { TE = l, Number = l.MaTe.Substring(2) })
                    .ToList();
                    var TEFinal = TeNumbers
                    .OrderByDescending(item => {
                        if (int.TryParse(item.Number, out int number))
                            return number;
                        return 0; // Hoặc giá trị mặc định khác bạn muốn sử dụng
                    })
                    .Select(item => item.TE.MaTe)
                    .FirstOrDefault();
                    if (TEFinal == null) idNewTE = "TE01";
                    else
                    {
                        int idNum = Int32.Parse(TEFinal.Substring(2));
                        idNewTE = $"TE0{++idNum}";
                    }
                    var newTreEm = new Data.TreEm()
                    {
                        MaTe = idNewTE,
                        MaPh = treEmView.idPh,
                        TenTe = treEmView.TenTe,
                        NgaySinhTE = treEmView.NgaySinhTE,
                        GioiTinh = treEmView.GioiTinh,
                        AvatarTE = fileName
                    };
                    await _context.TreEms.AddAsync(newTreEm);
                    _context.SaveChanges();
                    TempData["StatusMessage"] = "Thêm Trẻ Em Thành Công";
                    return RedirectToAction("Index");
                }
            }
            TempData["StatusMessage"] = "Thêm Trẻ Em Không Thành Công. Thử lại";
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> DetailTreEm(string? idTreEm)
        {
            if (idTreEm == null) NotFound("ABC");
            var treEm = _context.TreEms.Where(te => te.MaTe == idTreEm).FirstOrDefault();
            var phuHuynh = _context.PhuHuynhs.Where(ph => ph.MaPh == treEm.MaPh).FirstOrDefault();
            ViewBag.phuHuynh = phuHuynh;
            var dsLopTreEm = await _context.TreEms.Include(te => te.MaLops).FirstOrDefaultAsync(te => te.MaTe == treEm.MaTe);
            var dsLop = dsLopTreEm.MaLops.ToList();
            ViewBag.DsLop = dsLop;
            var hkNamHoc = new List<object>();
            foreach (var item in dsLop)
            {
                var hkNamHocItem = _context.GiangDays.Where(gd => gd.MaLop == item.MaLop).
                    Select(gd => new { idLop = gd.MaLop,HocKy = gd.HocKy,NamHoc = gd.NamHoc}).FirstOrDefault();
                hkNamHoc.Add(hkNamHocItem);
            }
            ViewBag.hkNam = hkNamHoc;
            return View(treEm);
        }

        public ActionResult EditTreEm(string idTreEm)
        {
            if (String.IsNullOrEmpty(idTreEm)) NotFound();
            ViewBag.idTreEm = idTreEm;
            var ttTreEmQuery = _context.TreEms.Where(te => te.MaTe == idTreEm).FirstOrDefault();
            var ttPhuHuynhQuery = _context.PhuHuynhs.Where(ph => ph.MaPh == ttTreEmQuery.MaPh).FirstOrDefault();
            ViewBag.oldImg = ttTreEmQuery.AvatarTE;
            TTTreEmMV ttTreEm = new TTTreEmMV()
            {
                TenPh = ttPhuHuynhQuery.TenPh,
                DiaChiPh = ttPhuHuynhQuery.DiaChiPh,
                SdtPhuhuynh = ttPhuHuynhQuery.SdtPhuhuynh,
                GioiTinhPh = ttPhuHuynhQuery.GioiTinh,
                NgaySinhPh = ttPhuHuynhQuery.NgaySinh,
                TenTe = ttTreEmQuery.TenTe,
                GioiTinh = ttTreEmQuery.GioiTinh,
                NgaySinhTE = ttTreEmQuery.NgaySinhTE,
            };
            return View(ttTreEm);
        }

        [HttpPost]
        public async Task<ActionResult> EditTreEm(string idTreEm,[Bind]TTTreEmMV treEmEdit)
        {
            if(ModelState.IsValid)
            {
                
                ViewBag.idTreEm = idTreEm;
                var ttTreEmQuery = _context.TreEms.Where(te => te.MaTe == idTreEm).FirstOrDefault();
                var ttPhuHuynhQuery = _context.PhuHuynhs.Where(ph => ph.MaPh == ttTreEmQuery.MaPh).FirstOrDefault();
                int tuoiTE = DateTime.Now.Year - treEmEdit.NgaySinhTE.Year;
                if (tuoiTE < 3 || tuoiTE > 6)
                {
                    ModelState.AddModelError("NgaySinhTE", "Ngày sinh không hợp lệ");
                    TTTreEmMV ttTreEm = loadDataEditTreEm(ttTreEmQuery, ttPhuHuynhQuery, idTreEm);
                    return View(ttTreEm);
                }
                if (DateTime.Now.Year - treEmEdit.NgaySinhPh.Year < 18)
                {
                    ModelState.AddModelError("NgaySinh", "Tuổi phải trên 18");
                    TTTreEmMV ttTreEm = loadDataEditTreEm(ttTreEmQuery, ttPhuHuynhQuery, idTreEm);
                    return View(ttTreEm);
                }
                var fileUploadEdit = treEmEdit.AvatarTE;
                string fileNameNew = "";
                if (fileUploadEdit != null)
                {
                    var fileName = GetUniqueFileName(fileUploadEdit.FileName);
                    var path = Path.Combine(_hostingEnvironment.WebRootPath, "AdminDashboard\\img\\TreEm");
                    var oldAvatarPath = Path.Combine(path, ttTreEmQuery.AvatarTE);
                    try
                    {
                        if (System.IO.File.Exists(oldAvatarPath))
                        {
                            System.IO.File.Delete(oldAvatarPath);
                        }
                        var newAvatarPath = Path.Combine(path, fileName);
                        if (!System.IO.File.Exists(newAvatarPath))
                        {
                            await fileUploadEdit.CopyToAsync(new FileStream(newAvatarPath, FileMode.Create));
                            fileNameNew = fileName;
                        }
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Error deleting file, retrying...");

                        TTTreEmMV ttTreEm = loadDataEditTreEm(ttTreEmQuery,ttPhuHuynhQuery,idTreEm);
                        return View(ttTreEm);
                    }




                }
                if (!String.IsNullOrEmpty(fileNameNew)) ttTreEmQuery.AvatarTE = fileNameNew;
                ttTreEmQuery.TenTe = treEmEdit.TenTe;
                ttTreEmQuery.GioiTinh = treEmEdit.GioiTinh;
                ttTreEmQuery.NgaySinhTE = treEmEdit.NgaySinhTE;
                ttPhuHuynhQuery.TenPh = treEmEdit.TenPh;
                ttPhuHuynhQuery.DiaChiPh = treEmEdit.DiaChiPh;
                ttPhuHuynhQuery.SdtPhuhuynh = treEmEdit.SdtPhuhuynh;
                ttPhuHuynhQuery.NgaySinh = treEmEdit.NgaySinhPh;
                await _context.SaveChangesAsync();
                return RedirectToAction("DetailTreEm", "QLTreEm", new { idTreEm = ttTreEmQuery.MaTe, area = "TreEm" });
            }
            TempData["StatusMessage"] = "Lỗi thử lại";
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> AddTreEmIntoLop(string? idTreEm)
        {
            
            if(idTreEm == null) return NotFound();
            var treEm = _context.TreEms.Where(te => te.MaTe == idTreEm).FirstOrDefault();
            if(treEm == null) return NotFound();
            int tuoiTE = DateTime.Now.Year - treEm.NgaySinhTE.Year;
            var loaiLop = _context.LoaiLops.Where(ll => ll.DoTuoiBatDau <= tuoiTE && tuoiTE < ll.DoTuoiKetThuc).FirstOrDefault();
            ViewBag.TenLoaiLop = loaiLop.TenLoai;
            ViewBag.idTreEm = idTreEm;
            //check
            var lopTreEmDaHoc = await _context.TreEms.Include(te => te.MaLops).FirstOrDefaultAsync(te => te.MaTe == idTreEm);
            int count = 0;
            foreach (var item in lopTreEmDaHoc.MaLops)
            {
                var namHoc = _context.GiangDays.Where(gd => gd.MaLop == item.MaLop).Select(s => s.NamHoc).FirstOrDefault();
                if(namHoc == DateTime.Now.Year)
                {
                    count++;
                }
            }
            //trong năm học hiện tại đã thêm hai lớp học rồi
            if(count == 2)
            {
                TempData["StatusMessage"] = "Đã thêm đủ lớp trong năm cho trẻ em này";
                return RedirectToAction("DetailTreEm",new { idTreEm = idTreEm });
            }
            var dsLopTheoLoai = _context.Lops.Join(_context.GiangDays,l => l.MaLop,g => g.MaLop,(l,gd) => new {Lop = l,Hk = gd.HocKy,NamHoc = gd.NamHoc})
                .Where(l => l.Lop.MaLoai == loaiLop.MaLoai).Where(l => l.NamHoc == DateTime.Now.Year).ToList();
            var dsLopMV = new List<LopMV>();
            foreach (var item in dsLopTheoLoai)
            {
                var dsTreEmLop = await _context.Lops.Include(l => l.MaTes).FirstOrDefaultAsync(l => l.MaLop == item.Lop.MaLop);
                dsLopMV.Add(new LopMV()
                {
                    TenLop = item.Lop.TenLop,
                    MaLop = item.Lop.MaLop,
                    SiSo = item.Lop.SiSo,
                    ConLai = item.Lop.SiSo - dsTreEmLop.MaTes.Count,
                    hocKy = item.Hk,
                    NamHoc = item.NamHoc
                });
            }
            return View(dsLopMV);
        }

        [HttpPost, ActionName("AddTreEmIntoLop")]
        public async Task<ActionResult> AddTreEmIntoLopPost(string? LopAddInto,string hocky, string idTreEm)
        {
            //kiem tra trẻ em đã học lớp ở kỳ hiện tại chưa
            var dsLopcuaTe = await _context.TreEms.Include(te => te.MaLops)
                .FirstOrDefaultAsync(te => te.MaTe == idTreEm);
            bool checkTeLop = false;
            foreach (var item in dsLopcuaTe.MaLops)
            {
                var gd = _context.GiangDays.Where(gd => gd.MaLop == item.MaLop).Select(l => new {hk = l.HocKy,Nam = l.NamHoc}).FirstOrDefault();
                if(gd.hk == Int32.Parse(hocky) && gd.Nam == DateTime.Now.Year)
                {
                    checkTeLop = true;
                    break;
                }

            }
            if(checkTeLop == true)
            {
                TempData["StatusMessage"] = $"Trẻ em này đã được thêm lớp ở học kỳ {hocky} - {DateTime.Now.Year}";
                return RedirectToAction("DetailTreEm", new { idTreEm = idTreEm });
            }

            var lop = await _context.Lops.Include(l => l.MaTes).FirstOrDefaultAsync(l => l.MaLop == LopAddInto);
            var treEm = await _context.TreEms.FindAsync(idTreEm);
            if(lop != null && treEm != null)
            {
                lop.MaTes.Add(treEm);
                _context.SaveChanges();
            }
            return RedirectToAction("DetailTreEm", new { idTreEm = idTreEm });
        }

        public async Task<ActionResult> DeleteTreEm(string idTreEm)
        {
            if (String.IsNullOrEmpty(idTreEm)) return NotFound();
            try
            {
                var TreEm = _context.TreEms.Where(te => te.MaTe == idTreEm).FirstOrDefault();
                var TenTreEm = TreEm.TenTe;
                var lopOfTreEm = await _context.TreEms.Include(te => te.MaLops).FirstOrDefaultAsync(te => te.MaTe == idTreEm);
                var dsLop = new List<Lop>();
                foreach (var item in lopOfTreEm.MaLops)
                {
                    dsLop.Add(item); // Thêm các phần tử cần xóa vào danh sách tạm thời
                }
                if (dsLop.Count > 0)
                {
                    foreach (var item in dsLop)
                    {
                        lopOfTreEm.MaLops.Remove(item);
                    }
                }
                await _context.SaveChangesAsync();
                var phieuLLTreEm = _context.PhieuLienLacs.Where(pll => pll.MaTe == idTreEm).ToList();
                if (phieuLLTreEm.Count > 0)
                    _context.PhieuLienLacs.RemoveRange(phieuLLTreEm);
                var theTrangTreEm = _context.TheTrangs.Where(tt => tt.MaTe == idTreEm).ToList();
                if (theTrangTreEm.Count > 0)
                {
                    _context.TheTrangs.RemoveRange(theTrangTreEm);
                }
                await _context.SaveChangesAsync();
                var phuHuynh = _context.PhuHuynhs.Where(h => h.MaPh == TreEm.MaPh).FirstOrDefault();
                _context.TreEms.Remove(TreEm);
                _context.PhuHuynhs.Remove(phuHuynh);
                await _context.SaveChangesAsync();
                TempData["StatusMessage"] = $"Xóa Trẻ Em {TenTreEm}";
            }catch(Exception ex)
            {
                TempData["StatusMessage"] = $"Xóa Trẻ Em Không Thành Công {ex.Message}";
            }

            return RedirectToAction("Index");
        }
        private AppUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<AppUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(AppUser)}'. " +
                    $"Ensure that '{nameof(AppUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
        private TTTreEmMV loadDataEditTreEm(Data.TreEm ttTreEmQuery,Data.PhuHuynh ttPhuHuynhQuery,string idTreEm)
        {
            ViewBag.idTreEm = idTreEm;
            ViewBag.oldImg = ttTreEmQuery.AvatarTE;
            TTTreEmMV ttTreEm = new TTTreEmMV()
            {
                TenPh = ttPhuHuynhQuery.TenPh,
                DiaChiPh = ttPhuHuynhQuery.DiaChiPh,
                SdtPhuhuynh = ttPhuHuynhQuery.SdtPhuhuynh,
                GioiTinhPh = ttPhuHuynhQuery.GioiTinh,
                NgaySinhPh = ttPhuHuynhQuery.NgaySinh,
                TenTe = ttTreEmQuery.TenTe,
                GioiTinh = ttTreEmQuery.GioiTinh,
                NgaySinhTE = ttTreEmQuery.NgaySinhTE,
            };
            return ttTreEm;
        }
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
    }
}
