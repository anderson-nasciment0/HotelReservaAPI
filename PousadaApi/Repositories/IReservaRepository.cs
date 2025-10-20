using PousadaApi.Models;

namespace PousadaApi.Repositories
{
    public interface IReservaRepository : IRepository<Reserva>
    {
        public int HospedesPorAcomodacao(Reserva reserva);
        public bool ConflitoReserva(Reserva reserva);
    }
}
