using Microsoft.AspNetCore.Http;
using net_il_mio_fotoalbum.Models.Db;

namespace net_il_mio_fotoalbum.Models.Form
{
    public class PhotoForm
    {
        public Photo Photo { get; set; }

        public List<Category>? Categories { get; set; }

        public List<int>? CategoriesId { get; set; }

        public IFormFile? ImageFormFile { get; set; }
    }
}
