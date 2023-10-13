using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Interface;
using net_il_mio_fotoalbum.Models;
using net_il_mio_fotoalbum.Models.Db;
using System.Diagnostics;

namespace net_il_mio_fotoalbum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Photo> _crudPhoto;
        private readonly IRepository<Category> _crudCategory;

        public HomeController(ILogger<HomeController> logger, IRepository<Photo> crudPhoto ,IRepository<Category> crudCategory)
        {
            _logger = logger;
            _crudPhoto = crudPhoto;
            _crudCategory = crudCategory;
        }

        public IActionResult Index()
        {

            List<Photo> list = _crudPhoto.SearchAndIncludeList(p => p.Visible == true, p => p.Categories);

            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}