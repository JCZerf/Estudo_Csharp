using Microsoft.EntityFrameworkCore;

namespace Estudo_C_.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Consumos> Consumos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
