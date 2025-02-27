using LivrariaTech.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LivrariaTech.Api.Infraestructure.DataAccess
{
    public class LivrariaTechDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\dev\\LivrariaTech\\db\\LivrariaTech.db");
        }
    }
}
