using Metalcoin.Core.Domain;
using Metalcoin.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalcoin.Core.Interfaces.Repositories
{
    public interface ICuponsRepository:IRepository<Cupom>
    {
        Task<Cupom> BuscarCupomAtivos(TipoStatusCupom status);
        Task<Cupom>BuscarCupomIndisponiveis(TipoStatusCupom status);
    }
}
