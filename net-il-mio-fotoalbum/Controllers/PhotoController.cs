using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using net_il_mio_fotoalbum.Interface;
using net_il_mio_fotoalbum.Models.Db;
using net_il_mio_fotoalbum.Models.Form;

namespace net_il_mio_fotoalbum.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class PhotoController : Controller
    {
        private readonly IRepository<Photo> _crudPhoto;
        private readonly IRepository<Category> _crudCategory;
        public PhotoController(IRepository<Photo> crudHeplper, IRepository<Category> crudCategory) 
        {
            _crudPhoto = crudHeplper;
            _crudCategory = crudCategory;
        }

        [HttpGet]
        public IActionResult Index()
        {

            List<Photo> photos =_crudPhoto.GetAll().ToList();
            return View(photos);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

           Photo photo = _crudPhoto.SearchAndInclude(p => p.Id == id, p => p.Categories);
            return View(photo);
        }

        [HttpGet]
        public IActionResult Create()
        {
            PhotoForm model = new();
            model.Categories = _crudCategory.GetAll().ToList();
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(PhotoForm model)
        {
            if (!ModelState.IsValid)
            {
                List<Category> categories = _crudCategory.GetAll().ToList();
                model.Categories = categories;
                return View("Create", model);
            }

            if (!model.CategoriesId.IsNullOrEmpty())
            {
                model.Photo.Categories?.Clear();
                model.Photo.Categories = new();
                foreach (var id in model.CategoriesId)
                {
                    Category category = _crudCategory.GetById(id);
                    if (category != null)
                        model.Photo.Categories.Add(category);

                }
            }
            
            SetImageFileFromFormFile(model);
            
            _crudPhoto.Add(model.Photo);

            return RedirectToAction("index");
        }


        [HttpPost]
        public IActionResult EditVisible(int id) 
        {
            Photo photoEdit = _crudPhoto.GetById(id);
            if (photoEdit == null)
                return RedirectToAction("index");
            if(photoEdit.Visible)
                photoEdit.Visible = false;
            else
                photoEdit.Visible = true;
            _crudPhoto.Update(photoEdit);
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Photo toDelete = _crudPhoto.GetById(id);
            _crudPhoto.Delete(toDelete);
            return RedirectToAction("Index");
        }

        private void SetImageFileFromFormFile(PhotoForm model)
        {
            if (model.ImageFormFile == null)
            {
                return;
            }

            MemoryStream stream = new MemoryStream();
            model.ImageFormFile.CopyTo(stream);
            model.Photo.ImageFile = stream.ToArray();

        }
    }
}

