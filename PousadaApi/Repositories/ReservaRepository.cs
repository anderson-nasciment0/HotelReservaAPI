using PousadaApi.Data;
using PousadaApi.Models;

namespace PousadaApi.Repositories
{
    public class ReservaRepository : Repository<Reserva>, IReservaRepository
    {
        private readonly AppDbContext _context;

        public ReservaRepository(AppDbContext context) : base(context) { }

        public int HospedesPorAcomodacao(Reserva reserva)
        {
            return GetAll().Where(x => x.AcomodacaoId == reserva.AcomodacaoId).Count();
        }

        public bool ConflitoReserva(Reserva reserva)
        {
            return GetAll().Any(r =>
    r.AcomodacaoId == reserva.AcomodacaoId &&
    r.CheckIn < reserva.CheckOut &&
    reserva.CheckIn < r.CheckOut);
        }
    }
}
