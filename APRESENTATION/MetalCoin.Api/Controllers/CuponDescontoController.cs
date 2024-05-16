using Metalcoin.Core.Domain;
using Metalcoin.Core.Dtos;
using Metalcoin.Core.Dtos.Categorias;
using Metalcoin.Core.Dtos.Request;
using Metalcoin.Core.Interfaces.Repositories;
using Metalcoin.Core.Interfaces.Services;
using MetalCoin.Application.Services;
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
            var listaCategorias = await _cuponsRepository.ObterTodos();

            if (listaCategorias.Count == 0) return NoContent();

            return Ok(listaCategorias);
        }


        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult> CadastrarCategoria([FromBody] CupomCadastrarRequest cupom)
        {
            if (cupom == null) return BadRequest("Informe o nome da categoria");

            var response = await _cuponsServices.CadastrarCupom(cupom);

            if (response == null) return BadRequest("Categoria já existe");

            return Created("cadastrar", response);
        }






    }
}
