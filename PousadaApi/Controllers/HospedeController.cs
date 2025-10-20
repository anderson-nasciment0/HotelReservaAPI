using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PousadaApi.Models;
using PousadaApi.Repositories;

namespace PousadaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospedeController : ControllerBase
    {
        private readonly IHospedeRepository _hospedeRepository;

        public HospedeController(IHospedeRepository hospedeRepository)
        {
            _hospedeRepository = hospedeRepository;
        }

        [HttpGet("ObterTodos")]
        public ActionResult<IEnumerable<Hospede>> Get()
        {
            var hospedes = _hospedeRepository.GetAll();
            return Ok(hospedes);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterHospede")]
        public ActionResult<Hospede> Get(int id)
        {
            var hospede = _hospedeRepository.Get(x => x.Id == id);
            if (hospede == null)
            {
                return NotFound("Hospede não encontrada");
            }

            return Ok(hospede);
        }

        [HttpPost("CadastrarHospede")]
        public ActionResult Post(Hospede hospede)
        {
            if (hospede == null)
            {
                return BadRequest("Hospede é nulo");
            }
            var novoHospede = _hospedeRepository.Create(hospede);
            return new CreatedAtRouteResult("ObterHospede", new { id = novoHospede.Id }, novoHospede);
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult Put(int id, Hospede hospede)
        {
            if (id != hospede.Id)
            {
                return BadRequest();
            }

            var novoHospede = _hospedeRepository.Update(hospede);
            return Ok(novoHospede);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var hospede = _hospedeRepository.Get(x => x.Id == id);
            if (hospede == null)
            {
                return NotFound("Acomodação não encontrada");
            }

            var deletado = _hospedeRepository.Delete(hospede);
            return Ok(deletado);
        }
    }
}
