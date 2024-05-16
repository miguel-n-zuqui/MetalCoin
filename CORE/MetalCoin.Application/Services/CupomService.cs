using Metalcoin.Core.Domain;
using Metalcoin.Core.Dtos.Request;
using Metalcoin.Core.Dtos.Response;
using Metalcoin.Core.Interfaces.Repositories;
using Metalcoin.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalCoin.Application.Services
{
    internal class CupomService : ICuponsServices
    {
        private readonly ICuponsRepository _cuponsRepository;
        public CupomService(ICuponsRepository repository)
        {
            _cuponsRepository = repository;
        }
        public Task<CupomResponse> AtualizaCupom(CupomCadastrarRequest cupom)
        {
            throw new NotImplementedException();
        }

        public Task<CupomResponse> CadastrarCupom(CupomCadastrarRequest cupom)
        {
            var cupomEntidade = new Cupom
            {
                CodigoCupom = Guid.NewGuid(),
                Descricao = cupom.Descricao.ToUpper(),
                statusCupom = cupom.statusCupom,
                ValorDesconto = cupom.ValorDesconto,
                TipoDescontoCupon = cupom.TipoDescontoCupon
                
            };

            await _cuponsRepository.Adicionar(cupomEntidade);

            var response = new CategoriaResponse
            {
                
            };

            return response;
        }

        public Task<bool> DeletarCupom(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
