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

        public async Task<bool> AtivarCupom(AtivareDesativarCupomRequest cupom)
        {
            var cupomDb = await _cuponsRepository.ObterPorId(cupom.Id);
            if (cupomDb.statusCupom == 0) return false;
            cupomDb.statusCupom = cupom.StatusCupom;

           await _cuponsRepository.Atualizar(cupomDb);
           
            
            return true;
        }

        public async Task<CupomResponse> AtualizaCupom(CupomAtualizarRequest cupom)
        {
            var cupomDb = await _cuponsRepository.ObterPorId(cupom.Id);

            cupomDb.statusCupom = cupom.statusCupom;
            cupomDb.Descricao = cupom.Descricao.ToUpper();
            cupomDb.ValorDesconto = cupom.ValorDesconto;
            cupomDb.TipoDescontoCupon = cupom.TipoDescontoCupon;
            cupomDb.DataValidade = DateTime.Now;
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
            if (cupom.DataValidade < DateTime.Now) return null;
            var cupomEntidade = new Cupom
            {
                CodigoCupom = "aleatorio",
                Descricao = cupom.Descricao.ToUpper(),
                statusCupom = cupom.statusCupom,
                ValorDesconto = cupom.ValorDesconto,
                TipoDescontoCupon = cupom.TipoDescontoCupon,
                DataValidade = cupom.DataValidade,
                
                
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
            var cupom = await _cuponsRepository.ObterPorId(id);
            if (cupom == null) return false;


            await _cuponsRepository.Remover(id);
            return true;
        }

        public async Task<bool> DesativarCupom(AtivareDesativarCupomRequest cupom)
        {
            var cupomDb = await _cuponsRepository.ObterPorId(cupom.Id);
            if (cupomDb.statusCupom == 0) return false;
            cupomDb.statusCupom = cupom.StatusCupom;

            await _cuponsRepository.Atualizar(cupomDb);


            return true;
        }

        public Task<CupomResponse> UtilizarCupom(UtilizarCupomRequest cupom)
        {
            throw new NotImplementedException();
        }
    }
}
