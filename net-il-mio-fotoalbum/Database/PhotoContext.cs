using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using net_il_mio_fotoalbum.Models.Db;

namespace net_il_mio_fotoalbum.Database
{
    public class PhotoContext : IdentityDbContext<IdentityUser>
    {

        public DbSet<Photo> Photos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Message> Messages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=PhotoAlbum;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
