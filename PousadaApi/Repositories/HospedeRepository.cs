using PousadaApi.Data;
using PousadaApi.Models;

namespace PousadaApi.Repositories
{
    public class HospedeRepository : Repository<Hospede>, IHospedeRepository
    {
        private readonly AppDbContext _context;

        public HospedeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
