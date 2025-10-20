using Microsoft.EntityFrameworkCore;
using PousadaApi.Models;

namespace PousadaApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Acomodacao> Acomodacoes { get; set; }
        public DbSet<Hospede> Hospedes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
    }
}
