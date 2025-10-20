using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PousadaApi.Data;
using PousadaApi.Models;
using PousadaApi.Repositories;

namespace PousadaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcomodacaoController : ControllerBase
    {
        private readonly IAcomodacaoRepository _acomodacaoRepository;

        public AcomodacaoController(IAcomodacaoRepository acomodacaoRepository)
        {
            _acomodacaoRepository = acomodacaoRepository;
        }

        [HttpGet("ObterTodos")]
        public ActionResult<IEnumerable<Acomodacao>> Get()
        {
            var acomodacoes = _acomodacaoRepository.GetAll();
            return Ok(acomodacoes);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterAcomodacao")]
        public ActionResult<Acomodacao> Get(int id)
        {
            var acomodacao = _acomodacaoRepository.Get(x => x.Id == id);
            if (acomodacao == null) {
                return NotFound("Acomodação não encontrada");
            }

            return Ok(acomodacao);
        }

        [HttpPost("CadastrarAcomodacao")]
        public ActionResult Post(Acomodacao acomodacao)
        {
            if (acomodacao == null)
            {
                return BadRequest("Acomodação é nula");
            }
            var novaAcomodacao = _acomodacaoRepository.Create(acomodacao);
            return new CreatedAtRouteResult("ObterAcomodacao", new { id = novaAcomodacao.Id }, novaAcomodacao);
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult Put(int id, Acomodacao acomodacao)
        {
            if(id != acomodacao.Id)
            {
                return BadRequest();
            }

            var novaAcomodacao = _acomodacaoRepository.Update(acomodacao);
            return Ok(novaAcomodacao);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var acomodacao = _acomodacaoRepository.Get(x => x.Id == id);
            if(acomodacao == null)
            {
                return NotFound("Acomodação não encontrada");
            }

            var deletado = _acomodacaoRepository.Delete(acomodacao);
            return Ok(deletado);
        }
    }
}
