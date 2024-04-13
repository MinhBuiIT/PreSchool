using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLPreschool.Data;
using QLPreschool.ModelViews;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using QLPreschool.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;


namespace QLPreschool.Areas.GiaoVien.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("GiaoVien")]
    public class QLGiaoVienController : Controller
    {
        private QlTMnContext _context { get; set; }
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserStore<AppUser> _userStore;
        private readonly int ELE_PER_PAGE = 8;
        public QLGiaoVienController(QlTMnContext context,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment,
            UserManager<AppUser> userManager,
            IUserStore<AppUser> userStore) { 
            _context = context;
            _userManager = userManager;
            _userStore = userStore;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index(int? pages,string? search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                var dsGVSearch = (from gv in _context.GiaoViens where gv.TenGv.Contains(search) select gv).ToList();
                ViewBag.Search = search;

                return View(dsGVSearch);
            }
            if (pages == null) pages = 1;
            int currentPage = (int)pages;
            int countPages = (int)Math.Ceiling((double)_context.GiaoViens.Count() / ELE_PER_PAGE);
            ViewBag.currentPage = currentPage;
            ViewBag.countPages = countPages;
            var dsGV = (from gv in _context.GiaoViens select gv).ToList()
                .Skip((currentPage - 1) * ELE_PER_PAGE).Take(ELE_PER_PAGE).ToList();
            
            return View(dsGV);

        }

        public IActionResult DetailGV(string? idGv)
        {
            if(String.IsNullOrEmpty(idGv))
            {
                return View("NotFound");
            }
            var gvDetail = _context.GiaoViens.Where(gv => gv.MaGv == idGv).FirstOrDefault();
            if(gvDetail == null)
            {
                return View("NotFound");
            }
            ViewBag.idGv = gvDetail.MaGv;
            ViewBag.GvDetail = gvDetail;
            ViewBag.Email = _context.Users.Where(u => u.maGV == idGv).FirstOrDefault().Email;
            var dsGiangDay = _context.GiangDays.Where(gd => gd.MaGv == gvDetail.MaGv).ToList();
            var detailGiangDayGVList = new List<GiangDayGVMV>();
            if(dsGiangDay.Count > 0)
            {
                foreach (var gd in dsGiangDay)
                {
                    var LopGD = _context.Lops.Where(l => l.MaLop == gd.MaLop).FirstOrDefault();
                    var phongGD = _context.PhongHocs.Where(p => p.MaPhong == LopGD.MaPhong).FirstOrDefault();
                    detailGiangDayGVList.Add(new GiangDayGVMV()
                    {
                        tenGV = gvDetail.TenGv,
                        gioiTinh = gvDetail.GioiTinh,
                        DiaChi = gvDetail.DiaChi,
                        AvatarGV = gvDetail.AvatarGV,
                        chucVu = gvDetail.ChucVu,
                        SDT_GV = gvDetail.SdtGv,
                        tenLop = LopGD.TenLop,
                        si_so = LopGD.SiSo,
                        hocKi = gd.HocKy,
                        namHoc = gd.NamHoc,
                        TenPhong = phongGD.TenPhong
                    });
                }
            }
            
            return View(detailGiangDayGVList);
        }

        [HttpGet]
        public IActionResult AddClassGV(string? idGv)
        {
            if (String.IsNullOrEmpty(idGv))
            {
                return View("NotFound");
            }
            ViewBag.idGV = idGv;
            LoadDataInAddClass();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> AddClassGV(string? idGv,[Bind]LopPTMV lopPT)
        {
            if (String.IsNullOrEmpty(idGv))
            {
                return View("NotFound");
            }
            var gvPT = _context.GiaoViens.Where(gv => gv.MaGv == idGv).FirstOrDefault();
            if (gvPT == null)
            {
                return View("NotFound");
            }
            var sucChuaPhong = _context.PhongHocs.Where(p => p.MaPhong == lopPT.MaPhong).FirstOrDefault().SucChua;
            if(lopPT.SiSo > sucChuaPhong)
            {
                ModelState.AddModelError("SiSo", $"Sỉ số vượt quá sức chứa phòng({sucChuaPhong})");
                ViewBag.idGV = idGv;
                LoadDataInAddClass();
                return View("AddClassGV");
            }
            if(String.IsNullOrEmpty(lopPT.MaLoai))
            {
                ModelState.AddModelError("MaLoai", $"Vui lòng chọn loại lớp");
                ViewBag.idGV = idGv;
                LoadDataInAddClass();
                return View("AddClassGV");
            }
            //check giáo viên chỉ được dạy ở một kỳ trong một năm học
            var getGVDayHkNH = _context.GiangDays.Where(gd => gd.HocKy == lopPT.HocKi && gd.NamHoc == lopPT.NamHoc && gd.MaGv == idGv).FirstOrDefault();
            if(getGVDayHkNH != null)
            {
                ModelState.AddModelError("", $"Giáo viên đã phụ trách ở học kỳ này");
                ViewBag.idGV = idGv;
                LoadDataInAddClass();
                return View("AddClassGV");
            }

            //check phòng đã dạy tại học kỳ năm học hay chưa

            var getGdHkyNamHoc = _context.GiangDays.Where(gd => gd.HocKy == lopPT.HocKi && gd.NamHoc == lopPT.NamHoc).ToList();
            bool checkRoomExits = false;
            foreach(var gd in getGdHkyNamHoc)
            {
                var mp = _context.Lops.Where(l => l.MaLop == gd.MaLop).FirstOrDefault().MaPhong;
                if(mp == lopPT.MaPhong)
                {
                    checkRoomExits = true;
                    break;
                }
            }
            if(checkRoomExits == true)
            {
                ModelState.AddModelError("MaPhong", $"Phòng đã được sắp xếp ở học kỳ này");
                ViewBag.idGV = idGv;
                LoadDataInAddClass();
                return View("AddClassGV");
            }
            var idNewLop = "";
            var lopNumbers = _context.Lops
            .Select(l => new { Lop = l, Number = l.MaLop.Substring(2) })
            .ToList();
            var lopFinal = lopNumbers
            .OrderByDescending(item => {
                if (int.TryParse(item.Number, out int number))
                     return number;
                return 0; // Hoặc giá trị mặc định khác bạn muốn sử dụng
                })
            .Select(item => item.Lop.MaLop)
            .FirstOrDefault();
            if (lopFinal == null) idNewLop = "L01";
            else
            {
                int idNum = Int32.Parse(lopFinal.Substring(2));
                idNewLop = $"L0{++idNum}";
            }
            
           try
            {
                await _context.Lops.AddAsync(new Lop()
                {
                    MaLoai = lopPT.MaLoai,
                    MaPhong = lopPT.MaPhong,
                    MaLop = idNewLop,
                    TenLop = lopPT.TenLop,
                    SiSo = lopPT.SiSo,
                });
                await _context.GiangDays.AddAsync(new GiangDay()
                {
                    MaGv = idGv,
                    MaLop = idNewLop,
                    HocKy = lopPT.HocKi,
                    NamHoc = lopPT.NamHoc
                });
                _context.SaveChanges();
                return RedirectToAction("DetailGV",new {idGv = idGv});
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("",ex.Message);
                ViewBag.idGV = idGv;
                LoadDataInAddClass();
                return View("AddClassGV");
            }
        }

        [HttpGet]
        public IActionResult AddGV()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGV([Bind]GiaoVienMV gvMV)
        {
            if(ModelState.IsValid)
            {
                var checkEmail = await _userManager.FindByEmailAsync(gvMV.Email);
                if (checkEmail != null)
                {
                    ModelState.AddModelError("Email", "Email đã tồn tại");
                    return View("AddGV");
                }
                var fileUpload = gvMV.AvatarGV;
                if(fileUpload != null)
                {
                    var filename = GetUniqueFileName(fileUpload.FileName);
                    var pathFolder = Path.Combine(_hostingEnvironment.WebRootPath, "AdminDashboard\\img");
                    var filePath = Path.Combine(pathFolder, filename);
                    string? avatarStr = null;
                    if(!System.IO.File.Exists(filePath))
                    {
                        avatarStr = filename;
                        gvMV.AvatarGV.CopyTo(new FileStream(filePath,FileMode.Create));
                    }
                    var idNewGV = "";
                    var GvNumbers = _context.GiaoViens
                    .Select(l => new { GV = l, Number = l.MaGv.Substring(2) })
                    .ToList();
                    var GVFinal = GvNumbers
                    .OrderByDescending(item => {
                        if (int.TryParse(item.Number, out int number))
                            return number;
                        return 0; // Hoặc giá trị mặc định khác bạn muốn sử dụng
                    })
                    .Select(item => item.GV.MaGv)
                    .FirstOrDefault();
                    if (GVFinal == null) idNewGV = "GV01";
                    else
                    {
                        int idNum = Int32.Parse(GVFinal.Substring(2));
                        idNewGV = $"GV0{++idNum}";
                    }
                    await _context.GiaoViens.AddAsync(new Data.GiaoVien() {
                        MaGv = idNewGV,
                        TenGv = gvMV.TenGV,
                        GioiTinh = gvMV.GioiTinh,
                        DiaChi  = gvMV.DiaChi,
                        ChucVu = gvMV.ChucVu,
                        SdtGv = gvMV.SDT,
                        AvatarGV = avatarStr
                    });
                    
                    _context.SaveChanges();
                    //Tạo user GV
                    //Kiểm tra unique Email
                    

                    var user = CreateUser();
                    await _userStore.SetUserNameAsync(user, gvMV.Email, CancellationToken.None);
                    await _userManager.SetEmailAsync(user, gvMV.Email);
                    user.maGV = idNewGV;
                    var result = await _userManager.CreateAsync(user, gvMV.MatKhau);
                    if(result.Succeeded)
                    {
                        var userId = await _userManager.GetUserIdAsync(user);
                        //tạo ra token email confirm
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        await _userManager.ConfirmEmailAsync(user, code);
                    }
                    return RedirectToAction("Index");
                }
            }
            return View("AddGV");
        }

        [HttpGet]
        public ActionResult EditGV(string? idGv)
        {
            if (String.IsNullOrEmpty(idGv))
            {
                return View("NotFound");
            }
            var gvDetail = _context.GiaoViens.Where(gv => gv.MaGv == idGv).FirstOrDefault();
            if (gvDetail == null)
            {
                return View("NotFound");
            }
            var gvModelView = new GiaoVienEditMV() {
                TenGV = gvDetail.TenGv,
                DiaChi = gvDetail.DiaChi,
                GioiTinh = gvDetail.GioiTinh,
                ChucVu = gvDetail.ChucVu,
                SDT = gvDetail.SdtGv
            };
            ViewBag.IdGv = idGv;
            ViewBag.AvatarGV = gvDetail.AvatarGV;
            return View(gvModelView);
        }

        [HttpPost]
        public async Task<ActionResult> EditGV(string? idGv,[Bind]GiaoVienEditMV gvForm)
        {
            if (String.IsNullOrEmpty(idGv))
            {
                return View("NotFound");
            }
            var gvDetail = await _context.GiaoViens.FindAsync(idGv);
            if (gvDetail == null)
            {
                return View("NotFound");
            }
            var fileUploadEdit = gvForm.AvatarGV;
            string fileNameNew = "";
            if(fileUploadEdit != null)
            {
                var fileName = GetUniqueFileName(fileUploadEdit.FileName);
                var path = Path.Combine(_hostingEnvironment.WebRootPath, "AdminDashboard\\img");
                var oldAvatarPath = Path.Combine(path, gvDetail.AvatarGV);
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
                    var gvModelView = new GiaoVienEditMV()
                    {
                        TenGV = gvDetail.TenGv,
                        DiaChi = gvDetail.DiaChi,
                        GioiTinh = gvDetail.GioiTinh,
                        ChucVu = gvDetail.ChucVu,
                        SDT = gvDetail.SdtGv
                    };
                    ViewBag.IdGv = idGv;
                    ViewBag.AvatarGV = gvDetail.AvatarGV;
                    return View(gvModelView);
                }
                
                
                

            }
            if(!String.IsNullOrEmpty(fileNameNew)) gvDetail.AvatarGV= fileNameNew;
            gvDetail.TenGv = gvForm.TenGV;
            gvDetail.ChucVu = gvForm.ChucVu;
            gvDetail.GioiTinh = gvForm.GioiTinh;
            gvDetail.DiaChi = gvForm.DiaChi;
            gvDetail.SdtGv = gvForm.SDT;
            await _context.SaveChangesAsync();
            return RedirectToAction("DetailGV", "QLGiaoVien", new { idGv = gvDetail.MaGv, area = "GiaoVien" });
        }

        public async Task<ActionResult> DeleteGV(string? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var gvDelete =  _context.GiaoViens.Where(gv => gv.MaGv == id).FirstOrDefault();
            if (gvDelete == null) return NotFound();
            //xóa avatar
            var fileNameAvatar = gvDelete.AvatarGV;
            var path = Path.Combine(_hostingEnvironment.WebRootPath, $"AdminDashboard\\img\\{fileNameAvatar}");
            try
            {
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                var giangDayGVDelete = await _context.GiangDays.Where(gd => gd.MaGv == gvDelete.MaGv).ToListAsync();
                var dsGD = giangDayGVDelete;
                _context.GiangDays.RemoveRange(giangDayGVDelete);
                
                
                _context.GiaoViens.Remove(gvDelete);
                _context.SaveChanges();
                TempData["StatusMessage"] = "Xóa thành công";
                return RedirectToAction("Index");
            }catch(Exception ex)
            {
                TempData["StatusMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
            
        }
        private void LoadDataInAddClass()
        {
            var loaiLop = from ll in _context.LoaiLops select ll;
            ViewBag.loaiLop = new SelectList(loaiLop, "MaLoai", "TenLoai");
            var phongHoc = from p in _context.PhongHocs select p;
            ViewBag.phongHoc = new SelectList(phongHoc, "MaPhong", "TenPhong");
            var nmHk = (from item in _context.HocKyNamHocs where item.NamHoc >= DateTime.Now.Year select item.NamHoc)
                .Distinct();
            ViewBag.nmHk = new SelectList(nmHk);
        }
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
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
    }
}
