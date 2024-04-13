using Microsoft.AspNetCore.Mvc;
using QLPreschool.Data;
using QLPreschool.Models;
using System.Diagnostics;

namespace QLPreschool.Controllers
{
    public class HomeController : Controller
    {
        private QlTMnContext _context { get; set; }
        private readonly ILogger<HomeController> _logger;
        private int ELE_PER_PAGE = 6;

        public HomeController(ILogger<HomeController> logger,QlTMnContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult News()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Classes(int? pages)
        {
            if (pages == null) pages = 1;
            
            var dsLopGD = (from lop in _context.Lops
                           join gd in _context.GiangDays on lop.MaLop equals gd.MaLop
                           select new {lop,namhoc = gd.NamHoc}).ToList();
            var dsLopNowYear = dsLopGD.Where(item => item.namhoc == DateTime.Now.Year).Select(item => item.lop).ToList();
            int currentPage = (int)pages;
            int countPages = (int)Math.Ceiling((double)dsLopNowYear.Count() / ELE_PER_PAGE);
            ViewBag.currentPage = currentPage;
            ViewBag.countPages = countPages;
            var dsLop = dsLopNowYear.Skip((currentPage-1) * ELE_PER_PAGE).Take(ELE_PER_PAGE).ToList();
            return View(dsLop);
        }
        public IActionResult Teachers(int? pages)
        {
            if (pages == null) pages = 1;
            int currentPage = (int)pages;
            int countPages = (int)Math.Ceiling((double)_context.GiaoViens.Count() / ELE_PER_PAGE);
            ViewBag.currentPage = currentPage;
            ViewBag.countPages = countPages;
            var dsGV = (from gv in _context.GiaoViens select gv)
                .Skip((currentPage - 1) * ELE_PER_PAGE).Take(ELE_PER_PAGE).ToList();
            return View(dsGV);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
