using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Interface;
using net_il_mio_fotoalbum.Models.Db;

namespace net_il_mio_fotoalbum.Controllers.Api
{
    [Route("api/photo/[action]")]
    [ApiController]
    public class ApiPhotoController : ControllerBase
    {

        private readonly IRepository<Photo> _crudPhoto;

        public ApiPhotoController(IRepository<Photo> crudPhoto)
        {
            _crudPhoto = crudPhoto;
        }

        [HttpGet]
        public IActionResult GetFilterName(string name = "")
        {
            if(name != "")
            {
                List<Photo> photos = _crudPhoto.SearchAndIncludeList(p => p.Visible && p.Title.Contains(name), p => p.Categories);
                if(photos.Count <= 0)
                    return NotFound();
                return Ok(photos);
            }
            return BadRequest();
        }
    }
}
