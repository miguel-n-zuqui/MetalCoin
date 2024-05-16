using Metalcoin.Core.Domain;
using Metalcoin.Core.Dtos.Request;
using Metalcoin.Core.Dtos.Response;
using Metalcoin.Core.Interfaces.Repositories;
using Metalcoin.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MetalCoin.Application.Services
{
    public class CupomService : ICuponsServices
    {
        private readonly ICuponsRepository _cuponsRepository;
        public CupomService(ICuponsRepository repository)
        {
            _cuponsRepository = repository;
        }
        public async Task<CupomResponse> AtualizaCupom(CupomAtualizarRequest cupom)
        {
            var cupomDb = await _cuponsRepository.ObterPorId(cupom.Id);

            cupomDb.statusCupom = cupom.statusCupom;
            cupomDb.Descricao = cupom.Descricao.ToUpper();
            cupomDb.ValorDesconto = cupom.ValorDesconto;
            cupomDb.TipoDescontoCupon = cupom.TipoDescontoCupon;


            await _cuponsRepository.Atualizar(cupomDb);

            var response = new CupomResponse
            {
                CodigoCupom = cupomDb.CodigoCupom,
                Descricao = cupomDb.Descricao,
                statusCupom = cupomDb.statusCupom,
                TipoDescontoCupon = cupomDb.TipoDescontoCupon,
                ValorDesconto = cupomDb.ValorDesconto,



            };

            return response;
        }
       
        public async Task<CupomResponse> CadastrarCupom(CupomCadastrarRequest cupom)
        {
            var cupomEntidade = new Cupom
            {
                CodigoCupom = "aleatorio",
                Descricao = cupom.Descricao.ToUpper(),
                statusCupom = cupom.statusCupom,
                ValorDesconto = cupom.ValorDesconto,
                TipoDescontoCupon = cupom.TipoDescontoCupon
                
            };

            await _cuponsRepository.Adicionar(cupomEntidade);

            var response = new CupomResponse
            {
                CodigoCupom = cupomEntidade.CodigoCupom,
                Descricao = cupomEntidade.Descricao,
                statusCupom = cupomEntidade.statusCupom,
                TipoDescontoCupon = cupomEntidade.TipoDescontoCupon,
                ValorDesconto = cupomEntidade.ValorDesconto,
                
            };

            return response;
        }

        public async Task<bool> DeletarCupom(Guid id)
        {
            var categoria = await _cuponsRepository.ObterPorId(id);
            if (categoria == null) return false;


            await _cuponsRepository.Remover(id);
            return true;
        }
    }
}
