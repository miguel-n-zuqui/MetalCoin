using Metalcoin.Core.Domain;
using Metalcoin.Core.Dtos;
using Metalcoin.Core.Dtos.Categorias;
using Metalcoin.Core.Dtos.Request;
using Metalcoin.Core.Interfaces.Repositories;
using Metalcoin.Core.Interfaces.Services;
using MetalCoin.Application.Services;
using MetalCoin.Infra.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MetalCoin.Api.Controllers
{
    [ApiController]
    public class CuponDescontoController : ControllerBase
    {
        private readonly ICuponsRepository _cuponsRepository;
        private readonly ICuponsServices _cuponsServices;

        public CuponDescontoController(ICuponsRepository cuponsRepository)
        {
            _cuponsRepository = cuponsRepository;
        }

        [HttpGet]
        [Route("todos")]
        public async Task<ActionResult> ObterTodasCategorias()
        {
            var listarCupons = await _cuponsRepository.ObterTodos();

            if (listarCupons.Count == 0) return NoContent();

            return Ok(listarCupons);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult> ObterUmaCategoria(Guid id)
        {
            var categoria = await _cuponsRepository.ObterPorId(id);
            if (categoria == null) return BadRequest("Cupom não encontrada");
            return Ok(categoria);
        }


        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult> CadastrarCategoria([FromBody] CupomCadastrarRequest cupom)
        {
            if (cupom == null) return BadRequest("Informe o nome da cupom");

            var response = await _cuponsServices.CadastrarCupom(cupom);

            if (response == null) return BadRequest("Categoria já existe");

            return Created("cadastrar", response);
        }
        [HttpPut]
        [Route("atualizar")]
        public async Task<ActionResult> AtualizarCategoria([FromBody] CupomAtualizarRequest cupom)
        {
            if (cupom == null) return BadRequest("Nenhum valor chegou na API");

            var response = await _cuponsServices.AtualizaCupom(cupom);

            return Ok(response);
        }


        [HttpDelete]
        [Route("deletar/{id:guid}")]
        public async Task<ActionResult> RemoverCupom(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Id não informado");

            var resultado = await _cuponsServices.DeletarCupom(id);

            if (!resultado) return BadRequest("o cupom que está tentando deletar não existe");

            return Ok("Cupom deletada com sucesso");
        }




    }
}
