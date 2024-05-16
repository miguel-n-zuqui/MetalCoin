using Metalcoin.Core.Domain;
using Metalcoin.Core.Dtos;
using Metalcoin.Core.Dtos.Categorias;
using Metalcoin.Core.Dtos.Request;
using Metalcoin.Core.Interfaces.Repositories;
using Metalcoin.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace MetalCoin.Api.Controllers
{
    [ApiController]
    public class CuponDescontoController : ControllerBase
    {
        private readonly ICuponsRepository _cuponsRepository;

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








    }
}
