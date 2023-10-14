using System.ComponentModel.DataAnnotations.Schema;

namespace net_il_mio_fotoalbum.Models.Db
{
    [Table("photo")]
    public class Photo
    {

        [Column("id")]
        public int Id { get; set; }
        
        [Column("title")]
        public string Title { get; set; }
        
        [Column("description")]
        public string? Description { get; set; }
        
        [Column("image")]
        public byte[]? ImageFile { get; set; }
        public string? ImageUrl => ImageFile is null ? "https://www.technol.si/wp-content/uploads/2018/11/default-image1.jpg" : $"data:image/png;base64,{Convert.ToBase64String(ImageFile)}";


        [Column("visible")]
        public bool Visible {  get; set; }
        
        public List<Category>? Categories { get; set; }

        public Photo() { }

    }
}
