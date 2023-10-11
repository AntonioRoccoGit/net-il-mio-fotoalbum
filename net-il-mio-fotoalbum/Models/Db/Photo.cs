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

        [Column("visible")]
        public bool Visible {  get; set; }
        
        public List<Category>? Categories { get; set; }

        public Photo() { }

    }
}
