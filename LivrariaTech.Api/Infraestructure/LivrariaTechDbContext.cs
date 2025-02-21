using LivrariaTech.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LivrariaTech.Api.Infraestructure
{
    public class LivrariaTechDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\dev\\LivrariaTech\\db\\LivrariaTech.db");
        }
    }
}
