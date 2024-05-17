﻿using Metalcoin.Core.Dtos.Categorias;
using Metalcoin.Core.Dtos.Request;
using Metalcoin.Core.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalcoin.Core.Interfaces.Services
{
    public interface ICuponsServices
    {
        Task<CupomResponse> CadastrarCupom(CupomCadastrarRequest cupom);
        Task<CupomResponse> AtualizaCupom(CupomAtualizarRequest cupom);
        Task<bool> DeletarCupom(Guid id);
        Task<bool> AtivarCupom(AtivareDesativarCupomRequest cupom);
        Task<bool> DesativarCupom(AtivareDesativarCupomRequest cupom);
        Task<CupomResponse> UtilizarCupom(UtilizarCupomRequest cupom);
    }
}
