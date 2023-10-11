using System.ComponentModel.DataAnnotations.Schema;

namespace net_il_mio_fotoalbum.Models.Db
{
    [Table("category")]
    public class Category
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public List<Photo>? Photos { get; set; }

        public Category() { }
    }
}
