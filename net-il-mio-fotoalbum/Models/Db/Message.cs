using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_il_mio_fotoalbum.Models.Db
{
    [Table("message")]
    public class Message
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("e_mail"), EmailAddress]
        public string EMail { get; set; }

        [Column("text")]
        public string Text { get; set; }

        [Column("is_new")]
        public bool? IsNew { get; set; } = true;
        
        public Message() { }
    }
}
