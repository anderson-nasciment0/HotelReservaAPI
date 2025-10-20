using PousadaApi.Data;
using PousadaApi.Models;

namespace PousadaApi.Repositories
{
    public class AcomodacaoRepository : Repository<Acomodacao>, IAcomodacaoRepository
    {
        private readonly AppDbContext _context;

        public AcomodacaoRepository(AppDbContext context) : base(context) { }
    }
}
