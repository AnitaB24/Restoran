using Microsoft.EntityFrameworkCore;

namespace Server.Models
{
    public class FastFoodContext : DbContext{
        public DbSet<FastFood> Restorani {get;set;}
        public DbSet<Lokacija> Lokacije {get;set;}

        public DbSet<Obracun> Racuni {get;set;}

        public FastFoodContext(DbContextOptions options) :base(options)
        {

        }
    }
}