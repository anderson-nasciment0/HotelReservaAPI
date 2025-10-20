using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PousadaApi.Models;
using PousadaApi.Repositories;

namespace PousadaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IAcomodacaoRepository _acomodacaoRepository;
        private readonly IHospedeRepository _hospedeRepository;


        public ReservaController(IReservaRepository reservaRepository, IAcomodacaoRepository acomodacaoRepository, IHospedeRepository hospedeRepository)
        {
            _reservaRepository = reservaRepository;
            _acomodacaoRepository = acomodacaoRepository;
            _hospedeRepository = hospedeRepository;
        }

        [HttpGet("ObterTodos")]
        public ActionResult<IEnumerable<Reserva>> Get()
        {
            var reservas = _reservaRepository.GetAll();
            return Ok(reservas);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterReserva")]
        public ActionResult<Reserva> Get(int id)
        {
            var reserva = _reservaRepository.Get(x => x.Id == id);
            if (reserva == null)
            {
                return NotFound("Reserva não encontrada");
            }

            return Ok(reserva);
        }

        [HttpPost("CadastrarReserva")]
        public ActionResult Post(Reserva reserva)
        {
            var acomodacao = _acomodacaoRepository.Get(a => a.Id == reserva.AcomodacaoId);
            var hospede = _hospedeRepository.Get(h => h.Id == reserva.HospedeId);

            if (reserva == null)
            {
                return BadRequest("Reserva não encontrada");
            }

            if (acomodacao == null)
            {
                return BadRequest("Acomodação não encontrada");
            }

            if (hospede == null)
            {
                return BadRequest("Hospede não encontrado");
            }

            if (reserva.CheckIn >= reserva.CheckOut)
            {
                return BadRequest("A data de check-int deve ser anterior a data de check-out");
            }

            if (reserva.CheckIn < DateTime.Today)
            {
                return BadRequest("A data de check-int não pode ser anterior a data atual");
            }

            var reservasExistentes = _reservaRepository.HospedesPorAcomodacao(reserva);
            bool conflitoReserva = _reservaRepository.ConflitoReserva(reserva);

            if (conflitoReserva)
            {
                return BadRequest("Ja existe uma reserva para essa data");
            }

            if (reservasExistentes >= acomodacao.Capacidade)
            {
                return BadRequest("A capacidade da acomodação está lotada");
            }

            int quantidadeDias = (reserva.CheckOut.Value - reserva.CheckIn.Value).Days;

            if (quantidadeDias < 1)
            {
                return BadRequest("A reserva deve ter pelo menos uma diaria");
            }
            reserva.ValorTotal = quantidadeDias * acomodacao.PrecoDiaria;

            var novaReserva = _reservaRepository.Create(reserva);
            return new CreatedAtRouteResult("ObterReserva", new { id = novaReserva.Id }, novaReserva);
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult Put(int id, Reserva reserva)
        {
            bool conflitoReserva = _reservaRepository.ConflitoReserva(reserva);

            if (id != reserva.Id)
            {
                return BadRequest("Reserva não encontrada");
            }
            if (reserva.CheckIn >= reserva.CheckOut)
            {
                return BadRequest("A data de check-int deve ser anterior a data de check-out");
            }
            if (reserva.CheckIn < DateTime.Today)
            {
                return BadRequest("A data de check-int não pode ser anterior a data atual");
            }
            if (conflitoReserva)
            {
                return BadRequest("Ja existe uma reserva para essa data");
            }

            var novaReserva = _reservaRepository.Update(reserva);
            return Ok(novaReserva);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var reserva = _reservaRepository.Get(x => x.Id == id);
            if (reserva == null)
            {
                return NotFound("Reserva não encontrada");
            }

            var deletado = _reservaRepository.Delete(reserva);
            return Ok(deletado);
        }
    }
}
